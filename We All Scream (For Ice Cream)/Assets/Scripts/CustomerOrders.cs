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
    public string selection = "null";
    string Ingredient;

    //Lists
    public string[] ingredients = new string[14];

    //Orders - Variables to store the selected ingredients
    private int ingredientIndex;
    public string ticketIceCream1;
    public string ticketIceCream2;
    public string ticketIceCream3;
    public string ticketIceCream4;
    public string ticketIceCream5;
    public string ticketSauce;
    public string ticketTopping;

    //Renderers
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

    private void Start()
    {
        Rend = GetComponent<SpriteRenderer>();

        //Ingredient Sprites
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

        //Cone Renderer
        buildCone = GameObject.FindGameObjectWithTag("Cone");
        buildConeRend = buildCone.GetComponent<SpriteRenderer>();

        //Scoops Renderer
        scoop1 = GameObject.Find("Scoop1");
        scoop2 = GameObject.Find("Scoop2");
        scoop3 = GameObject.Find("Scoop3");
        scoop4 = GameObject.Find("Scoop4");
        scoop5 = GameObject.Find("Scoop5");
        scoop1Rend = scoop1.GetComponent<SpriteRenderer>();
        scoop2Rend = scoop2.GetComponent<SpriteRenderer>();
        scoop3Rend = scoop3.GetComponent<SpriteRenderer>();
        scoop4Rend = scoop4.GetComponent<SpriteRenderer>();
        //scoop5Rend = scoop5.GetComponent<SpriteRenderer>();

        //Sauces Renderer - Only one exists?
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

        //Toppings Renderer - Only one exists?
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

        //Ingredient List
        ingredients[0] = "plainCone";

        ingredients[1] = "boneScoop";
        ingredients[2] = "cosmicScoop";
        ingredients[3] = "magmaScoop";
        ingredients[4] = "meatScoop";
        ingredients[5] = "tropicalScoop";

        ingredients[6] = "acidSauce";
        ingredients[7] = "bloodySauce";
        ingredients[8] = "bloodyUnicornSauce";
        ingredients[9] = "soulSauce";
        
        ingredients[10] = "batteriesTop";
        ingredients[11] = "eyeballsTop";
        ingredients[12] = "gemsTop";
        ingredients[13] = "glassTop";
        ingredients[14] = "nettlesTop";

    }

    private void Update()
    {
        //TEST
        if (randomiserButton)
        {
            //Cone randomiser not needed currently
            ticketIceCream1 = ingredients[Randomiser(1, 5)];
            ticketIceCream2 = ingredients[Randomiser(1, 5)];
            ticketIceCream3 = ingredients[Randomiser(1, 5)];
            ticketIceCream4 = ingredients[Randomiser(1, 5)];
            ticketIceCream5 = ingredients[Randomiser(1, 5)];
            ticketSauce = ingredients[Randomiser(6, 9)];
            ticketTopping = ingredients[Randomiser(10, 14)];
            Ingredient = ingredients[Randomiser(1, 5)];

        }
        selection = ingredients[5];
        Debug.Log(ingredients[2].ToString());
    }

    private int Randomiser(int x, int y)
    {
        int index = Random.Range(x, y);
        return index;
    }
}
