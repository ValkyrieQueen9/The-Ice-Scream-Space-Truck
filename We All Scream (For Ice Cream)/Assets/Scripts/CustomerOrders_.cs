using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public enum orderEnum
{
    STATE_GAME_START,
    STATE_CLOSED,
    STATE_OPENING,
    STATE_OPENED,
    STATE_CLOSING
}

public class CustomerOrders_ : MonoBehaviour
{
    //Script Purpose: Randomise customer orders and output selection to inspector and order ticket. 
    //Randomise Customer at the window and trigger shutter movement. When Ice Cream is submitted check it against the randomised.

    public GameObject beginGameButton;
    public GameObject submitButton;
    public GameObject restartButton;
    public AudioManager audioManager;
    public orderEnum orderEnum;
    public int orderCount = 0;

    [Header("Shutter Options")]
    public GameObject shutterOpen;
    public GameObject shutterClosed;
    public GameObject shutter;
    public float shutterSpeed = 5f;
    public float shutterWaitTime = 2f;

    [Header("Ice Cream Order")]
    public string orderCone;
    public string orderIceCream1;
    public string orderIceCream2;
    public string orderIceCream3;
    public string orderIceCream4;
    public string orderIceCream5;
    public string orderSauce;
    public string orderTopping;

    [HideInInspector]
    public int counterRunOnce = 0;
    public bool beginGame = false;

    //Game
    private bool ignoreThis = true;

    //Customer Sprites
    private SpriteRenderer customerSpaceRend;
    private SpriteRenderer customerBGRend;
    private Sprite level1Window, level2Window;
    private Sprite demonNormal, demonHappy, demonAngry, fireBoiNormal, fireBoiHappy, fireBoiAngry,  shadyNormal, shadyHappy, shadyAngry, funGuyNormal, funGuyHappy, funGuyAngry, witchNormal, witchHappy, witchAngry, tinyNormal, tinyHappy, tinyAngry;

    //Submission Checklist
    private bool coneResult, scoop1Result, scoop2Result, scoop3Result, scoop4Result, scoop5Result, sauceResult, toppingResult, submitResult = false;
    private bool orderSubmit = false;

    //Ingredients Array
    private string[] ingredients = new string[15];

    //Other GameObjects & Scripts
    private GameObject levelManagerObj;
    private LevelManager levelManager;
    private GameObject orderNumberObj;
    private TextMeshProUGUI orderNumber;

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
        //For each level there are different flavours being used. Use: if(scene level 1? or state level 1?) then define scoops 1-2 only 
        submitButton.SetActive(false);
        beginGameButton.SetActive(false);
        restartButton.SetActive(false);

        //Customer Sprites
        customerSpaceRend = GameObject.Find("CustomerSpace").GetComponent<SpriteRenderer>();
        customerBGRend = GameObject.Find("CustomerBG").GetComponent<SpriteRenderer>();

        level1Window = Resources.Load<Sprite>("backgrounds/level1Window");
        level2Window = Resources.Load<Sprite>("backgrounds/level2Window");

        fireBoiNormal = Resources.Load<Sprite>("customers/fireBoi0");
        fireBoiHappy = Resources.Load<Sprite>("customers/fireBoi1");
        fireBoiAngry = Resources.Load<Sprite>("customers/fireBoi2");
        demonNormal = Resources.Load<Sprite>("customers/demon0");
        demonHappy = Resources.Load<Sprite>("customers/demon1");
        demonAngry = Resources.Load<Sprite>("customers/demon2");
        shadyNormal = Resources.Load<Sprite>("customers/shady0");
        shadyHappy = Resources.Load<Sprite>("customers/shady1");
        shadyAngry = Resources.Load<Sprite>("customers/shady2");

