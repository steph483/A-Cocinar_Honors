using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class Cuttable : MonoBehaviour
{
    //public GameObject cut_version;
    private bool isColliding;


    public GameObject r_cut;
    public GameObject l_cut;

    private GameObject child1;
    private GameObject child2;
    private Collider child1Col;
    private Collider child2Col;

    private GameObject audioObject;

    //[SerializeField] AudioSource[] cuttingSounds;
    [SerializeField] GameObject lChop;
    [SerializeField] GameObject sChop;
    [SerializeField] AudioSource shortChop;
    [SerializeField] AudioSource longChop;

    

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("COllision detected");
    //    //Instantiate(cut_version, transform.position, transform.rotation);
    //    //Destroy(gameObject);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("COllision detected");
    //    ////Instantiate(cut_version, new Vector3(0, 0, 0), Quaternion.identity);
    //    //Instantiate(cut_version, gameObject.transform.position, gameObject.transform.rotation);
    //    //Destroy(gameObject);
    //    Debug.Log("Nopal was hit");
    //    Debug.Log("This is gameObject:" + gameObject.tag);
    //    Debug.Log("This is the other: " + other);
    //    Debug.Log("This is the other.tag: " + other.tag);

    //    if (gameObject.tag == "nopal" & other.tag == "spoon")
    //    {
    //        Debug.Log("Nopal and spoon collision detected");
    //        Destroy(gameObject);
    //        Instantiate(cut_version, gameObject.transform.position, gameObject.transform.rotation);
    //    }
    //}
    private void Start()
    {
        isColliding = false;
        //audioObject = GameObject.Find("Knife2");
        lChop = GameObject.Find("long_chop");
        sChop = GameObject.Find("short_chop");
        shortChop = sChop.GetComponent<AudioSource>();
        longChop = lChop.GetComponent<AudioSource>();
        //nopalesRecipe = RecipeManager.GetComponent<NopalesSaladRecipe>();
    }

    //private void OnTriggerExit(Collider other)
    //private void OnCollisionExit(Collision collision)
    //{

    //}
    private void OnTriggerExit(Collider other)
    {
        if (isColliding) return;
        isColliding = true;

        if (gameObject.layer == 7 & other.tag == "spoon")
        {
            
            shortChop.Play();
        
            //Debug.Log("Nopal and spoon collision detected");
            Destroy(gameObject);
            Vector3 originalPos = gameObject.transform.position;
            Transform originalTrans = gameObject.transform;
            child1 = Instantiate(l_cut, gameObject.transform.position += new Vector3((float)-.05, 0, 0), gameObject.transform.rotation);
            child1.gameObject.name = gameObject.name;
            //child1Col = child1.GetComponent<Collider>();
            child2 = Instantiate(r_cut, gameObject.transform.position += new Vector3((float).05, 0, 0), gameObject.transform.rotation);
            child2.gameObject.name = gameObject.name;
            //child2Col = child2.GetComponent<Collider>();

            //disable colliders of children that were just instantiated
            //child1Col.enabled = false;
            //child2Col.enabled = false;


            //Old code about instantiating when the object is deleted. 
            //Instantiate(cut_version, gameObject.transform.position, gameObject.transform.rotation);

            //FIXME: Why doesn't cutting go through all levels: stops at 1/8th cuts when it should go to 1/16 -> 1/32
            //cut_version.transform.GetChild(0).transform.parent = null;
            //cut_version.transform.GetChild(1).transform.parent = null;
        }

        StartCoroutine(ResetColliding());

    }

    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}

    IEnumerator ResetColliding()
    {
        yield return new WaitForEndOfFrame();
        //yield return new WaitForSeconds((float)1);

        //reenable children colliders
        //child1Col.enabled = true;
        //child2Col.enabled = true;

        isColliding = false;
    }
}
