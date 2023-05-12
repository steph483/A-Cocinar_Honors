using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStageItem : MonoBehaviour
{
    public GameObject RecipeManager;
    public NopalesSaladRecipe nopalesRecipe;

    void Start()
    {

        //nopalesRecipe = RecipeManager.GetComponent<NopalesSaladRecipe>();
        RecipeManager = GameObject.Find("Recipes");
        nopalesRecipe = RecipeManager.GetComponent<NopalesSaladRecipe>();


        if (nopalesRecipe == null)
        {
            Debug.LogError("There is no recipe manager found");
        }

        //just lets the gameManager that it is the final stage of the item

        if (gameObject.name == "cookedNopal")
        {
            nopalesRecipe.CookedItem(gameObject.name);
        }
        else
        {
            nopalesRecipe.CutItem(gameObject.name);
        }
    }

}
