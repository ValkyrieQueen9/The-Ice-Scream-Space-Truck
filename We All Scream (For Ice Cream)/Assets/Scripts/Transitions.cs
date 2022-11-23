using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public Animator animator;
    public bool fadeComplete = false;
    public bool fadeOutComplete = false;
    public bool fadeInComplete = false;


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
    }

    public void FadeInCompleteTrig()
    {
        Debug.Log("FadeIn is complete");
        fadeInComplete = true;
    }


}
