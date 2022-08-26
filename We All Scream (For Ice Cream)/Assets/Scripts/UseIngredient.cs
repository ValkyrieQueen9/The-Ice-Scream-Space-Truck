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

    private void Start()
    {
        cone = get
    }

    //When ingredient (script is attached to each ingredient) is clicked check for which ingredient type it is. 
    //- use bools triggered when script is set to decide the items type e.g. if ingredient is sprinkles, mark topping as true in inspector 

    //When ingredient type found trigger special function e.g. ice cream function

    //In each ingredient function check whether any other ingredients have been placed, if none add in lowest tier.
    //Maybe use invisible sprites that switch out art when triggered rather than creating new objects??



}
