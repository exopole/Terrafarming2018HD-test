using UnityEngine;

public class ActionMenuPlayerState : StateMachineBehaviour
{
    public bool isInterruptWhenMove = false;
    public AnimeParameters stateEnd;
    private PlayerMenuController player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        player = MainMenuManager.instance.player;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (isInterruptWhenMove && isPlayerMoving())
        {
            animator.SetBool(AnimeParameters.iswalking.ToString(), true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool(stateEnd.ToString(), false);
    }

    public bool isPlayerMoving()
    {
        return player.targetMove;
    }
}