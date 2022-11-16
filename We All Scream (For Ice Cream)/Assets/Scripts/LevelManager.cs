using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelsEnum
{
    STATE_START,
    STATE_LEVEL1,
    STATE_LEVEL2,
    STATE_LEVEL3,
    STATE_END
}

public class LevelManager : MonoBehaviour
{
    public LevelsEnum LevelsEnum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (LevelsEnum)
        {
            case LevelsEnum.STATE_START:
                break;
            case LevelsEnum.STATE_LEVEL1:
                break;
            case LevelsEnum.STATE_LEVEL2:
                break;
            case LevelsEnum.STATE_LEVEL3:
                break;
            case LevelsEnum.STATE_END:
                break;
            default:
                break;
        }
    }
}
