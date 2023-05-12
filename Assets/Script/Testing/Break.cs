using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject breakAble;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;

    private List<GameObject> particleList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        particleList.Add(a);
        particleList.Add(b);
        particleList.Add(c);
        particleList.Add(d);
        particleList.Add(f);
        particleList.Add(g);
        particleList.Add(h);
        particleList.Add(i);
        
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter()
    {
        ////hide unbroken cube
        //breakAble.SetActive(false);

        ////move the partiles
        //foreach (GameObject particle in particleList)
        //{
        //    particle.GetComponent<Rigidbody>().AddForce(0, 0, 1);
        //}

        ////wait 1 second
       



        ////stop velocity
        //foreach (GameObject particle in particleList)
        //{
        //    particle.GetComponent<Rigidbody>().AddForce(0, 0, 0);
        //}

    }
}
