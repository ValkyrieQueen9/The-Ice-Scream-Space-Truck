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
}

public class LevelManager : MonoBehaviour
{
    public LevelsEnum LevelsEnum;
    public bool gameplayActive = false;
    public bool levelTimesUp = false;
    public bool popUpComplete = false;
    public bool nextDayTriggered = false;
    public bool continueTriggered = false;
    public int levelTracker = 0; //0 is menu, 1 is tutorial, 2 is level 1, 3 is level 2, 4 is score, 5 is end
    public int nextLevel = 0;
    public int level1OrderCount = 0;
    public int level2OrderCount = 0;
    public float scoopPopUpSpeed;
    public float bannerSpeed;

    public TextMeshProUGUI levelNumber;
    public Transitions transitions;
    public CustomerOrders_ customerOrders;
    public Timer timer;
    public AudioManager audioManager;

    public GameObject mainMenu;
    public GameObject submitButton;
    public GameObject beginGameButton;
    public GameObject ingredientButtons;
    public GameObject tutorialEmpty, tutorialBGShade, tutorialBanner, tutorialNext, tutorialBack, tutorialSkip, tutorialContent;
    public GameObject scorePanel, scoreBGShade, scoreBanner, scoreNext, scoreText, scoreLevelText, scoreOrderNum;
    public GameObject scoreScoopsPanel, scoreScoop1, scoreScoop2, scoreScoop3;
    public GameObject endPanel, contButton, endText, endButton;

    private int tutorialPage = 0;
    private int fadeRunOnce = 0;
    private Vector3 bannerOffScreen, bannerOnScreen, bannerOffScreenRight;
    private Sprite tutPage0, tutPage1, tutPage2, tutPage3, tutPage4, tutPage5, tutPage6;
    private Sprite bronzeScoop, silverScoop, goldScoop;
    private SpriteRenderer tutorialBGShadeRend, tutorialContentRend, scoreScoop1Rend, scoreScoop2Rend, scoreScoop3Rend;
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
        endPanel.SetActive(false);
        mainMenu.SetActive(true);
        scoreScoopsPanel.SetActive(false);

        gameplayButtons = GameObject.FindGameObjectsWithTag("Gameplay Buttons");

        tutorialBGShadeRend = tutorialBGShade.GetComponent<SpriteRenderer>();
        tutorialContentRend = tutorialContent.GetComponent<SpriteRenderer>();
        scoreScoop1Rend = scoreScoop1.GetComponent<SpriteRenderer>();
        scoreScoop2Rend = scoreScoop2.GetComponent<SpriteRenderer>();
        scoreScoop3Rend = scoreScoop3.GetComponent<SpriteRenderer>();

        bronzeScoop = Resources.Load<Sprite>("score/bronzeScoop");
        silverScoop = Resources.Load<Sprite>("score/silverScoop");
        goldScoop = Resources.Load<Sprite>("score/goldScoop");

