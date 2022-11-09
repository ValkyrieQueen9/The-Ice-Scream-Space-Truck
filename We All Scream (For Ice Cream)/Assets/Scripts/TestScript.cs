using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Sprite animal, fruit, flower;

    //Can't use Sprites as arrays?
    //If using string or int, must find way to define which sprite/flavour it is!
    //Make array with all ingredients? Using ranges 3-7, 8-10 to choose ingredient type?
    //This way can make ingredients ordered via index? i.e: ingredients[2] = bloodySauce ///// if random == index 2 = sprite bloody sauce? then trigger orderBloodySauce

    int[] numberArray = new int[4];
    Sprite[] spriteArray = new Sprite[2];

    private void Start()
    {

        numberArray[0] = 10;
        numberArray[1] = 13;
        numberArray[2] = 13;
        numberArray[3] = 13;

        Debug.Log(numberArray[3]);

        spriteArray[0] = animal;
        spriteArray[1] = fruit;
        spriteArray[2] = flower;

        Debug.Log(spriteArray[2]);
    }
}
