using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//SCRIPT PURPOSE:
//To change to different levels
//Required:
//Change of background
//Enable/Disable ingredient buttons
//Timer, scores Reset
//Complete reset for builder, sprites etc
//Change state
//Fade to black transition? - Use a state?
//Show Level number in corner - mainly for Debugging
//Use this script to trigger bossevent method in Customer Orders

public enum LevelsEnum
{
    STATE_MENU, //Main Menu image and buttons including sound bar
    STATE_FADE, //Fade to black transition - MAKE FADE A SIMPLE COROUTINE?
    STATE_TUTORIAL, //Blue swipe across with images and arrows/next/continue buttons
    STATE_START, //Beginning state of gameplay, Begin button on shutter maybe or not needed? Can be used for countdown too
    STATE_LEVEL1, //Level 1 gameplay, changed when time is up
    STATE_LEVEL2, //Level 2 gameplay- changed when time is up
    STATE_LEVEL3, //Level 2 gameplay- changed when time is up
    STATE_SCORE, //Fades to black and shows successful orders and time when continue is clicked - adds successful orders to total and wipes old order number? Includes total time
    STATE_END, //Fades to end menu with total score and time? 
    STATE_PAUSE //Maybe not necessary? hard to return to previous state?
}

public class LevelManager : MonoBehaviour
{
    public LevelsEnum LevelsEnum;
    public TextMeshProUGUI levelNumber;
    public int levelTracker = 0; //0 is menu, 1 is tutorial, 2 is level 1, 3 is level 2, 4 is end

    public GameObject mainMenu;
    public GameObject customerOrdersObj;
    private CustomerOrders_ customerOrders;
    //int to keep track of level even when using fades and pauses.


    void Start()
    {
        levelNumber.text = "0";
        LevelsEnum = LevelsEnum.STATE_MENU;
        mainMenu.SetActive(true);
        customerOrders = customerOrdersObj.GetComponent<CustomerOrders_>();
    }


    void Update()
    {
        switch (LevelsEnum)
        {
            case LevelsEnum.STATE_MENU:
                levelNumber.text = "M";
                //Game is started from Buttons

                //Create Sound bar
                //Disable ingredient buttons - method to active and deactivate ingredients


                break;

            case LevelsEnum.STATE_FADE:
                //Fade in dark screen 
                //use if statements to move on
                //if levelTracker == 0 then move to tutorial
                //if "" == 2 move to level 1 - number change in tutorial or end of this script
                // if "" == 3 move to level 2

                break;

            case LevelsEnum.STATE_TUTORIAL:
                levelNumber.text = "T";
                //Move in swipe panel with instructions
                //show arrows for next back slides
                //use methods for each page of instructions - showTut1() - deactivate current strip and activate correct

                break;

            case LevelsEnum.STATE_START:
                levelNumber.text = "0";
                //Beginning state of gameplay, Begin button on shutter maybe or not needed? Can be used for countdown too

                break;

            case LevelsEnum.STATE_LEVEL1:
                levelNumber.text = "1";
                //Level 1 gameplay, changed when time is up

                break;

            case LevelsEnum.STATE_LEVEL2:
                levelNumber.text = "2";
                //Level 2 gameplay, changed when time is up

                break;

            case LevelsEnum.STATE_LEVEL3:
                levelNumber.text = "3";
                //IGNORE FOR NOW

                break;

            case LevelsEnum.STATE_SCORE:
                //Fades to black and shows successful orders and time for that level only
                //when continue is clicked - adds successful orders to total and wipes old order number? Does same with timer

                break;

            case LevelsEnum.STATE_END:
                levelNumber.text = "X";
                //Fades to end menu with total score and time?

                break;

            default:
                break;
        }

    }

    public void StartGame()
    {
        LevelsEnum = LevelsEnum.STATE_TUTORIAL;

    }

    public void ExitGame()
    {
        Debug.Log("Exiting Application...");
        Application.Quit();
    }

    IEnumerator shutterTransition()
    {

    }

    public void DisableGameButtons()
    {

    }

    public void EnableGameButtons()
    {

    }
}
