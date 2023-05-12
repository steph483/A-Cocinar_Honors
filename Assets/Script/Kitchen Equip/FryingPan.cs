using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    private bool cooking;
    [SerializeField] int count;
    public AudioSource sizzle;
    public GameObject smoke;
    private float timer;

    private void Start()
    {
        //timer = sizzle.clip.length;
        smoke.SetActive(false);
    }

    private void Update()
    {
        //timer -= Time.deltaTime;

        if (!cooking & count >= 1)
        {
            sizzle.Play();
            cooking = true;
            smoke.SetActive(true);
            //Debug.Log("start frying");
        }
        if (count <= 0)
        {
            //COUNT IS NOT WORKING
            //Debug.Log("Stop sound");
            sizzle.Stop();
            cooking = false;
            smoke.SetActive(false);
        }
    }
    //add the food as a child of the pan
    private void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;
        if (item.tag == "nopal")
        {
            count++;
            //Debug.Log("nopal has HIT pan");
            item.transform.parent = gameObject.transform;
        }
    }

    //void OnCollisionStay(Collision collisionInfo)
    //{
    //    Debug.Log("collision info: ", collisionInfo.collider);
    //}

    //when not colliding remove as a child
 
    private void OnTriggerExit(Collider other)
    {
        GameObject itemOut = other.gameObject;
        if (itemOut.tag == "nopal")
        {
            count--;
            //Debug.Log("nopal has LEFT pan");
            itemOut.transform.parent = null;
        }
    }
}
