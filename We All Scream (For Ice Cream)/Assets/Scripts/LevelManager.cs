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
    STATE_TUTORIAL, //Blue swipe across with images and arrows/next/continue buttons
    STATE_FADE,
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
    public int levelTracker = 0; //0 is menu, 1 is tutorial, 2 is level 1, 3 is level 2, 4 is score, 5 is end
    public int test = 0;
    public int fadeRunOnce = 0;
    public bool gameplayActive = false;
    public GameObject mainMenu;
    public Transitions transitions;
    public GameObject submitButton;
    public GameObject beginGameButton;
    public GameObject ingredientButtons;
    public CustomerOrders_ customerOrders;
    public GameObject[] gameplayButtons;


    void Start()
    {
        fadeRunOnce = 0;
        levelNumber.text = "0";
        LevelsEnum = LevelsEnum.STATE_MENU;
        mainMenu.SetActive(true);
        gameplayButtons = GameObject.FindGameObjectsWithTag("Gameplay Buttons");
    }


    void Update()
    {                
        if(test == 2)
                {
                    LevelsEnum = LevelsEnum.STATE_FADE;
                }
        Debug.Log("Level tracker = " + levelTracker);
        switch (LevelsEnum)
        {
            //Beginning State
            case LevelsEnum.STATE_MENU:
                levelTracker = 0;
                mainMenu.SetActive(true);
                levelNumber.text = "M";
                gameplayActive = false;

                //Game is started from Buttons
                //Create Sound bar - audio manager needed first
               
                break;

            //Triggered from Start button using startGame() method 
            case LevelsEnum.STATE_TUTORIAL:
                levelTracker = 1;
                mainMenu.SetActive(false);
                levelNumber.text = "T";

                //Move in swipe panel with instructions
                //show arrows for next back slides
                //use methods for each page of instructions - showTut1() - deactivate current strip and activate correct

                break;

            case LevelsEnum.STATE_FADE:
                //If statements might not work? Try make into method

                if(fadeRunOnce == 0 )
                {
                    transitions.FadeOut();
                    fadeRunOnce += 1;
                }

                if(transitions.fadeOutComplete) 
                    {
                    if (levelTracker == 0) //If on start menu, go to tutorial
                        {
                            LevelsEnum = LevelsEnum.STATE_TUTORIAL;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                            Debug.Log("State is now Tutorial");
                        }
                    if (levelTracker == 1) //If on tutorial, go to level 1
                        {
                            LevelsEnum = LevelsEnum.STATE_LEVEL1;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 2) //If on level 1, go to level 2
                        {
                            LevelsEnum = LevelsEnum.STATE_LEVEL2;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 3) //If on level 2, go to score
                        {
                            LevelsEnum = LevelsEnum.STATE_END;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 4) //If on score, go to end
                        {
                            LevelsEnum = LevelsEnum.STATE_TUTORIAL;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 5) //If on end, go to main menu
                        {
                            LevelsEnum = LevelsEnum.STATE_TUTORIAL;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker >= 100) //If on any level, go to start (pause menu exit?)
                        {
                            LevelsEnum = LevelsEnum.STATE_MENU;
                            transitions.fadeOutComplete = false;
                            fadeRunOnce = 0;
                        }
                    transitions.FadeIn();
                    //Debug.Log("Fade In triggered");
                    }


                break;

            case LevelsEnum.STATE_START:
                levelNumber.text = "0";
                gameplayActive = true; //need to put somewhere without loop
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
        LevelsEnum = LevelsEnum.STATE_FADE;
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Application...");
        Application.Quit();
    }

    public void DisableGameButtons()
    {
        //stops ingredient buttons from being used on main menu
        foreach(GameObject gameplayButton in gameplayButtons)
            {
            gameplayButton.SetActive(false);
            Debug.Log("All buttons are disabled");
            }
    }

    public void EnableGameButtons()
    {
        //renables buttons for gameplay
        foreach (GameObject gameplayButton in gameplayButtons)
        {
            gameplayButton.SetActive(true);
            Debug.Log("Most buttons are enabled!");
        }
    }

    public void Pause()
    {
        gameplayActive = false;
        DisableGameButtons();
        Debug.Log("Game test paused");
    }

    public void Play()
    {
        gameplayActive = true;
        EnableGameButtons();
        Debug.Log("Game test UNpaused");
    }
}
