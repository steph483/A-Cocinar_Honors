using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Nopal_Thorn : MonoBehaviour
{
    public Rigidbody rb;
    public NopalesSaladRecipe nopalRecipe;
    public AudioSource peelAudio;
    private bool notHit;
    //UNCOMMENT!!!!!!!!!!!!
    //public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        notHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("thorn was hit!");
    //    print("game onject is: " + collision.gameObject);

    //    if (collision.gameObject == spoon)
    //    {
    //        Debug.Log("SPOON!");
    //        rb.isKinematic = false;

    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("There is a collision " + other.gameObject);
        if (other.gameObject.tag == "spoon" & !notHit)
        {
            peelAudio.Play();
            Debug.Log("hit on nopal thorn");
            notHit = true;
            //Debug.Log("there is a spoon");
            rb.isKinematic = false;
            gameObject.transform.parent = null;
            nopalRecipe.CutItem(gameObject.name);
            StartCoroutine(deletion());
            //lets game mangager that it's been cut off
            //gameManager.AddCount("thorn", 1);
            //StartCoroutine(deletion());
        }
    }

    private IEnumerator deletion()
    {
        //Debug.Log("delection has been called");
        yield return new WaitForSeconds(10);
        nopalRecipe.CutItem(gameObject.name);
        Destroy(gameObject);
        //Destroy(rb.gameObject);
       
    }
}
