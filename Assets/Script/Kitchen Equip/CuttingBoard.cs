using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{

  
    private void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;
        if (other.gameObject.layer == 7 || other.gameObject.layer == 9)
        {
            //Debug.Log("something had entered");
            item.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject item = other.gameObject;
        if (other.gameObject.layer == 7 || other.gameObject.layer == 9)
        {
            //Debug.Log("something had exisited");
            item.transform.parent = null;
        }
    }
   

    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject item = collision.gameObject;
    //    if (collision.gameObject.layer == 7)
    //    {
    //        //Debug.Log("something had entered");
    //        item.transform.parent = gameObject.transform;
    //    }
    //}

    ////when not colliding remove as a child
    //private void OnCollisionExit(Collision collision)
    //{
    //    GameObject item = collision.gameObject;
    //    if (collision.gameObject.layer == 7)
    //    {
    //        //Debug.Log("something had exisited");
    //        item.transform.parent = null;
    //    }
    //}
}
