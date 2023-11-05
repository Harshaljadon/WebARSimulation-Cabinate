using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimeCall : MonoBehaviour, UserTouchResponseAction
{
    public Animator animator;
    public string animationParameterName;
    bool toggleAnime;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// user touch input to call animation
    /// </summary>
    public void TouchedTriggerRespones()
    {
        toggleAnime = !toggleAnime;
        if (toggleAnime)
        {
            animator.SetBool(animationParameterName, toggleAnime);
        }
        else
        {
            animator.SetBool(animationParameterName, toggleAnime);

        }
    }

}
