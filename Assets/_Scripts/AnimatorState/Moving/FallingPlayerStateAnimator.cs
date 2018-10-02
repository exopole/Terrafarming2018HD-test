using UnityEngine;

public class FallingPlayerStateAnimator : PlayerStateAnimator
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (controller.IsGrounded)
        {
            SwitchAnime(AnimeParameters.islanding, true);
        }
        else
        {
            if (Input.GetKey(CustomInputManager.instance.jumpKey) )
                if(controller.JetPack.CanBoost())
                    SwitchAnime(AnimeParameters.isjumping, true);
                else if(controller.JetPack.CanFly())
                    SwitchAnime(AnimeParameters.isflying, true);

        }
    }
}