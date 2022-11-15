using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum testEnum
{
    STATE_TEST1,
    STATE_TEST2,
    STATE_TEST3
}

public class TestScript : MonoBehaviour
{

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

    }

}

