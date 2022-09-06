using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseIngredient : MonoBehaviour
{
    [Header("Ingredient Type")]
    public bool iceCream = false;
    public bool topping = false;
    public bool sauce = false;

    private GameObject cone;
    private GameObject scoop1;
    private GameObject scoop2;
    private SpriteRenderer Rend;
    private Sprite galaxyFlavour, rainbowFlavour, galaxyScoop, rainbowScoop;
    private SpriteRenderer coneRend;
    private SpriteRenderer scoop1Rend;
    private SpriteRenderer scoop2Rend;


    private void Start()
    {
        Rend = GetComponent<SpriteRenderer>();
        galaxyFlavour = Resources.Load<Sprite>("flavours/galaxyIceCream");
        rainbowFlavour = Resources.Load<Sprite>("flavours/rainbowIceCream");
        galaxyScoop = Resources.Load<Sprite>("scoops/galaxyScoop");
        rainbowScoop = Resources.Load<Sprite>("scoops/rainbowScoop");
        cone = GameObject.FindGameObjectWithTag("Cone");
        scoop1 = GameObject.Find("Scoop1");
        scoop2 = GameObject.Find("Scoop2");
        scoop1Rend = scoop1.GetComponent<SpriteRenderer>();
        scoop2Rend = scoop2.GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
           if (iceCream)
        {
            Rend.sprite = galaxyFlavour;
            scoop1Rend.sprite = galaxyScoop;
        }
        if (topping)
        {
            Rend.sprite = rainbowFlavour;
            scoop2Rend.sprite = rainbowScoop;
        }
        
    }

    //When ingredient (script is attached to each ingredient) is clicked check for which ingredient type and flavour it is. 
    //- use bools triggered when script is set to decide the items type e.g. if ingredient is sprinkles, mark topping as true in inspector 

    //When ingredient type found trigger special function e.g. ice cream function

    //In each ingredient function check whether any other ingredients have been placed, if none add in lowest tier.
    //Maybe use invisible sprites that switch out art when triggered rather than creating new objects??

    void ChangeSprite()
    {
        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
        Sprite galaxyIceCream = Resources.Load<Sprite>("galaxyIceCream");
        currentSprite.sprite = galaxyIceCream;
    }

}
