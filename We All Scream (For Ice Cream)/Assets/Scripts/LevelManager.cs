using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//SCRIPT PURPOSE:
//To change to different levels
//Required:
//Timer, scores Reset
//Complete reset for builder, sprites etc
//Change state

public enum LevelsEnum
{
    STATE_MENU,
    STATE_TUTORIAL,
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
    public bool gameplayActive = false;
    public bool levelTimesUp = false;
    public bool popUpComplete = false;
    public bool nextDayTriggered = false;
    public int levelTracker = 0; //0 is menu, 1 is tutorial, 2 is level 1, 3 is level 2, 4 is score, 5 is end
    public int level1OrderCount = 0;
    public int level2OrderCount = 0;
    public float bannerSpeed;

    public TextMeshProUGUI levelNumber;
    public Transitions transitions;
    public CustomerOrders_ customerOrders;
    public Timer timer;

    public GameObject mainMenu;
    public GameObject submitButton;
    public GameObject beginGameButton;
    public GameObject ingredientButtons;
    public GameObject tutorialEmpty, tutorialBGShade, tutorialBanner, tutorialNext, tutorialWords;
    //public GameObject tutorialBack;
    public GameObject scorePanel, scoreBGShade, scoreBanner ,scoreNext ,scoreText, scoreLevelText, scoreOrderNum;

    private int nextLevel = 0;
    private int fadeRunOnce = 0;
    private Vector3 bannerOffScreen, bannerOnScreen, bannerOffScreenRight;
    private SpriteRenderer tutorialBGShadeRend;
    private GameObject[] gameplayButtons;

    void Start()
    {
        fadeRunOnce = 0;
        levelNumber.text = "0";
        LevelsEnum = LevelsEnum.STATE_MENU;
        bannerOffScreen = new Vector3(-39, 0);
        bannerOnScreen = new Vector3(0,0);
        bannerOffScreenRight = new Vector3(39, 0);
        tutorialBanner.transform.position = bannerOffScreen;
        scoreBanner.transform.position = bannerOffScreen;
        tutorialEmpty.SetActive(false);
        scorePanel.SetActive(false);
        mainMenu.SetActive(true);
        gameplayButtons = GameObject.FindGameObjectsWithTag("Gameplay Buttons");
        tutorialBGShadeRend = tutorialBGShade.GetComponent<SpriteRenderer>();
    }


