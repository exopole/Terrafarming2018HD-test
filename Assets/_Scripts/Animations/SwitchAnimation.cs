using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour {

    public AnimeParameters anime;

    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        UtilsAnimation.SwitchAnime(animator, anime, true);
    }

    private void OnTriggerExit(Collider other)
    {
        UtilsAnimation.SwitchAnime(animator, anime, false);
    }
}
