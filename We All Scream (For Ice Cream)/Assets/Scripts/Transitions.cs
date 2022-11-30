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


}
