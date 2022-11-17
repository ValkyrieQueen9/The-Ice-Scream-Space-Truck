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
    STATE_START,
    STATE_LEVEL1,
    STATE_LEVEL2,
    STATE_LEVEL3,
    STATE_END
        //STATE_TRANSITION
}

public class LevelManager : MonoBehaviour
{
    public LevelsEnum LevelsEnum;
    public TextMeshProUGUI levelNumber;


    // Start is called before the first frame update
    void Start()
    {
        levelNumber.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        switch (LevelsEnum)
        {
            case LevelsEnum.STATE_START:
                levelNumber.text = "0";

                break;

            case LevelsEnum.STATE_LEVEL1:
                levelNumber.text = "1";


                break;

            case LevelsEnum.STATE_LEVEL2:
                levelNumber.text = "2";

                break;

            case LevelsEnum.STATE_LEVEL3:
                levelNumber.text = "3";

                break;

            case LevelsEnum.STATE_END:
                levelNumber.text = "X";

                break;

            default:
                break;
        }
    }
}
