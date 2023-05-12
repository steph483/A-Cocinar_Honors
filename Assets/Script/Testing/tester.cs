using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public bool n1;
    public bool n2;
    private GameObject child;
    // Start is called before the first frame update
    public GameObject nopal;
    void Start()
    {
        StartCoroutine(wait30Secs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator wait30Secs()
    {
        yield return new WaitForSeconds(20);
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
