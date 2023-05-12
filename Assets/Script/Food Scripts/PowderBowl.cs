using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PowderBowl : MonoBehaviour
{
    //public GameObject spoon;
    public GameObject oreganoPowder;
    public GameObject saltPowder;
    public bool oregano;
    public bool salt;
    public AudioSource spiceAudio;
    void Start()
    {
      
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "spoon") {
            spiceAudio.Play();
            if (oregano){
                if (!oreganoPowder.gameObject.activeSelf)
                {
                    oreganoPowder.SetActive(true);
                }
                if (saltPowder.gameObject.activeSelf)
                {
                    saltPowder.SetActive(false);
                    oreganoPowder.SetActive(true);
                }
            }
            if (salt){
                if (oreganoPowder.gameObject.activeSelf)
                {
                    oreganoPowder.SetActive(false);
                    saltPowder.SetActive(true);
                }
                if (!saltPowder.gameObject.activeSelf)
                {
                    saltPowder.SetActive(true);
                }
             }
        }
    }
}
