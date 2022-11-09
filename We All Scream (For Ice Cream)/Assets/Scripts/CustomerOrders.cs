using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrders : MonoBehaviour
{

    //Script Purpose: Randomise customer orders and output selection to inspector and order ticket. 
    //Randomise Customer at the window and trigger shutter movement. When Ice Cream is submitted check it against the randomised.

    //Add all ingredient Sprites - copy from use ingredients
    //New ingredient sprites needed for orders
    //Create lists of each ingredient type and customers for each level
    //OPTION: Create one list for each ing type and add ingredients after each level
    //Create randomiser function and output to inspector, then later, to order ticket
    //Create function to check submitted ice cream against randomised result
    //Separate boss customer order later
    //Create simple successful order counter.

    public bool randomiserButton = false;
    public Sprite iceCreamSelection;
    int runOnce = 0;

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

    //Toppings
    private GameObject topping1, topping2, topping3, topping4, topping5;
    private SpriteRenderer topping1Rend, topping2Rend, topping3Rend, topping4Rend, topping5Rend;

    //Lists
    private Sprite[] iceCreams = new Sprite[5];
    private Sprite[] sauces = new Sprite[4];
    Sprite[] toppings = new Sprite[4];

    //Orders - Variables to store the selected ingredients
    private int ingredientIndex;
    private Sprite orderIceCream1;
    private Sprite orderIceCream2;
    private Sprite orderIceCream3;
    private Sprite orderIceCream4;
    private Sprite orderIceCream5;
    private Sprite orderSauce;
    private Sprite orderTopping;

    private void Start()
    {
        Rend = GetComponent<SpriteRenderer>();

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

        //Lists
        iceCreams[0] = boneScoop;
        iceCreams[1] = cosmicScoop;
        iceCreams[2] = magmaScoop;
        iceCreams[3] = meatScoop;
        iceCreams[4] = tropicalScoop;

        sauces[0] = acidSauce;
        sauces[1] = bloodySauce;
        sauces[2] = bloodyUnicornSauce;
        sauces[3] = soulSauce;

        toppings[0] = batteriesTop;
        toppings[1] = eyeballsTop;
        toppings[2] = gemsTop;
        toppings[3] = glassTop;
        toppings[4] = nettlesTop;

    }

    private void Update()
    {
        /*
        if(randomiserButton == true && runOnce == 0)
        {
        orderIceCream1 = iceCreams[Randomiser()];
        runOnce += 1;
        }
        iceCreamSelection = iceCreams[2];
        */
    }

    private int Randomiser()
    {
        int index = Random.Range(0, 5);
        return index;
    }
}
