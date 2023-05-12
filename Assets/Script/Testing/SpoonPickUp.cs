using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SpoonPickUp : MonoBehaviour
{
    public LayerMask layerMask;
    public bool isColliding;
    // Start is called before the first frame update
    //el asado
    void Start()
    {
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, mask);

        //if (!isColliding)
        //{
        //    myCollisions();
        //}
        
    }

    //private void myCollisions()
    //{
    //    //check to see what is in the sounding area & checks to make sure it's food
    //    Collider[] hits = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, layerMask);

    //    //attach them to spoon

    //    for (int i = 0; i < 16 || i < hits.Length; i++)
    //    {
    //        hits[i].gameObject.transform.parent = gameObject.transform;
    //    }

    //}

    //private void detach()
    //{
    //    //find what is attached to the 
    //}

    

    // check to see if it is a food object

    //if it is, set a limit of how many can be grabbed and add it to the spoon

    // add a button to know when to let go? might not be necessary
}