    void Update()
    {             
        if(gameplayActive == false)
        {
            timer.runTimer = false;
        }

        Debug.Log("Level tracker = " + levelTracker);
        switch (LevelsEnum)
        {
            case LevelsEnum.STATE_MENU:
                levelTracker = 0;
                level1OrderCount = 0;
                level2OrderCount = 0;
                levelNumber.text = "M";
                mainMenu.SetActive(true);
                gameplayActive = false;
                nextDayTriggered = false;
                DisableGameButtons();
                //Create Sound bar - audio manager needed first
               
                break;

            //Triggered from Start button using startGame() method 
            case LevelsEnum.STATE_TUTORIAL:
                levelTracker = 1;
                levelNumber.text = "T";
                nextLevel = 1;
                mainMenu.SetActive(false);
                tutorialEmpty.SetActive(true);
                tutorialNext.SetActive(false);
                tutorialWords.SetActive(false);

                if (transitions.fadeInComplete)
                    {
                    tutorialBanner.transform.position = Vector3.MoveTowards(tutorialBanner.transform.position, bannerOnScreen, bannerSpeed * Time.deltaTime);
                    if (tutorialBanner.transform.position == bannerOnScreen)
                    {
                        tutorialNext.SetActive(true);
                        tutorialWords.SetActive(true);

                        //Appear Text
                    }
                }
                //show arrows for next back slides
                //if next button clicked appear new instructions
                //use methods for each page of instructions - showTut1() - deactivate current strip and activate correct
                //if last continue button clicked, move banner back to starting pos and fade out BG using Alpha colour setting

                break;

            case LevelsEnum.STATE_FADE:
                transitions.fadeInComplete = false;

                if(fadeRunOnce == 0 )
                {

                    transitions.FadeOut();
                    fadeRunOnce += 1;
                }
                
                //NEEDS ATTENTION!
                if(transitions.fadeOutComplete) 
                    {
                    if (levelTracker == 0) //If on start menu, go to tutorial
                        {
                            LevelsEnum = LevelsEnum.STATE_TUTORIAL;
                            fadeRunOnce = 0;
                            Debug.Log("State is now Tutorial");
                        }
                    if (levelTracker == 1) //If on tutorial, go to level 1
                        {
                            LevelsEnum = LevelsEnum.STATE_LEVEL1;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 2) //If on level 1, go to score
                        {
                            LevelsEnum = LevelsEnum.STATE_SCORE;
                            customerOrders.orderCount = 0;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 3) //If on score, go to level 2
                        {
                            LevelsEnum = LevelsEnum.STATE_LEVEL2;
                            customerOrders.orderCount = 0;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 4) //If on score, go to next level - will need tweaking when new levels added
                        {
                            LevelsEnum = LevelsEnum.STATE_LEVEL2;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker == 5) //If on end, go to main menu
                        {
                            LevelsEnum = LevelsEnum.STATE_MENU;
                            fadeRunOnce = 0;
                        }
                    if (levelTracker >= 100) //If on any level, go to start (pause menu exit?)
                        {
                            LevelsEnum = LevelsEnum.STATE_MENU;
                            fadeRunOnce = 0;
                        }
                    transitions.FadeIn();
                    }

                break;

            case LevelsEnum.STATE_START:
                levelNumber.text = "0";

                if(tutorialBanner.activeSelf)
                {
                    tutorialBanner.transform.position = Vector3.MoveTowards(tutorialBanner.transform.position, bannerOffScreen, bannerSpeed * Time.deltaTime);
                    tutorialBGShadeRend.color = new Color (0,0,0,0);
                    tutorialNext.SetActive(false);
                    tutorialWords.SetActive(false);
                }
                if(tutorialBanner.transform.position == bannerOffScreen)
                {
                    tutorialEmpty.SetActive(false);
                }


                break;

            case LevelsEnum.STATE_LEVEL1:
                levelTracker = 2;
                levelNumber.text = "1";
                nextLevel = 2;
                if(timer.secondsLeft <= 0)
                {
                    Debug.Log("Level 1 Times Up!");
                    timer.runTimer = false;
                    TimesUp();
                    level1OrderCount = customerOrders.orderCount;
                }

                break;

            case LevelsEnum.STATE_LEVEL2:
                levelTracker = 3;
                levelNumber.text = "2";
                nextLevel = 3;
                timer.runTimer = true;
                if (timer.secondsLeft <= 0)
                {
                    Debug.Log("Level 2 Times Up!");
                    TimesUp();
                    level2OrderCount = customerOrders.orderCount;
                }

                break;

            case LevelsEnum.STATE_LEVEL3:
                levelNumber.text = "3";
                //IGNORE FOR NOW

                break;

            case LevelsEnum.STATE_SCORE:

                if (nextDayTriggered == false)
                {

                    if (customerOrders.ShutterClosed())
                    {
                        scorePanel.SetActive(true);
                        scoreNext.SetActive(false);
                        scoreText.SetActive(false);
                        scoreLevelText.SetActive(false);
                        scoreOrderNum.SetActive(false);
                        scoreBanner.transform.position = Vector3.MoveTowards(scoreBanner.transform.position, bannerOnScreen, bannerSpeed * Time.deltaTime);
                        if (scoreBanner.transform.position == bannerOnScreen)
                        {
                            if (nextLevel == 2)
                            {
                                ScoreShow(level1OrderCount);
                            }
                            if (nextLevel == 3)
                            {
                                ScoreShow(level2OrderCount);
                            }
                            scoreText.SetActive(true);
                            scoreLevelText.SetActive(true);
                            scoreNext.SetActive(true);
                            scoreOrderNum.SetActive(true);
                        }
                        levelNumber.text = "S";
                        levelTracker = 4;

                    }

                }
                else if (nextDayTriggered && scoreBanner.activeSelf)
                        {
                            Debug.Log("Next Day Triggered");
                            scoreBanner.transform.position = Vector3.MoveTowards(scoreBanner.transform.position, bannerOffScreenRight, bannerSpeed * Time.deltaTime);
                            scoreBGShade.SetActive(false);
                            scoreNext.SetActive(false);
                            scoreText.SetActive(false);
                            scoreLevelText.SetActive(false);
                            scoreOrderNum.SetActive(false);
                        }
                        if (scoreBanner.transform.position == bannerOffScreenRight)
                        {
                            scorePanel.SetActive(false);
                            if (nextLevel == 2)
                            {
                                nextDayTriggered = false;
                                LevelsEnum = LevelsEnum.STATE_LEVEL2;
                            }
                            if (nextLevel == 3)
                            {
                                nextDayTriggered = false;
                                LevelsEnum = LevelsEnum.STATE_LEVEL3;
                            }
                        }

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

    public void TutorialNext()
    {
        transitions.fadeInComplete = false;
        gameplayActive = true;
        LevelsEnum = LevelsEnum.STATE_START;
    }

    public void NextDay()
    {
        nextDayTriggered = true;
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
        timer.runTimer = false;
        gameplayActive = false;
        DisableGameButtons();
        Debug.Log("Game test paused");
    }

    public void Play()
    {
        timer.runTimer = true;
        EnableGameButtons();
        Debug.Log("Game PLAYING");
        if (nextLevel == 1)
        {
            LevelsEnum = LevelsEnum.STATE_LEVEL1;
        }
        if (nextLevel == 2)
        {
            LevelsEnum = LevelsEnum.STATE_LEVEL2;
        }
        if (nextLevel == 3)
        {
            LevelsEnum = LevelsEnum.STATE_LEVEL3;
        }
    }

    public void TimesUp()
    {
        Debug.Log("TimesUp called");

        timer.runTimer = false;
        levelTimesUp = true;
        gameplayActive = false;
        submitButton.SetActive(false);
        DisableGameButtons();
        //Trigger sound

        //if (sound is finished?
    
        customerOrders.orderEnum = orderEnum.STATE_CLOSING;

        if (customerOrders.ShutterClosed())
        {
            timer.ResetTimer();
            LevelsEnum = LevelsEnum.STATE_SCORE;
        }
    }

    public void ScoreShow(int orderCount)
    {
        scoreOrderNum.GetComponent<TextMeshProUGUI>().text = orderCount.ToString();
    }

}
