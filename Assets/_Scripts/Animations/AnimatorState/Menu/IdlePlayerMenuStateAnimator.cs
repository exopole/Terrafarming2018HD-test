using UnityEngine;

public class IdlePlayerMenuStateAnimator : PlayerMenuStateAnimator
{

    public bool doAction;
    public AnimeParameters animeAction;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (isPlayerMoving())
        {
            SwitchAnime(AnimeParameters.iswalking, true);
        }
        else
        {
            SwitchAnime(AnimeParameters.iswalking, false);
        }


    }

    public void DoAction()
    {
        SwitchAnime(AnimeParameters.isplanting, true);
    }
}