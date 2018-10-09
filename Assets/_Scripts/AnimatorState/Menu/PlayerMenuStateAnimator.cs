using UnityEngine;

public class PlayerMenuStateAnimator : StateMachineBehaviour
{
    #region variables

    protected PlayerMenuController controller;

    #endregion variables

    
    #region Unity methods

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        controller = MainMenuManager.instance.player;
    }

    #endregion Unity methods

    public void SwitchAnime(AnimeParameters anime, bool activate)
    {
        controller.anim.SetBool(anime.ToString(), activate);
    }

    public bool isPlayerMoving()
    {
        Vector3 mouvement = controller.behaviour.moveDirection;
        return mouvement.x != 0 | mouvement.z != 0;
    }

}