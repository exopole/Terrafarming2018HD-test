using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController1 : MonoBehaviour
{
    #region variables editor

    public CharacterController Cc;
    public bool isGrounded;
    public Animator anim;

    public bool canDoAction = true;

    public BehaviourController behaviour;
   

    #endregion variables editor

    private void Start()
    {
        Cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        SwitchAnime(AnimeParameters.islanding, false);
    }

    #region getter/setter
    #endregion

    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }

        set
        {
            if (isGrounded != value)
            {
                isGrounded = value;

                SwitchAnime(AnimeParameters.islanding, IsGrounded);
                SwitchAnime(AnimeParameters.isfalling, !IsGrounded);

            }
        }
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