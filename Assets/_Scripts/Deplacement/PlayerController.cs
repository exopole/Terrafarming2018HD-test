using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region variables editor

    public CharacterController Cc;
    public bool isGrounded;
    public Animator anim;

    public bool canDoAction = true;

    public BehaviourController behaviour;
    public ParticleSystem aterrisageParticle;
    public PropulseurParticleController propulseurParticle;

    public float MinEmmissionPropulseur = 50;
    public float MaxEmmissionPropulseur = 1000;

    public GameObject shadowObject;

    [SerializeField]
    private JetPackPlayer jetPack;


    public bool usingJetPack = false;

    #endregion variables editor

    private void Start()
    {
        Cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        SwitchAnime(AnimeParameters.islanding, false);
    }

    #region getter/setter
    public JetPackPlayer JetPack { get => jetPack;  }
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

                if (isGrounded)
                {
                    aterrisageParticle.gameObject.transform.position = transform.position;
                    aterrisageParticle.Clear();
                    aterrisageParticle.Play();
                    //SetAltitudeMaxFromGroundPos(0);
                    propulseurParticle.StopPropulseur();
                    shadowObject.SetActive(false);
                }
                else
                {
                    shadowObject.SetActive(true);
                }
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

    public void Jump()
    {
        behaviour.Jump();
        propulseurParticle.Burst();
    }

    public void JumpWithJetPack()
    {
        if (JetPack.BoostConso())
        {
            behaviour.JumpWithAdditionalForce(JetPack.JumpForce);
            propulseurParticle.Burst();
        }
    }

    public void BoostFromJetPack()
    {
        if (JetPack.BoostConso())
        {
            behaviour.JumpWith(JetPack.JumpForce);
            propulseurParticle.Burst();
        }
    }

    public void Fly()
    {
        if (JetPack.StartConsommation())
            behaviour.IsFlying = true;
    }

    public void StopFlying()
    {
        JetPack.StopConsommation();
        behaviour.IsFlying = false;
    }
}