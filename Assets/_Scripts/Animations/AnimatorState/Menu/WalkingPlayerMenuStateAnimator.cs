using UnityEngine;

public class WalkingPlayerMenuStateAnimator : IdlePlayerMenuStateAnimator
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        controller.behaviour.target = controller.targetMove;
        controller.targetMove = null;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (!isPlayerMoving())
        {
            SwitchAnime(AnimeParameters.iswalking, false);
        }
    }
}