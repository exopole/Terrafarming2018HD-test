using UnityEngine;

public class FlyingPlayerStateAnimator : PlayerStateAnimator
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        controller.Fly();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (!Input.GetKey(CustomInputManager.instance.jumpKey)
            || (controller.IsGrounded && !Input.GetKey(CustomInputManager.instance.jumpKey))
            || !controller.JetPack.CanFly())
        {
            SwitchAnime(AnimeParameters.isflying, false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        controller.StopFlying();
    }
}