using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WorkingHand : MonoBehaviour
{
    public float speed;

    private float gripTarget;
    private float gripCurrent;
    private float triggerTarget;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    Animator animator;
    SkinnedMeshRenderer skinnedMeshRenderer;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand(); //animating the hand every frame to reach that target animation when triggered
    }
    internal void SetGrip(float v)
    {
        gripTarget = v;
        //throw new NotImplementedException(); used for methods that will be used 
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;

    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }


    }

    public void ToggleVisbility()
    {
        skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
    }

}
