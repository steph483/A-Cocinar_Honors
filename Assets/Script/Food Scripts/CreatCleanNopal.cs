using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCleanNopal : MonoBehaviour
{
    public bool n1;
    public bool n2;
    private GameObject child;
    public GameObject nopal;


    public void CreateNew()
    {
        Debug.Log("create new called"); 
        StartCoroutine(wait8Secs());
    }

    private IEnumerator wait8Secs()
    {
        yield return new WaitForSeconds(8);
        Debug.Log("waited 8 secs");
        child = Instantiate(nopal, gameObject.transform.position, gameObject.transform.rotation);
        if (n1)
        {
            child.name = "nopal_1";
        }
        if (n2)
        {
            child.name = "nopal_2";
        }
        Debug.Log("DESTROYED");
        Destroy(gameObject);
    }

}
