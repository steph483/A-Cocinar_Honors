using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class NopalesSaladRecipe : MonoBehaviour
{
    public GameManager GameManager;
    public CreatCleanNopal newNopal1;
    public CreatCleanNopal newNopal2;

    private bool isDone;

    private int cutThorns;
    private int cutThorns2;
    private int cutTomatoes;
    private int cutTomatoes2;
    private int cutNopales;
    private int cutNopales2;
    private int cutOnions;
    private int cookedNopales;


    void Start()
    {
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
  
        //if (cutNopales == 30 | cutNopales2 == 30) //might have to add something so this only plays once
        //{
        //    Debug.Log("All nopales are cut");
        //    //play done jingle on knife

        //    //play done particle effect on cutting board

        //}

        

        //if (cutOnions == 8)
        //{
        //    Debug.Log("All onions are cut");
        //    //play done jingle on knife

        //    //play done particle effect on cutting board
        //}
        
        //if (cookedNopales == 60)
        //{
        //    Debug.Log("The nopakes are cooking");
        //}

    }

    public bool IsCompleted()
    {
        return isDone;
    }

    public void CutItem(string type)
    {
        if(type == "thorn_1")
        {
            cutThorns++;
            if (DethronedNopal())
            {
                //check to see if it has also been but up
                //Debug.Log("nopal1 is dethorned");
                GameManager.CutCompletedTask();
                Debug.Log("played audio on N1");
                //INSTANTIATE NEW VERSION
                newNopal1.CreateNew();
                //check to see if it has been cooked
                //if so then finished
            }
        }
        if (type == "nopal_1")
        {
            cutNopales++;
            if (cutNopales == 30)
            {
                //Debug.Log("1 nnopales are cut");
                //play done jingle on knife
                GameManager.CutCompletedTask();
                //play done particle effect on cutting board
            }
        }
        if (type == "onion_1")
        {
            cutOnions++;
            if (cutOnions == 8)
            {
                //Debug.Log("1 onions are cut");
                //play done jingle on knife
                GameManager.CutCompletedTask();
                //play done particle effect on cutting board
            }
        }
        if (type == "tomato_1")
        {
            cutTomatoes++;
            if (cutTomatoes == 16)
            {
                //Debug.Log("1 tomatoes are cut");
                //play done jingle on knife
                GameManager.CutCompletedTask();
                //play done particle effect on cutting board
            }
        }
        if (type == "thorn_2")
        {
            cutThorns2++;

            if (DethronedNopal2())
            {
                //check to see if it has also been but up
                //Debug.Log("nopal2 is dethorned");
                GameManager.CutCompletedTask();
                Debug.Log("played audio on N2");
                //INSTANTIATE NEW VERSION
                newNopal2.CreateNew();
                //check to see if it has been cooked
                //if so then finished
            }
        }
        if (type == "nopal_2")
        {
            cutNopales2++;
            if (cutNopales2 == 30)
            {
        
                //play done jingle on knife
                GameManager.CutCompletedTask();
                //play done particle effect on cutting board
            }
        }
        if (type == "tomato_2")
        {
            cutTomatoes2++;
            if (cutTomatoes2 == 16)
            {
                //Debug.Log("2 tomatoes are cut");
                //play done jingle on knife
                GameManager.CutCompletedTask();
                //play done particle effect on cutting board
            }
        }
    }

    public void CookedItem(string type)
    {
        if (type == "cookedNopal")
        {
            cookedNopales++;
            if (cookedNopales == 60)
            {
                Debug.Log("THEY HAVE ALL BEEN COOKED");
                GameManager.CutCompletedTask();
            }
        }
    }

    private bool DethronedNopal()
    {
        
        //make sure nopal is dethorned
        if (cutThorns == 195 )
        {
            return true;
        }
        else { return false; }

    }

    private bool DethronedNopal2()
    {
        //make sure nopal is dethorned
        if (cutThorns2 == 195)
        {
            return true;
        }
        else { return false; }
    }



}