        funGuyNormal = Resources.Load<Sprite>("customers/funGuy0");
        funGuyHappy = Resources.Load<Sprite>("customers/funGuy1");
        funGuyAngry = Resources.Load<Sprite>("customers/funGuy2");
        witchNormal = Resources.Load<Sprite>("customers/witch0");
        witchHappy = Resources.Load<Sprite>("customers/witch1");
        witchAngry = Resources.Load<Sprite>("customers/witch2");
        tinyNormal = Resources.Load<Sprite>("customers/tiny0");
        tinyHappy = Resources.Load<Sprite>("customers/tiny1");
        tinyAngry = Resources.Load<Sprite>("customers/tiny2");

        //Level Manager
        levelManagerObj = GameObject.Find("Level Manager");
        levelManager = levelManagerObj.GetComponent<LevelManager>();

        //Order Number
        orderNumberObj = GameObject.Find("OrderNumber");
        orderNumber = orderNumberObj.GetComponent<TextMeshProUGUI>();
        
        //Renderer
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
        ingredients[10] = "batteriesTopping";
        ingredients[11] = "eyeballsTopping";
        ingredients[12] = "gemsTopping";
        ingredients[13] = "glassTopping";
        ingredients[14] = "nettlesTopping";
    }

    private void Update()
    {
        switch (orderEnum)
        {
            case orderEnum.STATE_GAME_START: //BEGIN GAME IN STATE_GAME_START
                Debug.Log("Game has not started");
                orderCount = 0;
                orderNumber.text = ("0");
                counterRunOnce = 0;
                EmptyOrderTicket();
                ClearOrder();
                shutter.transform.position = shutterClosed.transform.position;

                if (levelManager.gameplayActive)
                {
                    beginGameButton.SetActive(true);
                }
                else
                {
                    beginGameButton.SetActive(false);
                }

                if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL1)
                {
                    customerBGRend.sprite = level1Window;
                    customerSpaceRend.sprite = fireBoiNormal;
                }

                if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL2)
                {
                    customerBGRend.sprite = level2Window;
                    customerSpaceRend.sprite = funGuyNormal;
                }

                if (beginGame)
                {
                    beginGameButton.SetActive(false);
                    orderEnum = orderEnum.STATE_CLOSED;
                }

                break;

            case orderEnum.STATE_CLOSED: //STATE_CLOSED
                EmptyOrderTicket();
                ClearOrder();
                orderSubmit = false;

                if (beginGame)
                {
                    audioManager.PlaySound("WindowShutterOpen");
                    orderEnum = orderEnum.STATE_OPENING;
                }
                else
                {
                    StartCoroutine(Wait(orderEnum.STATE_OPENING, shutterWaitTime));
                    audioManager.PlaySound("WindowShutterOpen");
                }

                break;

            //STATE_OPENING
            case orderEnum.STATE_OPENING:
                beginGame = false;
                shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, shutterOpen.transform.position, shutterSpeed * Time.deltaTime);


                //Randomise Ingredients
                orderCone = ingredients[0];
                orderIceCream1 = ingredients[Randomiser(1, 6)];
                orderIceCream2 = ingredients[Randomiser(1, 6)];
                orderIceCream3 = ingredients[Randomiser(1, 6)];
                orderIceCream4 = ingredients[Randomiser(1, 6)];
                orderIceCream5 = ingredients[Randomiser(1, 6)];
                orderSauce = ingredients[Randomiser(6, 10)];
                orderTopping = ingredients[Randomiser(10, 15)];

                if (ShutterOpened())
                {
                    orderEnum = orderEnum.STATE_OPENED;
                }

                break;

            //STATE_OPENED
            case orderEnum.STATE_OPENED:
                ChangeOrderTicket();
                if (levelManager.gameplayActive)
                {
                    submitButton.SetActive(true);
                    restartButton.SetActive(true);
                }
                else
                {
                    restartButton.SetActive(false);
                    submitButton.SetActive(false);
                }

                if (orderSubmit)
                {
                    if (submitResult)
                    {
                        Count();
                        orderNumber.text = (orderCount.ToString());
                        ChangeEmotionHappy();
                        StartCoroutine(Wait(orderEnum.STATE_CLOSING, shutterWaitTime));
                        audioManager.PlaySound("WindowShutterClose");
                    }
                    else
                    {
                        ChangeEmotionAngry();
                    }

                }

                break;

            //STATE_CLOSING
            case orderEnum.STATE_CLOSING:
                counterRunOnce = 0;
                submitButton.SetActive(false);
                restartButton.SetActive(false);
                shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, shutterClosed.transform.position, shutterSpeed * Time.deltaTime);
                if (ShutterClosed())
                {
                    if (levelManager.levelTimesUp == false)
                    {
                        ChangeCustomer();
                        orderEnum = orderEnum.STATE_CLOSED;
                    }
                    else
                        orderEnum = orderEnum.STATE_GAME_START;
                }

   
        break;

            default:
                break;
        }


    }        

    public void BeginGame()
    {
        beginGame = true;
    }

    public void OrderSubmit()
    {
        Debug.Log("Order Submitted");
        CheckOrder();
        orderSubmit = true;
    }

    public void ClearOrder()
    {
        buildConeRend.sprite =null;
        scoop1Rend.sprite = null; scoop2Rend.sprite = null; scoop3Rend.sprite = null; scoop4Rend.sprite = null; scoop5Rend.sprite = null;
        sauce1Rend.sprite = null; sauce2Rend.sprite = null; sauce3Rend.sprite = null; sauce4Rend.sprite = null; sauce5Rend.sprite = null;
        topping1Rend.sprite = null; topping2Rend.sprite = null; topping3Rend.sprite = null; topping4Rend.sprite = null; topping5Rend.sprite = null;

        coneResult = false; scoop1Result = false; scoop2Result = false; scoop3Result = false; scoop4Result = false; scoop5Result = false; sauceResult = false; toppingResult = false; submitResult = false;
    }

    public void EmptyOrderTicket()
    {
        ticketConeRend.sprite = null;
        ticketScoop1Rend.sprite = null;
        ticketScoop2Rend.sprite = null;
        ticketScoop3Rend.sprite = null;
        ticketScoop4Rend.sprite = null;
        ticketScoop5Rend.sprite = null;
        ticketSauceRend.sprite = null;
        ticketToppingRend.sprite = null;
    }

    public void Count()
    {
        if(counterRunOnce == 0)
        {
            orderCount += 1;
            counterRunOnce += 1;
        }
        
    }

    public bool ShutterOpened()
    {
        return shutter.transform.position == shutterOpen.transform.position;
    }

    public bool ShutterClosed()
    {
        return shutter.transform.position == shutterClosed.transform.position;
    }

    private int Randomiser(int x, int y)
    {
        int index = Random.Range(x, y);
        return index;
    }

    private void ChangeCustomer() 
    {
        //Unsure how this will work with more customers
        if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL1)
        {
            customerBGRend.sprite = level1Window;
            if (customerSpaceRend.sprite == fireBoiNormal || customerSpaceRend.sprite == fireBoiHappy || customerSpaceRend.sprite == fireBoiAngry)
            {
                customerSpaceRend.sprite = demonNormal;
            }
            else if (customerSpaceRend.sprite == demonNormal || customerSpaceRend.sprite == demonHappy || customerSpaceRend.sprite == demonAngry)
            {
                customerSpaceRend.sprite = shadyNormal;
            }
            else if (customerSpaceRend.sprite == shadyNormal || customerSpaceRend.sprite == shadyHappy || customerSpaceRend.sprite == shadyAngry)
            {
                customerSpaceRend.sprite = fireBoiNormal;
            }
        }

        if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL2)
        {
            customerBGRend.sprite = level2Window;

            if (customerSpaceRend.sprite == witchNormal || customerSpaceRend.sprite == witchHappy || customerSpaceRend.sprite == witchAngry)
            {
                customerSpaceRend.sprite = funGuyNormal;
            }
            else if (customerSpaceRend.sprite == funGuyNormal || customerSpaceRend.sprite == funGuyHappy || customerSpaceRend.sprite == funGuyAngry)
            {
                customerSpaceRend.sprite = tinyNormal;
            }
            else if (customerSpaceRend.sprite == tinyNormal || customerSpaceRend.sprite == tinyHappy || customerSpaceRend.sprite == tinyAngry)
            {
                customerSpaceRend.sprite = witchNormal;
            }
        }
    }

    private void ChangeEmotionHappy()
    {
        if (customerSpaceRend.sprite == demonNormal || customerSpaceRend.sprite == demonAngry)
        {
            customerSpaceRend.sprite = demonHappy;
        }

        else if(customerSpaceRend.sprite == fireBoiNormal || customerSpaceRend.sprite == fireBoiAngry)
        {
            customerSpaceRend.sprite = fireBoiHappy;
        }

        else if (customerSpaceRend.sprite == shadyNormal || customerSpaceRend.sprite == shadyAngry)
        {
            customerSpaceRend.sprite = shadyHappy;
        }

        else if (customerSpaceRend.sprite == funGuyNormal || customerSpaceRend.sprite == funGuyAngry)
        {
            customerSpaceRend.sprite = funGuyHappy;
        }

        else if (customerSpaceRend.sprite == witchNormal || customerSpaceRend.sprite == witchAngry)
        {
            customerSpaceRend.sprite = witchHappy;
        }
        
        else if (customerSpaceRend.sprite == tinyNormal || customerSpaceRend.sprite == tinyAngry)
        {
            customerSpaceRend.sprite = tinyHappy;
        }
    }

    private void ChangeEmotionAngry()
    {
        if (customerSpaceRend.sprite == demonNormal || customerSpaceRend.sprite == demonHappy)
        {
            customerSpaceRend.sprite = demonAngry;
        }

        else if (customerSpaceRend.sprite == fireBoiNormal || customerSpaceRend.sprite == fireBoiHappy)
        {
            customerSpaceRend.sprite = fireBoiAngry;
        }

        else if (customerSpaceRend.sprite == shadyNormal || customerSpaceRend.sprite == shadyHappy)
        {
            customerSpaceRend.sprite = shadyAngry;
        }

        else if (customerSpaceRend.sprite == funGuyNormal || customerSpaceRend.sprite == funGuyHappy)
        {
            customerSpaceRend.sprite = funGuyAngry;
        }

        else if (customerSpaceRend.sprite == witchNormal || customerSpaceRend.sprite == witchHappy)
        {
            customerSpaceRend.sprite = witchAngry;
        }

        else if (customerSpaceRend.sprite == tinyNormal || customerSpaceRend.sprite == tinyHappy)
        {
            customerSpaceRend.sprite = tinyAngry;
        }
    }

    private void ChangeOrderTicket()
    {

        //Cone
        if(orderCone == ingredients[0])
        {
            ticketConeRend.sprite = ticketPlainCone;
        }
        //Bone Ice Cream
        if (orderIceCream1 == ingredients[1])
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

    private void CheckOrder()
    {
        if(ignoreThis == false) //Code to use later if less flavour options per level is used
        { 
        //LEVEL 1 CHECKS - 2 Scoops 
        if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL1) //If game is on Level 1 only check cone, scoop1, sauce and topping
        {
            if (string.Compare(orderCone, buildConeRend.sprite.name) == 0)
            {
                coneResult = true;
                Debug.Log("Cone is correct");
            }
            else
            {
                Debug.Log("Cone is wrong");
            }

            if (string.Compare(orderIceCream1, scoop1Rend.sprite.name) == 0)
            {
                scoop1Result = true;
                Debug.Log("Scoop 1 is correct");
            }
            else
            {
                Debug.Log("Scoop 1 is wrong");
            }

            if (string.Compare(orderIceCream2, scoop2Rend.sprite.name) == 0)
            {
                scoop2Result = true;
                Debug.Log("Scoop 2 is correct!");
            }
            else
            {
                Debug.Log("Scoop 2 is wrong");
            }

            if (string.Compare(orderSauce, sauce2Rend.sprite.name) == 0)
            {
                sauceResult = true;
                Debug.Log("Sauce 2 is correct");
            }
            else
            {
                Debug.Log("Sauce 2 is wrong");
            }

            if (string.Compare(orderTopping, topping2Rend.sprite.name) == 0)
            {
                toppingResult = true;
                Debug.Log("Topping 2 is correct");
            }
            else
            {
                Debug.Log("Topping 2 is wrong");
            }

            if (coneResult && scoop1Result && scoop2Result && sauceResult && toppingResult == true)
            {
                submitResult = true;
                Debug.Log("SUCCESS");
            }
            else
            {
                Debug.Log("FAIL");
            }
        }
        
        //LEVEL 2 CHECKS - 3 Scoops
        if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL2)
        {
            if (string.Compare(orderCone, buildConeRend.sprite.name) == 0)
            {
                coneResult = true;
                Debug.Log("Cone is correct");
            }
            else
            {
                Debug.Log("Cone is wrong");
            }

            if (string.Compare(orderIceCream1, scoop1Rend.sprite.name) == 0)
            {
                scoop1Result = true;
                Debug.Log("Scoop 1 is correct");
            }
            else
            {
                Debug.Log("Scoop 1 is wrong");
            }

            if (string.Compare(orderIceCream2, scoop2Rend.sprite.name) == 0)
            {
                scoop2Result = true;
                Debug.Log("Scoop 2 is correct!");
            }
            else
            {
                Debug.Log("Scoop 2 is wrong");
            }

            if (string.Compare(orderIceCream3, scoop3Rend.sprite.name) == 0)
            {
                scoop3Result = true;
                Debug.Log("Scoop 3 is correct!");
            }
            else
            {
                Debug.Log("Scoop 3 is wrong");
            }

            if (string.Compare(orderSauce, sauce3Rend.sprite.name) == 0)
            {
                sauceResult = true;
                Debug.Log("Sauce 3 is correct");
            }
            else
            {
                Debug.Log("Sauce 3 is wrong");
            }

            if (string.Compare(orderTopping, topping3Rend.sprite.name) == 0)
            {
                toppingResult = true;
                Debug.Log("Topping 3 is correct");
            }
            else
            {
                Debug.Log("Topping 3 is wrong");
            }

            if (coneResult && scoop1Result && scoop2Result && scoop3Result && sauceResult && toppingResult == true)
            {
                submitResult = true;
                Debug.Log("SUCCESS");
            }
            else
            {
                Debug.Log("FAIL");
            }
        }

        //LEVEL 3 CHECKS - 5 Scoops
        if (levelManager.LevelsEnum == LevelsEnum.STATE_LEVEL3)
        {

            if (string.Compare(orderCone, buildConeRend.sprite.name) == 0)
            {
                coneResult = true;
                Debug.Log("Cone is correct");
            }
            else
            {
                Debug.Log("Cone is wrong");
            }

            if (string.Compare(orderIceCream1, scoop1Rend.sprite.name) == 0)
            {
                scoop1Result = true;
                Debug.Log("Scoop 1 is correct");
            }
            else
            {
                Debug.Log("Scoop 1 is wrong");
            }

            if (string.Compare(orderIceCream2, scoop2Rend.sprite.name) == 0)
            {
                scoop2Result = true;
                Debug.Log("Scoop 2 is correct!");
            }
            else
            {
                Debug.Log("Scoop 2 is wrong");
            }

            if (string.Compare(orderIceCream3, scoop3Rend.sprite.name) == 0)
            {
                scoop3Result = true;
                Debug.Log("Scoop 3 is correct!");
            }
            else
            {
                Debug.Log("Scoop 3 is wrong");
            }

            if (string.Compare(orderIceCream4, scoop4Rend.sprite.name) == 0)
            {
                scoop4Result = true;
                Debug.Log("Scoop 4 is correct!");
            }
            else
            {
                Debug.Log("Scoop 4 is wrong");
            }

            if (string.Compare(orderIceCream5, scoop5Rend.sprite.name) == 0)
            {
                scoop5Result = true;
                Debug.Log("Scoop 5 is correct!");
            }
            else
            {
                Debug.Log("Scoop 5 is wrong");
            }

            if (string.Compare(orderSauce, sauce5Rend.sprite.name) == 0)
            {
                sauceResult = true;
                Debug.Log("Sauce 5 is correct");
            }
            else
            {
                Debug.Log("Sauce 5 is wrong");
            }

            if (string.Compare(orderTopping, topping5Rend.sprite.name) == 0)
            {
                toppingResult = true;
                Debug.Log("Topping 5 is correct");
            }
            else
            {
                Debug.Log("Topping 5 is wrong");
            }

            if (coneResult && scoop1Result && scoop2Result && scoop3Result && scoop4Result && scoop5Result && sauceResult && toppingResult == true)
            {
                submitResult = true;
                Debug.Log("SUCCESS");
            }
            else
            {
                Debug.Log("FAIL");
            }
        }
        }

        //ALL OPTIONS CHECKS 
        if (levelManager.LevelsEnum != LevelsEnum.STATE_START && levelManager.LevelsEnum != LevelsEnum.STATE_END)
        {
            if (buildConeRend.sprite == null)
                {
                    Debug.Log("Missing a cone!");
                }
            else if (string.Compare(orderCone, buildConeRend.sprite.name) == 0)
                {
                    coneResult = true;
                    Debug.Log("Cone is correct");
                }
                else
                {
                    Debug.Log("Cone is wrong");
                }


            if (scoop1Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderIceCream1, scoop1Rend.sprite.name) == 0)
                {
                    scoop1Result = true;
                    Debug.Log("Scoop 1 is correct");
                }
                else
                {
                    Debug.Log("Scoop 1 is wrong");
                }

            if (scoop2Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderIceCream2, scoop2Rend.sprite.name) == 0)
                {
                    scoop2Result = true;
                    Debug.Log("Scoop 2 is correct!");
                }
                else
                {
                    Debug.Log("Scoop 2 is wrong");
                }

            if (scoop3Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderIceCream3, scoop3Rend.sprite.name) == 0)
                {
                    scoop3Result = true;
                    Debug.Log("Scoop 3 is correct!");
                }
                else
                {
                    Debug.Log("Scoop 3 is wrong");
                }

            if (scoop4Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderIceCream4, scoop4Rend.sprite.name) == 0)
                {
                    scoop4Result = true;
                    Debug.Log("Scoop 4 is correct!");
                }
                else
                {
                    Debug.Log("Scoop 4 is wrong");
                }

            if (scoop5Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderIceCream5, scoop5Rend.sprite.name) == 0)
                {
                    scoop5Result = true;
                    Debug.Log("Scoop 5 is correct!");
                }
                else
                {
                    Debug.Log("Scoop 5 is wrong");
                }

            if (sauce5Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderSauce, sauce5Rend.sprite.name) == 0)
                {
                    sauceResult = true;
                    Debug.Log("Sauce 5 is correct");
                }
                else
                {
                    Debug.Log("Sauce 5 is wrong");
                }

            if (topping5Rend.sprite == null)
                {
                    Debug.Log("Missing a scoop!");
                }
            else if (string.Compare(orderTopping, topping5Rend.sprite.name) == 0)
                {
                    toppingResult = true;
                    Debug.Log("Topping 5 is correct");
                }
                else
                {
                    Debug.Log("Topping 5 is wrong");
                }

            if (coneResult && scoop1Result && scoop2Result && scoop3Result && scoop4Result && scoop5Result && sauceResult && toppingResult == true)
            {
                submitResult = true;
                Debug.Log("SUCCESS");
            }
            else
            {
                Debug.Log("FAIL");
            }
        }
    }

    IEnumerator Wait (orderEnum state, float waitFor)
    {
        yield return new WaitForSeconds(waitFor);
        orderEnum = state;
    }
   

}

