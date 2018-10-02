using UnityEngine;

public class IdlePlayerStateAnimator1 : PlayerStateAnimator1
{

    public bool doAction;
    public AnimeParameters animeAction;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        controller.canDoAction = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (doAction && Input.GetKeyDown(CustomInputManager.instance.actionKey))
        {
            DoAction();
        }
        if (isPlayerMoving())
        {
            SwitchAnime(AnimeParameters.iswalking, true);
        }
        else
        {
            SwitchAnime(AnimeParameters.iswalking, false);
        }

        if (Input.GetKeyDown(CustomInputManager.instance.jumpKey))
        {
            SwitchAnime(AnimeParameters.isjumping, true);
            controller.canDoAction = false;
        }

        if (!controller.IsGrounded && controller.Cc.velocity.y <= 0)
        {
            SwitchAnime(AnimeParameters.isfalling, true);
            controller.canDoAction = false;
        }

    }

    public void DoAction()
    {
        SwitchAnime(AnimeParameters.isplanting, true);
    }
}