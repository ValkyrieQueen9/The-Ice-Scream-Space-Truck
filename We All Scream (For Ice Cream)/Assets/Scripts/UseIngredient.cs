using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseIngredient : MonoBehaviour
{
    [Header("Ingredient Type")]
    public bool iceCream = false;
    public bool topping = false;
    public bool sauce = false;
    public bool cone = false;

    [Header("Ingredient Flavour")]
    public bool galaxy = false;
    public bool cosmic = false;
    public bool rainbow = false;
    public bool neon = false;
    public bool red = false;
    public bool plain = false;

    private SpriteRenderer Rend;

    //Flavours
    private Sprite galaxyScoop, rainbowScoop, neonTop, cosmicScoop, redScoop, plainCone;

    //Cone
    private GameObject buildCone;
    private SpriteRenderer buildConeRend;

    //Scoops
    private GameObject scoop1, scoop2, scoop3, scoop4;
    private SpriteRenderer scoop1Rend, scoop2Rend, scoop3Rend, scoop4Rend;

    //Toppings
    private GameObject topping1, topping2, topping3, topping4;
    private SpriteRenderer topping1Rend, topping2Rend, topping3Rend, topping4Rend;

    //ErrorMsgs
    [HideInInspector]
    public GameObject errorMsgs;
    public UIManager UIManager;

    private void Start()
    {
        Rend = GetComponent<SpriteRenderer>();

        //ErrorMsgs
        errorMsgs = GameObject.Find("ErrorMsgs");
        UIManager = errorMsgs.GetComponent<UIManager>();

        //Flavours
        galaxyScoop = Resources.Load<Sprite>("scoops/galaxyScoop");
        rainbowScoop = Resources.Load<Sprite>("scoops/rainbowScoop");
        neonTop = Resources.Load<Sprite>("toppings/neonTopping");
        cosmicScoop = Resources.Load<Sprite>("scoops/cosmicScoop");
        redScoop = Resources.Load<Sprite>("scoops/redScoop");
        plainCone = Resources.Load<Sprite>("cones/plainCone");

        //Cone
        buildCone = GameObject.FindGameObjectWithTag("Cone");
        buildConeRend = buildCone.GetComponent<SpriteRenderer>();

        //Scoops
        scoop1 = GameObject.Find("Scoop1");
        scoop2 = GameObject.Find("Scoop2");
        scoop3 = GameObject.Find("Scoop3");
        scoop4 = GameObject.Find("Scoop4");
        scoop1Rend = scoop1.GetComponent<SpriteRenderer>();
        scoop2Rend = scoop2.GetComponent<SpriteRenderer>();
        scoop3Rend = scoop3.GetComponent<SpriteRenderer>();
        scoop4Rend = scoop4.GetComponent<SpriteRenderer>();

        //Toppings
        topping1 = GameObject.Find("Topping1");
        topping2 = GameObject.Find("Topping2");
        //topping3 = GameObject.Find("Topping3");
        //topping4 = GameObject.Find("Topping4");
        topping1Rend = topping1.GetComponent<SpriteRenderer>();
        topping2Rend = topping2.GetComponent<SpriteRenderer>();
        //topping3Rend = topping3.GetComponent<SpriteRenderer>();
        //topping4Rend = topping4.GetComponent<SpriteRenderer>();

    }

    //When ingredient (script is attached to each "empty" ingredient sprite) is clicked check for which ingredient type and flavour it is.
    //- use bools triggered manually when script is set to decide the items type e.g. if ingredient is sprinkles, mark topping as true in inspector 

    //When ingredient type found trigger special function e.g. ice cream function

    //In each ingredient function check whether any other ingredients have been placed, if none add in lowest tier.
    //Maybe use invisible sprites that switch out art when triggered rather than creating new objects??

    public void addIngredient()
    {
        if (cone)
        {
            if(buildConeRend.sprite == null)
            {
                if (plain)
                {
                    buildConeRend.sprite = plainCone;
                }
            }
        }

        if (iceCream)
        {
            if(buildConeRend.sprite == null)
            {
                Debug.Log("You need a cone first!");
                StartCoroutine(UIManager.ShortPopUp(UIManager.noConeMsg));
            }

            //SCOOP 1 --- Check if a cone and any scoops have been added to 1st layer of cone(scoop1)
            if(buildConeRend.sprite != null && scoop1Rend.sprite == null)
            {
                if (galaxy)
                    {
                        scoop1Rend.sprite = galaxyScoop;
                    }
                if (rainbow)
                    {
                        scoop1Rend.sprite = rainbowScoop;
                    }
                if (cosmic)
                    {
                        scoop1Rend.sprite = cosmicScoop;
                    }
                if (red)
                    {
                        scoop1Rend.sprite = redScoop;
                    }
            }

            //SCOOP 2 --- Check if scoop1 is used and if any scoops have been added to 2nd layer of cone(scoop2)
            else if (scoop1Rend.sprite != null && scoop2Rend.sprite == null)
            {
                if (galaxy)
                    {
                        scoop2Rend.sprite = galaxyScoop;
                    }
                if (rainbow)
                    {
                        scoop2Rend.sprite = rainbowScoop;
                    }
                if (cosmic)
                    {
                        scoop2Rend.sprite = cosmicScoop;
                    }
                if (red)
                    {
                        scoop2Rend.sprite = redScoop;
                    }
            }

            //SCOOP 3 --- Check if scoop1 & scoop2 is used and if any scoops have been added to 3rd layer of cone(scoop3)
            else if (scoop1Rend.sprite != null && scoop2Rend.sprite != null && scoop3Rend.sprite == null)
            {
                if (galaxy)
                {
                    scoop3Rend.sprite = galaxyScoop;
                }
                if (rainbow)
                {
                    scoop3Rend.sprite = rainbowScoop;
                }
                if (cosmic)
                {
                    scoop3Rend.sprite = cosmicScoop;
                }
                if (red)
                {
                    scoop3Rend.sprite = redScoop;
                }
            }

            //SCOOP 4 --- Check if scoop1 is used and if any scoops have been added to second layer of cone(scoop2)
            else if (scoop1Rend.sprite != null && scoop2Rend.sprite != null && scoop3Rend.sprite != null && scoop4Rend.sprite == null)
            {
                if (galaxy)
                {
                    scoop4Rend.sprite = galaxyScoop;
                }
                if (rainbow)
                {
                    scoop4Rend.sprite = rainbowScoop;
                }
                if (cosmic)
                {
                    scoop4Rend.sprite = cosmicScoop;
                }
                if (red)
                {
                    scoop4Rend.sprite = redScoop;
                }
            }

            else if (scoop1Rend.sprite != null && scoop2Rend.sprite != null && scoop3Rend.sprite != null && scoop4Rend.sprite != null)
            {
                Debug.Log("That's enough scoops!");
                StartCoroutine(UIManager.ShortPopUp(UIManager.tmScoopsMsg));
                }

        }

        if (topping)
        {
            if (topping1Rend.sprite == null)
            {
                if (neon)
                {
                    topping1Rend.sprite = neonTop;
                }
            }

            else if(topping2Rend.sprite == null)
            {
                if (neon)
                {
                    topping2Rend.sprite = neonTop;
                }
            }

            else if(topping1Rend.sprite != null && topping2Rend.sprite != null)
            {
                Debug.Log("That's enough toppings!");
                StartCoroutine(UIManager.ShortPopUp(UIManager.tmToppingsMsg));
            }

            //FINISH 3rd and 4th Toppings layers
        }
    }

}
