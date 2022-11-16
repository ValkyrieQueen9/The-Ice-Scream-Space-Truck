using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum testEnum
{
    STATE_TEST1,
    STATE_TEST2,
    STATE_TEST3
}

public enum shutterEnum
{
    STATE_GAME_START,
    STATE_CLOSED,
    STATE_OPENING,
    STATE_OPENED,
    STATE_CLOSING
    
    //STATE_GAME_END
}

public class TestScript : MonoBehaviour
{
    public shutterEnum shutterEnum;
    public GameObject shutterOpen;
    public GameObject shutterClosed;
    public GameObject shutter;
    public float shutterSpeed = 5f;
    public bool nextCustomer = false;

    public testEnum testEnum;
    public bool testBool = false;

    private void Update()
    {

        switch (testEnum)
        {
            case testEnum.STATE_TEST1:
                Debug.Log("Test1 State");

                break;
            case testEnum.STATE_TEST2:
                Debug.Log("Test2 State");

                break;
            case testEnum.STATE_TEST3:
                Debug.Log("Test3 State");

                break;
            default:
                break;
        }
        if(testBool)
        {
            testEnum = testEnum.STATE_TEST1;
        }


        NewOrder();


    }

    private bool ShutterOpened()
    {
        return shutter.transform.position == shutterOpen.transform.position;
    }

    private bool ShutterClosed()
    {
        return shutter.transform.position == shutterClosed.transform.position;
    }

    private void NewOrder()
    {
        switch (shutterEnum)
        {   
           case shutterEnum.STATE_GAME_START:
                //BEGIN GAME HERE
                shutter.transform.position = shutterClosed.transform.position;

                break;
            case shutterEnum.STATE_CLOSED:
                //change customer sprites
                //begin game like this
                //begin button over shutter?
                Debug.Log("Shutter is Closed");
                if (nextCustomer)
                {
                    shutterEnum = shutterEnum.STATE_OPENING;
                }

                break;
            case shutterEnum.STATE_OPENING:
                //randomise ingredients
                nextCustomer = false;
                shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, shutterOpen.transform.position, shutterSpeed * Time.deltaTime);
                Debug.Log("Shutter Opening");
                Debug.Log("Randomising Ingredients...");
                if (ShutterOpened())
                {
                    shutterEnum = shutterEnum.STATE_OPENED;
                }
                break;

            case shutterEnum.STATE_OPENED:
                Debug.Log("Shutter Opened");
                Debug.Log("New Order ready!");
                //trigger new order on ticket
                //State on start - for now
                if(nextCustomer)
                {
                    shutterEnum = shutterEnum.STATE_CLOSING;
                }

                break;
            case shutterEnum.STATE_CLOSING:
                nextCustomer = false;
                shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, shutterClosed.transform.position, shutterSpeed * Time.deltaTime);
                Debug.Log("Shutter Closing");
                if(ShutterClosed())
                {
                    shutterEnum = shutterEnum.STATE_CLOSED;
                }

                break;
 
            default:
                break;
        }
    }
}

