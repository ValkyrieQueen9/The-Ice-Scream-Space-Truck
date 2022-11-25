using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public Animator animator;
    public bool fadeComplete = false;
    public bool fadeOutComplete = false;
    public bool fadeInComplete = false;
    public bool MenuShutterComplete = false;
    public bool CloseMenuShutComplete = false;
    public bool OpenMenuShutComplete = false;

    public void MenuShut()
    {
        animator.SetTrigger("MenuShutter");
    }

    public void MenuShutComplete()
    {
        MenuShutterComplete = true;
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    public void FadeComplete()
    {
        Debug.Log("Fade is complete");
        fadeComplete = true;
    }

    public void FadeOutCompleteTrig()
    {
        Debug.Log("FadeOut is complete");
        fadeOutComplete = true;
        fadeInComplete = false;
    }

    public void FadeInCompleteTrig()
    {
        Debug.Log("FadeIn is complete");
        fadeInComplete = true;
        fadeOutComplete = false;
    }


}
