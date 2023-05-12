using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCooking : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject nopal;
    //private GameObject child;

    private bool startedCook;

    public Material nopalMaterial;
    MeshRenderer nopalRenderer;
    Color cookednopalColor;

    private GameObject RecipeManager;
    NopalesSaladRecipe nopalesRecipe;

    private void Awake()
    {
        Color mainColor = new Color(0.4830303f, 0.9063317f, 0.2848055f, 1.0f);
        cookednopalColor = new Color(0.2666667f, 0.5019608f, 0.1607843f, 1.0f);
        nopalMaterial.SetColor("_Color", mainColor);
        //Debug.Log("color chaning shit");
    }

    void Start()
    {
        startedCook = false;
        RecipeManager = GameObject.Find("Recipes");
        nopalesRecipe = RecipeManager.GetComponent<NopalesSaladRecipe>();
        nopalRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //if (gameObject.name == "cookedNopal" )
        //{

        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "pan")
        {
            //Debug.Log("entered the pan");
            //instantiate new nopal
            //child = Instantiate(nopal, gameObject.transform.position, gameObject.transform.rotation);
            //child.name = "cookedNopal";
            gameObject.name = "cookedNopal";

            //Destroy(gameObject);
        }

        if (gameObject.name == "cookedNopal" & collision.gameObject.tag == "spoon" & !startedCook)
        {
            startedCook = true;
            //start changing color 
            StartCoroutine(startColorChanging());


            //when end change, tell the nopal recipe and play ding
        }
    
        IEnumerator startColorChanging()
        {
            yield return new WaitForSeconds(60);
            nopalRenderer.material.color = Color.Lerp(nopalRenderer.material.color, cookednopalColor, 20);
            nopalesRecipe.CookedItem(gameObject.name);
        }

    }
}
