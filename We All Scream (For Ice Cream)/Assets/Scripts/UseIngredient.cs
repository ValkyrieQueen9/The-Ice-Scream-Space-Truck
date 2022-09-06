using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseIngredient : MonoBehaviour
{
    [Header("Ingredient Type")]
    public bool iceCream = false;
    public bool topping = false;
    public bool sauce = false;

    [Header("Ingredient Flavour")]
    public bool galaxy = false;
    public bool rainbow = false;
    public bool neon = false;

    private SpriteRenderer Rend;

    //Flavours
    private Sprite galaxyScoop, rainbowScoop, neonTop;

    //Cone
    private GameObject cone;
    private SpriteRenderer coneRend;

    //Scoops
    private GameObject scoop1;
    private GameObject scoop2;
    private SpriteRenderer scoop1Rend;
    private SpriteRenderer scoop2Rend;

    //Toppings
    private GameObject topping1;
    private GameObject topping2;
    private SpriteRenderer topping1Rend;
    private SpriteRenderer topping2Rend;
    
    private void Start()
    {
        Rend = GetComponent<SpriteRenderer>();

        //Flavours
        galaxyScoop = Resources.Load<Sprite>("scoops/galaxyScoop");
        rainbowScoop = Resources.Load<Sprite>("scoops/rainbowScoop");
        neonTop = Resources.Load<Sprite>("toppings/neonTopping");

        //Cone
        cone = GameObject.FindGameObjectWithTag("Cone");

        //Scoops
        scoop1 = GameObject.Find("Scoop1");
        scoop2 = GameObject.Find("Scoop2");
        scoop1Rend = scoop1.GetComponent<SpriteRenderer>();
        scoop2Rend = scoop2.GetComponent<SpriteRenderer>();

        //Toppings
        topping1 = GameObject.Find("Topping1");
        topping2 = GameObject.Find("Topping2");
        topping1Rend = topping1.GetComponent<SpriteRenderer>();
        topping2Rend = topping2.GetComponent<SpriteRenderer>();

    }

    //When ingredient (script is attached to each ingredient) is clicked check for which ingredient type and flavour it is. 
    //- use bools triggered when script is set to decide the items type e.g. if ingredient is sprinkles, mark topping as true in inspector 

    //When ingredient type found trigger special function e.g. ice cream function

    //In each ingredient function check whether any other ingredients have been placed, if none add in lowest tier.
    //Maybe use invisible sprites that switch out art when triggered rather than creating new objects??

    public void addIngredient()
    {
        if (iceCream)
        {
            //Check if any scoops have been added to first layer of cone(scoop1)
            if(scoop1Rend.sprite == null)
            {
                if (galaxy)
                    {
                        scoop1Rend.sprite = galaxyScoop;
                    }
                if (rainbow)
                    {
                        scoop1Rend.sprite = rainbowScoop;
                    }
            }

            //Check if any scoops have been added to second layer of cone(scoop2)
            else if (scoop2Rend.sprite == null)
            {
                if (galaxy)
                    {
                        scoop2Rend.sprite = galaxyScoop;
                    }
                if (rainbow)
                    {
                        scoop2Rend.sprite = rainbowScoop;
                    }
            }

            else
            {
                Debug.Log("Too many scoops!");
            }

            //if a scoop has been added only add to scoop2
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

            else
            {
                Debug.Log("Too many toppings!");
            }
        }
    }

}
