using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Creates Trigger for UI Messages
    //Turn off UI element in inspector to set up

    public GameObject noConeMsg;
    public GameObject tmToppingsMsg;
    public GameObject tmScoopsMsg;

    public bool errorMsgVisble = false;

    //on update check if the other error msgs are active
    //make coroutine that pops it up for a few seconds when triggered - only if other error msgs are inactive

    private void Update()
    {
        if (noConeMsg.activeSelf == true || tmToppingsMsg.activeSelf == true || tmScoopsMsg.activeSelf == true)
        {
            errorMsgVisble = true;
        }
        else
        {
            errorMsgVisble = false;
        }
    }

    public IEnumerator ShortPopUp(GameObject UItarget)
    {
        tmScoopsMsg.SetActive(false);
        tmToppingsMsg.SetActive(false);
        noConeMsg.SetActive(false);
        UItarget.SetActive(true);
        yield return new WaitForSeconds(2f);
        UItarget.SetActive(false);
    }
}
