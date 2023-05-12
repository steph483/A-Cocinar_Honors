using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public AudioSource cut_completionDing;

    public ParticleSystem sparkles;

    private int thornsCutOff;
    private int onionsCut;
    private int tomatosCut;
    private int nopalesCut;
    private int nopalesCooked;

    public NopalesSaladRecipe saladRecipe;
    public AudioSource imessageSound;


    // Start is called before the first frame update
    void Start()
    {


        dialogueManager = GetComponent<DialogueManager>(); //finds it ?

        sparkles.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (NopalesDethroned() == true)
        {
            Debug.Log("ready to move on");

        }
    }

    public void AddCount(String gm, int count)
    {
        if (gm == "thorn")
        {
            thornsCutOff += count;
        }

    }

    public bool NopalesDethroned()
    {
        if (thornsCutOff >= 195)
        {
            Debug.Log("All the thorns are off");
            return true;
        }

        return false;
    }

    public void NopalesFinal()
    {

    }



    //checks to see when a task has  been done,
    
    
    public void CutCompletedTask()
    {
        //plays a ding and then a couple seconds later calls 
        cut_completionDing.Play();
        /*var em = sparkles.emission;
        var dur = sparkles.main.duration;

        em.enabled = true;*/
        sparkles.Play();
        StartCoroutine(PlaySparkle());

        //UNCOMMENT
        //StartCoroutine(PlayMessageSound());
    }

    IEnumerator PlayMessageSound()
    {
        yield return new WaitForSeconds(5);
        imessageSound.Play();
    }

    IEnumerator PlaySparkle()
    {
        yield return new WaitForSeconds(1);
        sparkles.Stop();
    }
}
