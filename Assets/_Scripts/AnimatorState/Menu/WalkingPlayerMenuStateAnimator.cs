using UnityEngine;

public class WalkingPlayerMenuStateAnimator : IdlePlayerMenuStateAnimator
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (!isPlayerMoving())
        {
            SwitchAnime(AnimeParameters.iswalking, false);
        }
    }
}