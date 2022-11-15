using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrders_ : MonoBehaviour
{
    //Script Purpose: Randomise customer orders and output selection to inspector and order ticket. 
    //Randomise Customer at the window and trigger shutter movement. When Ice Cream is submitted check it against the randomised.

    //----Add all ingredient Sprites - copy from use ingredients
    //----New ingredient sprites needed for orders
    //----Create lists of each ingredient type and customers for each level
    //---Create randomiser function and output to inspector
    //Output order to order ticket
    //Create function to check submitted ice cream against randomised result
    //Separate boss customer order later
    //Create simple successful order counter.

    public GameObject shutterOpen;
    public GameObject shutterClosed;
    public GameObject shutter;
    public float shutterSpeed = 5f;
    public bool shutterTrigger = false;

    public bool currentOrder = false;
    public string[] ingredients = new string[15];

    //Orders
    public string orderCone;
    public string orderIceCream1;
    public string orderIceCream2;
    public string orderIceCream3;
    public string orderIceCream4;
    public string orderIceCream5;
    public string orderSauce;
    public string orderTopping;

    //Renderers
    private SpriteRenderer Rend;

    //Ticket Ingredients Sprites
    private Sprite ticketPlainCone, ticketBoneScoop, ticketCosmicScoop, ticketMagmaScoop, ticketMeatScoop, ticketTropicalScoop, ticketAcidSauce, ticketBloodySauce, ticketBloodyUnicornSauce, ticketSoulSauce, ticketBatteriesTop, ticketEyeballsTop, ticketGemsTop, ticketGlassTop, ticketNettlesTop;

    //Flavours Sprites
    private Sprite plainCone, boneScoop, cosmicScoop, magmaScoop, meatScoop, tropicalScoop, acidSauce, bloodySauce, bloodyUnicornSauce, soulSauce, batteriesTop, eyeballsTop, gemsTop, glassTop, nettlesTop;

    //Cone Builder
    private GameObject buildCone;
    private SpriteRenderer buildConeRend;

    //Scoops Builder
    private GameObject scoop1, scoop2, scoop3, scoop4, scoop5;
    private SpriteRenderer scoop1Rend, scoop2Rend, scoop3Rend, scoop4Rend, scoop5Rend;

    //Sauce Builder
    private GameObject sauce1, sauce2, sauce3, sauce4, sauce5;
    private SpriteRenderer sauce1Rend, sauce2Rend, sauce3Rend, sauce4Rend, sauce5Rend;

    //Toppings Builder
    private GameObject topping1, topping2, topping3, topping4, topping5;
    private SpriteRenderer topping1Rend, topping2Rend, topping3Rend, topping4Rend, topping5Rend;

    //Order Ticket Builder
    private GameObject ticketCone, ticketScoop1, ticketScoop2, ticketScoop3, ticketScoop4, ticketScoop5, ticketSauce, ticketTopping;
    private SpriteRenderer ticketConeRend, ticketScoop1Rend, ticketScoop2Rend, ticketScoop3Rend, ticketScoop4Rend, ticketScoop5Rend, ticketSauceRend, ticketToppingRend; 


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

        //Ticket Ingredient Sprites
        
        ticketPlainCone = Resources.Load<Sprite>("cones/plainCone");

        ticketBoneScoop = Resources.Load<Sprite>("scoops/boneScoop");
        ticketCosmicScoop = Resources.Load<Sprite>("scoops/cosmicScoop");
        ticketMagmaScoop = Resources.Load<Sprite>("scoops/magmaScoop");
        ticketMeatScoop = Resources.Load<Sprite>("scoops/meatScoop");
        ticketTropicalScoop = Resources.Load<Sprite>("scoops/tropicalScoop");

        ticketAcidSauce = Resources.Load<Sprite>("sauces/acidSauce");
        ticketBloodySauce = Resources.Load<Sprite>("sauces/bloodySauce");
        ticketBloodyUnicornSauce = Resources.Load<Sprite>("sauces/bloodyUnicornSauce");
        ticketSoulSauce = Resources.Load<Sprite>("sauces/soulSauce");

        ticketBatteriesTop = Resources.Load<Sprite>("toppings/batteriesTopping");
        ticketEyeballsTop = Resources.Load<Sprite>("toppings/eyeballsTopping");
        ticketGemsTop = Resources.Load<Sprite>("toppings/gemsTopping");
        ticketGlassTop = Resources.Load<Sprite>("toppings/glassTopping");
        ticketNettlesTop = Resources.Load<Sprite>("toppings/nettlesTopping");

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
        scoop5Rend = scoop5.GetComponent<SpriteRenderer>();

        //Sauces Renderer
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

        //Toppings Renderer
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

        //Order Ticket Renderer
        ticketCone = GameObject.Find("TicketCone");
        ticketScoop1 = GameObject.Find("TicketScoop1");
        ticketScoop2 = GameObject.Find("TicketScoop2");
        ticketScoop3 = GameObject.Find("TicketScoop3");
        ticketScoop4 = GameObject.Find("TicketScoop4");
        ticketScoop5 = GameObject.Find("TicketScoop5");
        ticketSauce = GameObject.Find("TicketSauce");
        ticketTopping = GameObject.Find("TicketTopping");
        ticketConeRend = ticketCone.GetComponent<SpriteRenderer>();
        ticketScoop1Rend = ticketScoop1.GetComponent<SpriteRenderer>();
        ticketScoop2Rend = ticketScoop2.GetComponent<SpriteRenderer>();
        ticketScoop3Rend = ticketScoop3.GetComponent<SpriteRenderer>();
        ticketScoop4Rend = ticketScoop4.GetComponent<SpriteRenderer>();
        ticketScoop5Rend = ticketScoop5.GetComponent<SpriteRenderer>();
        ticketSauceRend = ticketSauce.GetComponent<SpriteRenderer>();
        ticketToppingRend = ticketTopping.GetComponent<SpriteRenderer>();

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
        StartCoroutine(NewOrder());
        
        StartCoroutine(NewOrderTransition());
        
    }

    private int Randomiser(int x, int y)
    {
        int index = Random.Range(x, y);
        return index;
    }

    private bool ShutterOpened()
    {
        return shutter.transform.position == shutterOpen.transform.position;
    }

    private bool ShutterClosed()
    {
        return shutter.transform.position == shutterClosed.transform.position;
    }

    IEnumerator NewOrder()
    {
        
        while (currentOrder == false)
        {
            orderCone = ingredients[0];

            orderIceCream1 = ingredients[Randomiser(1, 6)];
            orderIceCream2 = ingredients[Randomiser(1, 6)];
            orderIceCream3 = ingredients[Randomiser(1, 6)];
            orderIceCream4 = ingredients[Randomiser(1, 6)];
            orderIceCream5 = ingredients[Randomiser(1, 6)];
            
            orderSauce = ingredients[Randomiser(6, 10)];

            orderTopping = ingredients[Randomiser(10, 15)];

            yield return new WaitUntil(ShutterOpened);

            currentOrder = true;
            //Trigger false when an order is successfully submitted.

        }

        //Many if statements to trigger ticket sprites - maybe move to Update() for order checking later?

        //Bone Ice Cream
        if (orderIceCream1 == ingredients[1]) //if the first scoop is bone ice cream change the order ticket sprite
        {
            ticketScoop1Rend.sprite = ticketBoneScoop;
        }
        if (orderIceCream2 == ingredients[1])
        {
            ticketScoop2Rend.sprite = ticketBoneScoop;
        }
        if (orderIceCream3 == ingredients[1])
        {
            ticketScoop3Rend.sprite = ticketBoneScoop;
        }
        if (orderIceCream4 == ingredients[1])
        {
            ticketScoop4Rend.sprite = ticketBoneScoop;
        }
        if (orderIceCream5 == ingredients[1])
        {
            ticketScoop5Rend.sprite = ticketBoneScoop;
        }
        //Cosmic Ice Cream
        if (orderIceCream1 == ingredients[2])
        {
            ticketScoop1Rend.sprite = ticketCosmicScoop;
        }
        if (orderIceCream2 == ingredients[2])
        {
            ticketScoop2Rend.sprite = ticketCosmicScoop;
        }
        if (orderIceCream3 == ingredients[2])
        {
            ticketScoop3Rend.sprite = ticketCosmicScoop;
        }
        if (orderIceCream4 == ingredients[2])
        {
            ticketScoop4Rend.sprite = ticketCosmicScoop;
        }
        if (orderIceCream5 == ingredients[2])
        {
            ticketScoop5Rend.sprite = ticketCosmicScoop;
        }
        //Magma Ice Cream
        if (orderIceCream1 == ingredients[3])
        {
            ticketScoop1Rend.sprite = ticketMagmaScoop;
        }
        if (orderIceCream2 == ingredients[3])
        {
            ticketScoop2Rend.sprite = ticketMagmaScoop;
        }
        if (orderIceCream3 == ingredients[3])
        {
            ticketScoop3Rend.sprite = ticketMagmaScoop;
        }
        if (orderIceCream4 == ingredients[3])
        {
            ticketScoop4Rend.sprite = ticketMagmaScoop;
        }
        if (orderIceCream5 == ingredients[3])
        {
            ticketScoop5Rend.sprite = ticketMagmaScoop;
        }
        //Meat Ice Cream
        if (orderIceCream1 == ingredients[4])
        {
            ticketScoop1Rend.sprite = ticketMeatScoop;
        }
        if (orderIceCream2 == ingredients[4])
        {
            ticketScoop2Rend.sprite = ticketMeatScoop;
        }
        if (orderIceCream3 == ingredients[4])
        {
            ticketScoop3Rend.sprite = ticketMeatScoop;
        }
        if (orderIceCream4 == ingredients[4])
        {
            ticketScoop4Rend.sprite = ticketMeatScoop;
        }
        if (orderIceCream5 == ingredients[4])
        {
            ticketScoop5Rend.sprite = ticketMeatScoop;
        }
        //Tropical Ice Cream
        if (orderIceCream1 == ingredients[5])
        {
            ticketScoop1Rend.sprite = ticketTropicalScoop;
        }
        if (orderIceCream2 == ingredients[5])
        {
            ticketScoop2Rend.sprite = ticketTropicalScoop;
        }
        if (orderIceCream3 == ingredients[5])
        {
            ticketScoop3Rend.sprite = ticketTropicalScoop;
        }
        if (orderIceCream4 == ingredients[5])
        {
            ticketScoop4Rend.sprite = ticketTropicalScoop;
        }
        if (orderIceCream5 == ingredients[5])
        {
            ticketScoop5Rend.sprite = ticketTropicalScoop;
        }
        //Sauces
        if (orderSauce == ingredients[6])
        {
            ticketSauceRend.sprite = ticketAcidSauce;
        }
        if (orderSauce == ingredients[7])
        {
            ticketSauceRend.sprite = ticketBloodySauce;
        }
        if (orderSauce == ingredients[8])
        {
            ticketSauceRend.sprite = ticketBloodyUnicornSauce;
        }
        if (orderSauce == ingredients[9])
        {
            ticketSauceRend.sprite = ticketSoulSauce;
        }
        //Toppings
        if (orderTopping == ingredients[10])
        {
            ticketToppingRend.sprite = ticketBatteriesTop;
        }
        if (orderTopping == ingredients[11])
        {
            ticketToppingRend.sprite = ticketEyeballsTop;
        }
        if (orderTopping == ingredients[12])
        {
            ticketToppingRend.sprite = ticketGemsTop;
        }
        if (orderTopping == ingredients[13])
        {
            ticketToppingRend.sprite = ticketGlassTop;
        }
        if (orderTopping == ingredients[14])
        {
            ticketToppingRend.sprite = ticketNettlesTop;
        }
    }

    
    IEnumerator NewOrderTransition ()
    {
        if (ShutterClosed() == false)
        {
            shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, shutterClosed.transform.position, shutterSpeed * Time.deltaTime);
            Debug.Log("Shutter Closing");
            yield return new WaitUntil(ShutterClosed);
            Debug.Log("Shutter Closed");
        }
       
        shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, shutterOpen.transform.position, shutterSpeed * Time.deltaTime);
        Debug.Log("Shutter Opening");
        yield return new WaitUntil(ShutterOpened);
        Debug.Log("ShutterOpen");
    } 
   

}