        tutPage0 = Resources.Load<Sprite>("tutorial/tutPage0");
        tutPage1 = Resources.Load<Sprite>("tutorial/tutPage1");
        tutPage2 = Resources.Load<Sprite>("tutorial/tutPage2");
        tutPage3 = Resources.Load<Sprite>("tutorial/tutPage3");
        tutPage4 = Resources.Load<Sprite>("tutorial/tutPage4");
        tutPage5 = Resources.Load<Sprite>("tutorial/tutPage5");
        tutPage6 = Resources.Load<Sprite>("tutorial/tutPage6");

    }


    void Update()
    {             
        if(gameplayActive == false)
        {
            timer.runTimer = false;
        }

        switch (LevelsEnum)
        {
            case LevelsEnum.STATE_MENU:
                levelTracker = 0;
                level1OrderCount = 0;
                level2OrderCount = 0;
                tutorialPage = 0;
                nextLevel = 1;
                levelNumber.text = "M";
                mainMenu.SetActive(true);
                gameplayActive = false;
                nextDayTriggered = false;
                tutorialContentRend.sprite = tutPage0;
                scoreBanner.transform.position = bannerOffScreen;
                DisableGameButtons();
               
                break;

            //Triggered from Start button using startGame() method 
            case LevelsEnum.STATE_TUTORIAL:
                levelTracker = 1;
                levelNumber.text = "T";
                nextLevel = 1;
                tutorialBanner.transform.position = bannerOnScreen;

                mainMenu.SetActive(false);
                tutorialEmpty.SetActive(true);
                tutorialNext.SetActive(true);
                tutorialSkip.SetActive(true);
                tutorialContent.SetActive(true);

                if (tutorialPage >= 1)
                {
                    tutorialBack.SetActive(true);
                }
                else tutorialBack.SetActive(false);

                //Tutorial Next switches pages

                break;

            case LevelsEnum.STATE_FADE:
                transitions.fadeInComplete = false;

                if(fadeRunOnce == 0 )
                {
                    transitions.FadeOut();
                    fadeRunOnce += 1;
                }

                if (transitions.fadeOutComplete)
                {
                    if (nextLevel == 1)
                    {
                        LevelsEnum = LevelsEnum.STATE_TUTORIAL;
                        fadeRunOnce = 0;
                        StartCoroutine(transitions.LoadingScreen(transitions.Lvl1LoadingScreen));
                    }

                    if (nextLevel == 2)
                    {
                        LevelsEnum = LevelsEnum.STATE_START;
                        customerOrders.orderCount = 0;
                        fadeRunOnce = 0;
                        StartCoroutine(transitions.LoadingScreen(transitions.Lvl2LoadingScreen));
                    }

                    if(nextLevel == 0)
                    {
                        LevelsEnum = LevelsEnum.STATE_MENU;
                        fadeRunOnce = 0;
                        transitions.FadeIn();
                    }

                }
                break;

            case LevelsEnum.STATE_START:
                levelNumber.text = "0";
                if(tutorialBanner.activeSelf)
                {
                    tutorialBanner.transform.position = Vector3.MoveTowards(tutorialBanner.transform.position, bannerOffScreenRight, bannerSpeed * Time.deltaTime);
                    tutorialBGShadeRend.color = new Color (0,0,0,0);
                    tutorialNext.SetActive(false);
                    tutorialBack.SetActive(false);
                    tutorialSkip.SetActive(false);
                    tutorialContent.SetActive(false);
                }
                if(tutorialBanner.transform.position == bannerOffScreenRight)
                {
                    gameplayActive = true;
                    tutorialEmpty.SetActive(false);
                }

                if(scoreBanner.activeSelf)
                {
                     Debug.Log("Next Day Triggered");
                     scoreBanner.transform.position = Vector3.MoveTowards(scoreBanner.transform.position, bannerOffScreenRight, bannerSpeed * Time.deltaTime);
                     scoreBGShade.SetActive(false);
                     scoreNext.SetActive(false);
                     scoreText.SetActive(false);
                     scoreLevelText.SetActive(false);
                     scoreOrderNum.SetActive(false);
                     ResetScoreScoops();
                }
                if(scoreBanner.transform.position == bannerOffScreenRight)
                {
                     scorePanel.SetActive(false);
                }

                if(customerOrders.beginGame)
                {
                     if (nextLevel == 2)
                     {
                           nextDayTriggered = false;
                           LevelsEnum = LevelsEnum.STATE_FADE;
                     }
                     if (nextLevel == 3)
                     {
                           nextDayTriggered = false;
                           LevelsEnum = LevelsEnum.STATE_LEVEL3;
                     }
                }

                break;

            case LevelsEnum.STATE_LEVEL1:
                levelTracker = 2;
                levelNumber.text = "1";
                nextLevel = 2;
                scoreBanner.transform.position = bannerOffScreen;
                if(timer.secondsLeft <= 0)
                {
                    Debug.Log("Level 1 Times Up!");
                    TimesUp();
                    gameplayActive = false;
                    level1OrderCount = customerOrders.orderCount;
                }

                break;

            case LevelsEnum.STATE_LEVEL2:
                levelTracker = 3;
                levelNumber.text = "2";
                nextLevel = 5;
                scoreBanner.transform.position = bannerOffScreen;

                if (timer.secondsLeft <= 0)
                {
                    Debug.Log("Level 2 Times Up!");
                    TimesUp();
                    gameplayActive = false;
                    level2OrderCount = customerOrders.orderCount;
                }

                break;

            case LevelsEnum.STATE_LEVEL3:
                levelNumber.text = "3";
                //IGNORE FOR NOW

                break;

            case LevelsEnum.STATE_SCORE:
                
                if (nextDayTriggered == false && audioManager.TimesUpFinished == true)
                {
                    gameplayActive = false;
                    if (customerOrders.ShutterClosed())
                    {
                        scorePanel.SetActive(true);
                        scoreNext.SetActive(false);
                        scoreText.SetActive(false);
                        scoreLevelText.SetActive(false);
                        scoreOrderNum.SetActive(false);
                        if (scoreBanner.activeSelf)
                        {
                        scoreBanner.transform.position = Vector3.MoveTowards(scoreBanner.transform.position, bannerOnScreen, bannerSpeed * Time.deltaTime);
                        }

                        if (scoreBanner.transform.position == bannerOnScreen)
                        {
                            if (nextLevel == 2)
                            {
                                ScoreShow(level1OrderCount);
                                scoreScoopsPanel.SetActive(true);
                                StartCoroutine(scoreResultPopUp(level1OrderCount));
                                scoreLevelText.GetComponent<TextMeshProUGUI>().text = "DAY 1 COMPLETE!".ToString();
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

                //when continue is clicked - adds successful orders to total and wipes old order number? Does same with timer

                break;

            case LevelsEnum.STATE_END:

                gameplayActive = false;
                levelTimesUp = false;

                if (customerOrders.ShutterClosed() && continueTriggered == false)
                {
                    scorePanel.SetActive(true);
                    contButton.SetActive(false);
                    scoreText.SetActive(false);
                    scoreLevelText.SetActive(false);
                    scoreOrderNum.SetActive(false);
                    if (scoreBanner.activeSelf)
                    {
                        scoreBanner.transform.position = Vector3.MoveTowards(scoreBanner.transform.position, bannerOnScreen, bannerSpeed * Time.deltaTime);
                    }

                    if (scoreBanner.transform.position == bannerOnScreen)
                    {
                        scoreLevelText.GetComponent<TextMeshProUGUI>().text = "DAY 2 COMPLETE!".ToString();
                        ScoreShow(level2OrderCount);
                        scoreScoopsPanel.SetActive(true);
                        StartCoroutine(scoreResultPopUp(level2OrderCount));

                        scoreText.SetActive(true);
                        scoreLevelText.SetActive(true);
                        scoreOrderNum.SetActive(true);
                        endPanel.SetActive(true);
                        contButton.SetActive(true);
                        endText.SetActive(false);
                        endButton.SetActive(false);
                    }                        
                    nextLevel = 0;
                    levelNumber.text = "X";
                    levelTracker = 5;

                }

                //Fades to end menu with total score and time?

                break;

            default:
                break;
        }

    }


    public void StartGame()
    {
        LevelsEnum = LevelsEnum.STATE_FADE;
        audioManager.PlaySound("ButtonClick");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Application...");
        audioManager.PlaySound("ButtonClick");
        Application.Quit();
    }

    public void TutorialNext()
    {
        audioManager.PlaySound("ButtonClick");

        if (tutorialPage == 0)
        {
            tutorialContentRend.sprite = tutPage1;
            tutorialPage = 1;
        }

        else if (tutorialPage == 1)
        {
            tutorialContentRend.sprite = tutPage2;
            tutorialPage = 2;
        }

        else if (tutorialPage == 2)
        {
            tutorialContentRend.sprite = tutPage3;
            tutorialPage = 3;
        }

        else if (tutorialPage == 3)
        {
            tutorialContentRend.sprite = tutPage4;
            tutorialPage = 4;
        }

        else if (tutorialPage == 4)
        {
            tutorialContentRend.sprite = tutPage5;
            tutorialPage = 5;
        }

        else if (tutorialPage == 5)
        {
            tutorialContentRend.sprite = tutPage6;
            tutorialPage = 6;
        }

        else if (tutorialPage == 6)
        {
            LevelsEnum = LevelsEnum.STATE_START;
            tutorialPage = 0;
        }

    }

    public void TutorialBack()
    {
        audioManager.PlaySound("ButtonClick");

        if (tutorialPage == 1)
        {
            tutorialContentRend.sprite = tutPage0;
            tutorialPage = 0;
        }

        if (tutorialPage == 2)
        {
            tutorialContentRend.sprite = tutPage1;
            tutorialPage = 1;
        }

        else if (tutorialPage == 3)
        {
            tutorialContentRend.sprite = tutPage2;
            tutorialPage = 2;
        }

        else if (tutorialPage == 4)
        {
            tutorialContentRend.sprite = tutPage3;
            tutorialPage = 3;
        }

        else if (tutorialPage == 5)
        {
            tutorialContentRend.sprite = tutPage4;
            tutorialPage = 4;
        }

        else if (tutorialPage == 6)
        {
            tutorialContentRend.sprite = tutPage5;
            tutorialPage = 5;
        }

    }

    public void TutorialSkip()
    {
        audioManager.PlaySound("ButtonClick");
        LevelsEnum = LevelsEnum.STATE_START;
        tutorialPage = 0;
    }

    public void NextDay()
    {
        Debug.Log("Next Day Triggered");
        nextDayTriggered = true;
        gameplayActive = true;
        levelTimesUp = false;
        LevelsEnum = LevelsEnum.STATE_FADE;
        audioManager.PlaySound("ButtonClick");

    }

    public void Continue()
    {
        continueTriggered = true;
        scoreScoopsPanel.SetActive(false);
        contButton.SetActive(false);
        scoreText.SetActive(false);
        scoreLevelText.SetActive(false);
        scoreOrderNum.SetActive(false);
        audioManager.PlaySound("ButtonClick");


        endText.SetActive(true);
        endButton.SetActive(true);
    }
    
    public void RestartGame()
    {
        Debug.Log("Restarting Game...");

        continueTriggered = false;
        LevelsEnum = LevelsEnum.STATE_FADE;
        customerOrders.orderEnum = orderEnum.STATE_GAME_START;
        scorePanel.SetActive(false);
        scoreScoopsPanel.SetActive(false);
        endPanel.SetActive(false);
    }

    public void DisableGameButtons()
    {
        //stops ingredient buttons from being used on main menu
        foreach(GameObject gameplayButton in gameplayButtons)
            {
            gameplayButton.SetActive(false);
            }
    }

    public void EnableGameButtons()
    {
        //renables buttons for gameplay
        foreach (GameObject gameplayButton in gameplayButtons)
        {
            gameplayButton.SetActive(true);
        }
    }

    public void Pause()
    {
        timer.runTimer = false;
        gameplayActive = false;
        DisableGameButtons();
    }

    public void UnPause()
    {
        EnableGameButtons();
        if (LevelsEnum != LevelsEnum.STATE_FADE && LevelsEnum != LevelsEnum.STATE_SCORE && LevelsEnum != LevelsEnum.STATE_TUTORIAL && LevelsEnum != LevelsEnum.STATE_END )
        {
            gameplayActive = true;
            if (LevelsEnum != LevelsEnum.STATE_START)
            {
            timer.runTimer = true;
            }
        }

    }

    public void Play()
    {
        timer.runTimer = true;
        EnableGameButtons();
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
        audioManager.PlaySound("TimesUp");
        timer.runTimer = false;
        levelTimesUp = true;
        submitButton.SetActive(false);
        DisableGameButtons();
        customerOrders.orderEnum = orderEnum.STATE_CLOSING;

        if (customerOrders.ShutterClosed())
        {
            timer.ResetTimer();
            if (nextLevel == 2 || nextLevel == 3)
            {
                LevelsEnum = LevelsEnum.STATE_SCORE;
            }
            else if (nextLevel == 5)
            {
                LevelsEnum = LevelsEnum.STATE_END;
            }

        }
    }

    public void ResetScoreScoops()
    {
        scoreScoop1Rend.sprite = null;
        scoreScoop2Rend.sprite = null;
        scoreScoop3Rend.sprite = null;
        scoreScoopsPanel.SetActive(false);
    }

    public void ScoreShow(int orderCount)
    {
        scoreOrderNum.GetComponent<TextMeshProUGUI>().text = orderCount.ToString();
    }

    IEnumerator scoreResultPopUp(int levelScore)
    { 
            if(levelScore == 0 || levelScore == 1)
                {
                yield return new WaitForSeconds(scoopPopUpSpeed);
                scoreScoop1Rend.sprite = bronzeScoop;
                    yield return new WaitForSeconds(scoopPopUpSpeed);
                    scoreScoop2Rend.sprite = null;
                    yield return new WaitForSeconds(scoopPopUpSpeed);
                    scoreScoop3Rend.sprite = null;
                yield return new WaitForSeconds(scoopPopUpSpeed);
        }

            else if (levelScore == 2 )
                {
                yield return new WaitForSeconds(scoopPopUpSpeed);
                scoreScoop1Rend.sprite = bronzeScoop;
                    yield return new WaitForSeconds(scoopPopUpSpeed);
                    scoreScoop2Rend.sprite = silverScoop;
                    yield return new WaitForSeconds(scoopPopUpSpeed);
                    scoreScoop3Rend.sprite = null;
                yield return new WaitForSeconds(scoopPopUpSpeed);
        }

            else if (levelScore >= 3)
                {
                yield return new WaitForSeconds(scoopPopUpSpeed);
                scoreScoop1Rend.sprite = bronzeScoop;
                    yield return new WaitForSeconds(scoopPopUpSpeed);
                    scoreScoop2Rend.sprite = silverScoop;
                    yield return new WaitForSeconds(scoopPopUpSpeed);
                    scoreScoop3Rend.sprite = goldScoop;
                yield return new WaitForSeconds(scoopPopUpSpeed);
        }
        
    }

}
