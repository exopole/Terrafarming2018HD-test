using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMenuController : MonoBehaviour
{
    #region variables editor

    public CharacterController Cc;
    public Animator anim;

    
    public BehaviourController behaviour;

    public Transform targetMove;
    
    #endregion variables editor

    private void Start()
    {
        Cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        SwitchAnime(AnimeParameters.islanding, false);
    }

    

    public virtual void SwitchAnime(AnimeParameters anime, bool activate)
    {
        anim.SetBool(anime.ToString(), activate);
    }

    public void disableMovement()
    {
        behaviour.canMove = false;
        //behaviourNotGrounded.enabled = false;
    }

    public void enableMovement()
    {
        behaviour.canMove = true;
    }

    public void SetAltitudeMaxFromGroundPos(float altitudeGround)
    {
        behaviour.setMaxAltitudeWithRef(altitudeGround);
    }

}