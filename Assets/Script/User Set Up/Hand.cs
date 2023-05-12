using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    ////Animation Vars
    //public float animationSpeed;
    //private float gripTarget;
    //private float gripCurrent;
    //private float triggerTarget;
    //private float triggerCurrent;
    //private string animatorGripParam = "Grip";
    //private string animatorTriggerParam = "Trigger";

    //private Animator animator;
    //private SkinnedMeshRenderer skinnedMeshRenderer;

    //Physics Movement
    [Space]
    [SerializeField] private ActionBasedController controller;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [Space]
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    [Space]
    [SerializeField] private Transform palm; //postition to make contact with
    [SerializeField] private float reachDistance = 0.01f, joinDistance = 0.05f;
    [SerializeField] private LayerMask grabbableLayer;


    private Transform _followTarget;
    private Rigidbody _body;

    private bool isGrabbing;
    private GameObject heldObject;
    private Transform grabPoint;
    private FixedJoint joint1, joint2;



    // Start is called before the first frame update
    void Start()
    {
        ////Animation
        //animator = GetComponent<Animator>();
        //skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        //Physics Movement
        _followTarget = controller.gameObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;
        _body.maxAngularVelocity = 20f;

        //Input setup
        controller.selectAction.action.started += Grab;
        controller.selectAction.action.canceled += Release;
        
        //Positioning Hands
        _body.rotation = _followTarget.rotation;
        _body.position = _followTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        //AnimateHand(); //animating the hand every frame to reach that target animation when triggered

        PhysicsMove();
    }
    //internal void SetGrip(float v)
    //{
    //    gripTarget = v;
    //    //throw new NotImplementedException(); used for methods that will be used 
    //}

    //internal void SetTrigger(float v)
    //{
    //    triggerTarget = v;
        
    //}

    private void PhysicsMove()
    {
        //Postiton
        //var positionWithOffset = _followTarget.position + positionOffset;
        var positionWithOffset = _followTarget.TransformPoint(positionOffset); //converting it to world space
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        //Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    private void Grab(InputAction.CallbackContext context)
    {
        if (isGrabbing || heldObject) 
            return; 

        Collider[] grababbleColliders = Physics.OverlapSphere(palm.position, reachDistance, grabbableLayer);

        if (grababbleColliders.Length < 1) return;

        var objectToGrab = grababbleColliders[0].transform.gameObject;

        var objectBody = objectToGrab.GetComponent<Rigidbody>();

        if(objectBody != null)
        {
            heldObject = objectBody.gameObject;
        }
        else
        {
            objectBody = objectToGrab.GetComponentInParent<Rigidbody>();
            if(objectBody != null)
            {
                heldObject = objectBody.gameObject;
            }
            else
            {
                return;
            }
        }

        StartCoroutine(GrabObject(grababbleColliders[0], objectBody)); //where the actual grabbing will happen
    }

    private IEnumerator GrabObject(Collider collider, Rigidbody targetBody)
    {
        isGrabbing = true;

        // Create grab point
        grabPoint = new GameObject().transform;
        grabPoint.position = collider.ClosestPoint(palm.position);
        grabPoint.parent = heldObject.transform;

        // Move hand to grab point
        _followTarget = grabPoint;

        // Wait for hand to reach grab point
        while (Vector3.Distance(grabPoint.position, palm.position) > joinDistance && isGrabbing)
        {
            yield return new WaitForEndOfFrame(); //checks the distance between the grab and palm and if its within join distance then it will continue
        }

        // Freeze Hand and object motion
        _body.velocity = Vector3.zero;
        _body.angularVelocity = Vector3.zero;
        targetBody.angularVelocity = Vector3.zero;
        targetBody.velocity = Vector3.zero;

        targetBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        targetBody.interpolation = RigidbodyInterpolation.Interpolate;

        // Attach joints
        joint1 = gameObject.AddComponent<FixedJoint>();
        joint1.connectedBody = targetBody;
        joint1.breakForce = float.PositiveInfinity;
        joint1.breakTorque = float.PositiveInfinity;

        joint1.connectedMassScale = 1;
        joint1.massScale = 1;
        joint1.enableCollision = false; //no collions between hand and object
        joint1.enablePreprocessing = false;
        
        joint2 = heldObject.AddComponent<FixedJoint>();
        joint2.connectedBody = _body;
        joint2.breakForce = float.PositiveInfinity;
        joint2.breakTorque = float.PositiveInfinity;
             
        joint2.connectedMassScale = 1;
        joint2.massScale = 1;
        joint2.enableCollision = false; //no collions between hand and object
        joint2.enablePreprocessing = false;

        // Reset Follow target
        _followTarget = controller.gameObject.transform;

    }

    private void Release(InputAction.CallbackContext context)
    {
        if(joint1 != null)
            Destroy(joint1);
        if(joint2 != null)
            Destroy(joint2);
        if (grabPoint != null)
            Destroy(grabPoint.gameObject);

        if(heldObject != null)
        {
            var targetBody = heldObject.GetComponent<Rigidbody>();
            targetBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            targetBody.interpolation = RigidbodyInterpolation.None;
            heldObject = null;
        }

        isGrabbing = false;
        _followTarget = controller.gameObject.transform;
    }

    //void AnimateHand()
    //{
    //    if(gripCurrent != gripTarget)
    //    {
    //        gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
    //        animator.SetFloat(animatorGripParam, gripCurrent);
    //    }
        
    //    if(triggerCurrent != triggerTarget)
    //    {
    //        triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
    //        animator.SetFloat(animatorTriggerParam, triggerCurrent);
    //    }


    //}

    //public void ToggleVisbility()
    //{
    //    skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
    //}

  
}
