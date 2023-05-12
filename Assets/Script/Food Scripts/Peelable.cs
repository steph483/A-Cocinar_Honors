using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peelable : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // On trigger knife inside 
    // (maybe) turn the convex collider off and turn box colider on
    // turn kinematic off or on to turn gravity on to make it grabable

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.layer == 9 & other.tag == "spoon")
        {
            Debug.Log("hit");
            rb.isKinematic = false;
            gameObject.transform.parent = gameObject.transform;
       
        }


    }
    
}
