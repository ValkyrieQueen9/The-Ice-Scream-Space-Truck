using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public GameObject videoCanvas;
    public GameObject Lvl1LoadingScreen;
    public GameObject Lvl2LoadingScreen;
    public Animator animator;
    public bool fadeComplete = false;
    public bool fadeOutComplete = false;
    public bool fadeInComplete = false;

    private void Start()
    {
        videoCanvas.SetActive(false);
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        videoCanvas.SetActive(false);
        animator.SetTrigger("FadeIn");
    }

    public void FadeComplete()
    {
        fadeComplete = true;
    }

    public void FadeOutCompleteTrig()
    {
        fadeOutComplete = true;
        fadeInComplete = false;
    }

    public void FadeInCompleteTrig()
    {
        fadeInComplete = true;
        fadeOutComplete = false;
    }

    public IEnumerator LoadingScreen(GameObject levelLoading)
    {
        if(fadeOutComplete)
        {
                videoCanvas.SetActive(true);
            if (levelLoading.name == "Lvl1LS")
            {
                Debug.Log("Activating video Canvas");
                Lvl2LoadingScreen.SetActive(false);
            }
            if (levelLoading.name == "Lvl2LS")
            {
                videoCanvas.SetActive(true);
                Lvl1LoadingScreen.SetActive(false);
            }
            Debug.Log("Loading Screen CoRoutine called");
            levelLoading.SetActive(true);
            yield return new WaitForSeconds(5f);
            levelLoading.SetActive(false);
            FadeIn();
        }
    }

}
