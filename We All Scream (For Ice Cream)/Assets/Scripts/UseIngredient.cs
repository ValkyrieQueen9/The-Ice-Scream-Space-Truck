using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseIngredient : MonoBehaviour

//When ingredient (script is attached to button) is clicked check for which ingredient type and flavour it is.
//- use bools triggered manually when script is set to decide the items type e.g. if ingredient is sprinkles, mark topping as true in inspector 

//When ingredient type found trigger special function e.g. ice cream function

//In each ingredient function check whether any other ingredients have been placed, if none add in lowest tier.
//Maybe use invisible sprites that switch out art when triggered rather than creating new objects??


{
    [Header("Ingredient Type")]
    public bool iceCream = false;
    public bool topping = false;
    public bool sauce = false;
    public bool cone = false;

    [Header("Ingredient Flavour")]

    //Cone
    public bool plain = false;
    //Scoops
    public bool bone = false;
    public bool cosmic = false;
    public bool magma = false;
    public bool meat = false;
    public bool tropical = false;
    //Sauces
    public bool acid = false;
    public bool bloody = false;
    public bool bloodyUnicorn = false;
    public bool soul = false;
    //Toppings
    public bool batteries = false;
    public bool eyeballs = false;
    public bool gems = false;
    public bool glass = false;
    public bool nettles = false;

    private SpriteRenderer Rend;

    //Flavours
    private Sprite plainCone, boneScoop, cosmicScoop, magmaScoop, meatScoop, tropicalScoop, acidSauce, bloodySauce, bloodyUnicornSauce, soulSauce, batteriesTop, eyeballsTop, gemsTop, glassTop, nettlesTop;

    //Cone
    private GameObject buildCone;
    private SpriteRenderer buildConeRend;

    //Scoops
    private GameObject scoop1, scoop2, scoop3, scoop4, scoop5;
    private SpriteRenderer scoop1Rend, scoop2Rend, scoop3Rend, scoop4Rend, scoop5Rend;

    //Sauce
    private GameObject sauce1, sauce2, sauce3, sauce4, sauce5;
    private SpriteRenderer sauce1Rend, sauce2Rend, sauce3Rend, sauce4Rend, sauce5Rend;

    //Toppings - numbers reference the number of scoops stacked?
    private GameObject topping1, topping2, topping3, topping4, topping5;
    private SpriteRenderer topping1Rend, topping2Rend, topping3Rend, topping4Rend, topping5Rend;

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
        plainCone = Resources.Load<Sprite>("cones/plainCone");

        boneScoop = Resources.Load<Sprite>("scoops/boneScoop");
        cosmicScoop = Resources.Load<Sprite>("scoops/cosmicScoop");
        magmaScoop = Resources.Load<Sprite>("scoops/magmaScoop");
        meatScoop = Resources.Load<Sprite>("scoops/meatScoop");
        tropicalScoop = Resources.Load<Sprite>("scoops/tropicalScoop");

        acidSauce = Resources.Load<Sprite>("sauces/acidSauce");
        bloodySauce = Resources.Load<Sprite>("sauces/bloodySauce");
        bloodyUnicornSauce = Resources.Load<Sprite>("sauces/bloodyUnicornSauce");
        soulSauce = Resources.Load<Sprite>("sauces/soulSauce");

        batteriesTop = Resources.Load<Sprite>("toppings/batteriesTopping");
        eyeballsTop = Resources.Load<Sprite>("toppings/eyeballsTopping");
        gemsTop = Resources.Load<Sprite>("toppings/gemsTopping");
        glassTop = Resources.Load<Sprite>("toppings/glassTopping");
        nettlesTop = Resources.Load<Sprite>("toppings/nettlesTopping");

        //Cone
        buildCone = GameObject.FindGameObjectWithTag("Cone");
        buildConeRend = buildCone.GetComponent<SpriteRenderer>();

        //Scoops
        scoop1 = GameObject.Find("Scoop1");
        scoop2 = GameObject.Find("Scoop2");
        scoop3 = GameObject.Find("Scoop3");
        scoop4 = GameObject.Find("Scoop4");
        scoop5 = GameObject.Find("Scoop5");
        scoop1Rend = scoop1.GetComponent<SpriteRenderer>();
        scoop2Rend = scoop2.GetComponent<SpriteRenderer>();
        scoop3Rend = scoop3.GetComponent<SpriteRenderer>();
        scoop4Rend = scoop4.GetComponent<SpriteRenderer>();
        scoop5Rend = scoop5.GetComponent<SpriteRenderer>();

        //Sauces
        sauce1 = GameObject.Find("Sauce1");
        sauce2 = GameObject.Find("Sauce2");
        sauce3 = GameObject.Find("Sauce3");
        sauce4 = GameObject.Find("Sauce4");
        sauce5 = GameObject.Find("Sauce5");
        sauce1Rend = sauce1.GetComponent<SpriteRenderer>();
        sauce2Rend = sauce2.GetComponent<SpriteRenderer>();
        sauce3Rend = sauce3.GetComponent<SpriteRenderer>();
        sauce4Rend = sauce4.GetComponent<SpriteRenderer>();
        sauce5Rend = sauce5.GetComponent<SpriteRenderer>();

        //Toppings
        topping1 = GameObject.Find("Topping1");
        topping2 = GameObject.Find("Topping2");
        topping3 = GameObject.Find("Topping3");
        topping4 = GameObject.Find("Topping4");
        topping5 = GameObject.Find("Topping5");
        topping1Rend = topping1.GetComponent<SpriteRenderer>();
        topping2Rend = topping2.GetComponent<SpriteRenderer>();
        topping3Rend = topping3.GetComponent<SpriteRenderer>();
        topping4Rend = topping4.GetComponent<SpriteRenderer>();
        topping5Rend = topping5.GetComponent<SpriteRenderer>();
    }

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
                //StartCoroutine(UIManager.ShortPopUp(UIManager.noConeMsg));
                //Use sound instead
            }

            //SCOOP 1 --- Check for cone & empty scoop1
            if(buildConeRend.sprite != null && scoop1Rend.sprite == null)
            {
                if (bone)
                    {
                        scoop1Rend.sprite = boneScoop;
                    }
                if (cosmic)
                    {
                        scoop1Rend.sprite = cosmicScoop;
                    }
                if (magma)
                    {
                        scoop1Rend.sprite = magmaScoop;
                    }
                if (meat)
                    {
                        scoop1Rend.sprite = meatScoop;
                    }
                if (tropical)
                    {
                        scoop1Rend.sprite = tropicalScoop;
                    }
            }

            //SCOOP 2 --- Check for scoop1 & empty sauce1 & scoop2
            else if (scoop1Rend.sprite != null && sauce1Rend.sprite == null && scoop2Rend.sprite == null)
            {
                if (bone)
                    {
                        scoop2Rend.sprite = boneScoop;
                    }
                if (cosmic)
                    {
                        scoop2Rend.sprite = cosmicScoop;
                    }
                if (magma)
                    {
                        scoop2Rend.sprite = magmaScoop;
                    }
                if (meat)
                    {
                        scoop2Rend.sprite = meatScoop;
                    }
                if (tropical)
                    {
                        scoop2Rend.sprite = tropicalScoop;
                    }
            }

            //SCOOP 3 --- Check for scoop2 & empty sauce2 & scoop3
            else if (scoop2Rend.sprite != null && sauce2Rend.sprite == null && scoop3Rend.sprite == null)
            {
                if (bone)
                {
                    scoop3Rend.sprite = boneScoop;
                }
                if (cosmic)
                {
                    scoop3Rend.sprite = cosmicScoop;
                }
                if (magma)
                {
                    scoop3Rend.sprite = magmaScoop;
                }
                if (meat)
                {
                    scoop3Rend.sprite = meatScoop;
                }
                if (tropical)
                {
                    scoop3Rend.sprite = tropicalScoop;
                }
            }

            //SCOOP 4 --- Check for scoop3 & empty sauce3 & scoop4
            else if (scoop3Rend.sprite != null && sauce3Rend.sprite == null && scoop4Rend.sprite == null)
            {
                if (bone)
                {
                    scoop4Rend.sprite = boneScoop;
                }
                if (cosmic)
                {
                    scoop4Rend.sprite = cosmicScoop;
                }
                if (magma)
                {
                    scoop4Rend.sprite = magmaScoop;
                }
                if (meat)
                {
                    scoop4Rend.sprite = meatScoop;
                }
                if (tropical)
                {
                    scoop4Rend.sprite = tropicalScoop;
                }
            }

            //SCOOP 5 --- Check for scoop4 & empty sauce4 & scoop5
            else if (scoop4Rend.sprite != null && sauce4Rend.sprite == null && scoop5Rend.sprite == null)
            {
                if (bone)
                {
                    scoop5Rend.sprite = boneScoop;
                }
                if (cosmic)
                {
                    scoop5Rend.sprite = cosmicScoop;
                }
                if (magma)
                {
                    scoop5Rend.sprite = magmaScoop;
                }
                if (meat)
                {
                    scoop5Rend.sprite = meatScoop;
                }
                if (tropical)
                {
                    scoop5Rend.sprite = tropicalScoop;
                }
            }

            //Enough Scoops
            else if (scoop5Rend.sprite != null)
                {
                Debug.Log("That's enough scoops!");
                //StartCoroutine(UIManager.ShortPopUp(UIManager.tmScoopsMsg));
                //sound notification here
                }
        }

        if (sauce)
        {
            //SAUCE 1 --- Check for scoop1 & empty scoop2 & sauce1
            if (scoop1Rend.sprite != null && scoop2Rend.sprite == null && sauce1Rend.sprite == null)
            {
                if (acid)
                {
                    sauce1Rend.sprite = acidSauce;
                }
                if (bloody)
                {
                    sauce1Rend.sprite = bloodySauce;
                }
                if (bloodyUnicorn)
                {
                    sauce1Rend.sprite = bloodyUnicornSauce;
                }
                if (soulSauce)
                {
                    sauce1Rend.sprite = soulSauce;
                }
            }

            //SAUCE 2 --- Check for scoop2 & empty scoop3 & sauce2
            else if (scoop2Rend.sprite != null && scoop3Rend.sprite == null && sauce2Rend.sprite == null) 
            {
                if (acid)
                {
                    sauce2Rend.sprite = acidSauce;
                }
                if (bloody)
                {
                    sauce2Rend.sprite = bloodySauce;
                }
                if (bloodyUnicorn)
                {
                    sauce2Rend.sprite = bloodyUnicornSauce;
                }
                if (soulSauce)
                {
                    sauce2Rend.sprite = soulSauce;
                }
            }

            //SAUCE 3 --- Check for scoop3 & empty scoop4 & sauce3
            else if (scoop3Rend.sprite != null && scoop4Rend.sprite == null && sauce3Rend.sprite == null)
            {
                if (acid)
                {
                    sauce3Rend.sprite = acidSauce;
                }
                if (bloody)
                {
                    sauce3Rend.sprite = bloodySauce;
                }
                if (bloodyUnicorn)
                {
                    sauce3Rend.sprite = bloodyUnicornSauce;
                }
                if (soulSauce)
                {
                    sauce3Rend.sprite = soulSauce;
                }
            }

            //SAUCE 4 --- Check for scoop4 & empty scoop5 & sauce4
            else if (scoop4Rend.sprite != null && scoop5Rend.sprite == null && sauce4Rend.sprite == null)
            {
                if (acid)
                {
                    sauce4Rend.sprite = acidSauce;
                }
                if (bloody)
                {
                    sauce4Rend.sprite = bloodySauce;
                }
                if (bloodyUnicorn)
                {
                    sauce4Rend.sprite = bloodyUnicornSauce;
                }
                if (soulSauce)
                {
                    sauce4Rend.sprite = soulSauce;
                }
            }

            //SAUCE 5 --- Check for scoop5 & empty sauce5
            else if (scoop5Rend.sprite != null && sauce5Rend.sprite == null)
            {
                if (acid)
                {
                    sauce5Rend.sprite = acidSauce;
                }
                if (bloody)
                {
                    sauce5Rend.sprite = bloodySauce;
                }
                if (bloodyUnicorn)
                {
                    sauce5Rend.sprite = bloodyUnicornSauce;
                }
                if (soulSauce)
                {
                    sauce5Rend.sprite = soulSauce;
                }
            }

            //Enough sauces
            else if (scoop5Rend.sprite != null)
            {
                Debug.Log("That's enough sauces!");
                //StartCoroutine(UIManager.ShortPopUp(UIManager.tmToppingsMsg));
                //sound notification instead
            }
        }

        if (topping)
        {
            //TOPPING 1 --- Check for sauce1 & empty topping1
            if (sauce1Rend.sprite != null && topping1Rend.sprite == null)
            {
                if (batteries)
                {
                    topping1Rend.sprite = batteriesTop;
                }
                if (eyeballs)
                {
                    topping1Rend.sprite = eyeballsTop;
                }
                if (gems)
                {
                    topping1Rend.sprite = gemsTop;
                }
                if (glass)
                {
                    topping1Rend.sprite = glassTop;
                }
                if (nettles)
                {
                    topping1Rend.sprite = nettlesTop;
                }
            }

            //TOPPING 2 --- Check for sauce2 & empty topping2
            else if (sauce2Rend.sprite != null && topping2Rend.sprite == null)
            {
                if (batteries)
                {
                    topping2Rend.sprite = batteriesTop;
                }
                if (eyeballs)
                {
                    topping2Rend.sprite = eyeballsTop;
                }
                if (gems)
                {
                    topping2Rend.sprite = gemsTop;
                }
                if (glass)
                {
                    topping2Rend.sprite = glassTop;
                }
                if (nettles)
                {
                    topping2Rend.sprite = nettlesTop;
                }
            }

            //TOPPING 3 --- Check for sauce3 & empty topping3
            else if (sauce3Rend.sprite != null && topping3Rend.sprite == null)
            {
                if (batteries)
                {
                    topping3Rend.sprite = batteriesTop;
                }
                if (eyeballs)
                {
                    topping3Rend.sprite = eyeballsTop;
                }
                if (gems)
                {
                    topping3Rend.sprite = gemsTop;
                }
                if (glass)
                {
                    topping3Rend.sprite = glassTop;
                }
                if (nettles)
                {
                    topping3Rend.sprite = nettlesTop;
                }
            }

            //TOPPING 4 --- Check for sauce4 & empty topping4
            else if (sauce4Rend.sprite != null && topping4Rend.sprite == null)
            {
                if (batteries)
                {
                    topping4Rend.sprite = batteriesTop;
                }
                if (eyeballs)
                {
                    topping4Rend.sprite = eyeballsTop;
                }
                if (gems)
                {
                    topping4Rend.sprite = gemsTop;
                }
                if (glass)
                {
                    topping4Rend.sprite = glassTop;
                }
                if (nettles)
                {
                    topping4Rend.sprite = nettlesTop;
                }
            }

            //TOPPING 5 --- Check for sauce5 & empty topping5
            else if (sauce5Rend.sprite != null && topping5Rend.sprite == null)
            {
                if (batteries)
                {
                    topping5Rend.sprite = batteriesTop;
                }
                if (eyeballs)
                {
                    topping5Rend.sprite = eyeballsTop;
                }
                if (gems)
                {
                    topping5Rend.sprite = gemsTop;
                }
                if (glass)
                {
                    topping5Rend.sprite = glassTop;
                }
                if (nettles)
                {
                    topping5Rend.sprite = nettlesTop;
                }
            }

            //Enough toppings
            else if (topping5Rend.sprite != null)
            {
                Debug.Log("That's enough toppings!");
                //StartCoroutine(UIManager.ShortPopUp(UIManager.tmToppingsMsg));
                //sound notification instead
            }
        }
    }

}
