using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoonTool : MonoBehaviour
{
    public GameObject oreganoPowder;
    public GameObject saltPowder;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("This is rigidbody", gameObject.GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.rotation.x);
        if(gameObject.transform.rotation.x > .5)
        //if (gameObject.GetComponent<Rigidbody>().rotation.x > 85)
        {
            Debug.Log("it's tipped");
            if (saltPowder.gameObject.activeSelf)
            {
                saltPowder.SetActive(false);
            }
            if (oreganoPowder.gameObject.activeSelf)
            {
                oreganoPowder.SetActive(false);
            }
        }
        
    }
}
