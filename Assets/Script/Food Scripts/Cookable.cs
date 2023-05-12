using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    // Start is called before the first frame update
    private Boolean triggered;
    private Boolean smoking;
    //public GameObject smoke;
    //public ParticleSystem smoke;

    [SerializeField] [Range(0f, 50f)] float lerpTime;

    public Material nopalMaterial;
    MeshRenderer nopalRenderer;
    Color cookednopalColor;
    private void Awake()
    {
        Color mainColor = new Color(0.4830303f, 0.9063317f, 0.2848055f, 1.0f);
        cookednopalColor = new Color(0.2666667f, 0.5019608f, 0.1607843f, 1.0f);
        nopalMaterial.SetColor("_Color", mainColor);
        Debug.Log("color chaning shit");
    }

    void Start()
    {
        triggered = false;
        smoking = false;
        //smoke.SetActive(false);
        //smoke.Pause();
        nopalRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "spoon")
        {

            if (triggered == false)
            {
                Debug.Log("Lets change that color!");
                //WaitForSecondsRealtime(10);
                StartCoroutine(cookingWaitTime("nopal"));
                //nopalMaterial.SetColor("_Color", Color.black);
                //nopalRenderer.material.color = Color.Lerp(nopalRenderer.material.color, cookednopalColor, lerpTime);

                //NOT SURE THIS IS WORKING
                nopalRenderer.material.color = Color.Lerp(nopalRenderer.material.color, cookednopalColor, Mathf.PingPong(Time.time, 1));
            }
            triggered = true;

        }

        if (smoking == false)
        {
            //cookingWaitTime("smoke");
            smoking = true;
        }

    }




    private IEnumerator cookingWaitTime(String waitType)
    {
        if (waitType == "nopal")
        {
            yield return new WaitForSeconds(5);
            //Instantiate(cookedVersion, gameObject.transform.position, gameObject.transform.rotation);
            //Destroy(gameObject);
        }
        //if (waitType == "smoke")
        //{
        //    yield return new WaitForSeconds(10);
        //    //smoke.SetActive(true);
        //    smoke.Play();
        //}
    }

    //private void WaitForSecondsRealtime(int v)
    //{
    //    throw new NotImplementedException();
    //}

}
