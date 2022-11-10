using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    //Make array with all ingredients? Using ranges 3-7, 8-10 to choose ingredient type?
    //This way can make ingredients ordered via index? i.e: ingredients[2] = bloodySauce ///// if random == index 2 = sprite bloody sauce? then trigger orderBloodySauce
    //To check order submissions - if index 7 = acid sauce, if sauce1 == acidSauce then sauce bool is true, if all builder bools are true == success 

    string[] ingredients = new string[14];
    string Ingredient;
    public bool randomiserButton = false;
    public string selection = "null";
    //public bool currentOrder = false;

    private void Start()
    {
        //Cone
        ingredients[0] = "plainCone";
        //Scoops
        ingredients[1] = "boneScoop";
        ingredients[2] = "cosmicScoop";
        ingredients[3] = "magmaScoop";
        ingredients[4] = "meatScoop";
        ingredients[5] = "tropicalScoop";
        //Sauces
        ingredients[6] = "acidSauce";
        ingredients[7] = "bloodySauce";
        ingredients[8] = "bloodyUnicornSauce";
        ingredients[9] = "soulSauce";
        //Toppings
        ingredients[10] = "batteriesTop";
        ingredients[11] = "eyeballsTop";
        ingredients[12] = "gemsTop";
        ingredients[13] = "glassTop";
        ingredients[14] = "nettlesTop";
    }

    private void Update()
    {
        if (randomiserButton)
        {
            Ingredient = ingredients[Randomiser(1, 5)];
        }
        selection = Ingredient;
        Debug.Log(selection.ToString());
        Debug.Log("Randomiser: " + Randomiser(1, 9).ToString());

        //Create while loop for orders:
        //While currentOrder == true, don't run code. When false, run code and change current order to true. Change to false when an order is submitted.

        /*
        while (currentOrder == false)
        {
            //Create variables for each ingredient space
            //Randomise the variables ingredient using randomiser.
            //Trigger currentOrder to true - trigger to false when order is successfully submitted (later in script?)
        }
        */
        //if statements to determine which randomised item was chosen and to change the order ticket items.
        //All sprites needed here and new sprites for tickets
    }

    private int Randomiser(int x, int y)
    {
        int index = Random.Range(x, y);
        return index;
        
    }




}
