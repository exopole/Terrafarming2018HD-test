using UnityEngine;

public class DecollagePlayerStateAnimator : IdlePlayerStateAnimator
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (controller.canDoAction )
        {
            SwitchAnime(AnimeParameters.isjumping, false);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

        if (Input.GetKeyDown(CustomInputManager.instance.jumpKey))
            controller.usingJetPack = true;
    }
}