using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    #region editor variable

    [Header("Général")]
    public CharacterController Cc;
    public Vector3 moveDirection = Vector3.zero;
    public bool canMove = true;
    [SerializeField]
    private bool usingDirectionel = true;
    public Transform target;
    public float distanceStop;

    [Header("Deplacement")]
    public float gravity = 20f;
    public float jumpSpeed = 8f;
    public float speed = 6f;
    public float speedRotate;

    [Header("Fly")]
    [SerializeField]
    private bool isFlying;
    public float multSpeedFly = 2;
    [SerializeField]
    private float maxHeightReference = 20;
    private float referenceYFly;
    [SerializeField]
    private float maxHeight = 20;    
    private float minHeight = 0;
    public float flotaison = 0;


    


    #endregion


    #region Monobehaviour Methods

    private void Start()
    {
        if (usingDirectionel && !CustomInputManager.instance)
        {
            Debug.Log("You don't have a CustomInputManager");
            UsingDirectionel = false;
        }

        if (Cc == null)
        {
            Debug.Log("Where is your CharactereController?");
        }
    }

    private void Update()
    {
        float y = moveDirection.y;
        if (canMove)
            moveDirection = CalculateMoveDirection();
        else
        {
            moveDirection = Vector3.zero;
        }
        moveDirection.y = y;

        if (isFlying)
        {
            if (transform.position.y <= referenceYFly)
                Jump(flotaison);
            Gravity((gravity / 2) * flotaison);
        }
        else
        {
            Gravity();
        }

        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            rotation(moveDirection);
        }
        Cc.Move(moveDirection * Time.deltaTime);
        if(Cc.velocity.y == 0)
        {
            moveDirection.y = 0;
        }
    }

    #endregion

    #region getter/setter
    public bool IsFlying
    {
        get
        {
            return isFlying;
        }

        set
        {
            if (IsFlying != value)
            {
                speed = (value) ? speed * multSpeedFly : speed / multSpeedFly;
            }
            isFlying = value;
            float yref = transform.position.y - calculateJumpHeight() * flotaison;
            //float yref = transform.position.y - flotaison;
            //Debug.Log(transform.position.y + " / " + yref + " / " + calculateJumpHeight() +" / " +  calculateJumpHeight() * flotaison);
            referenceYFly = (yref <= MinHeight) ? MinHeight : (yref > MaxHeight) ? MaxHeight : yref;
        }
    }

    public float MaxHeight
    {
        get
        {
            return maxHeight;
        }

        set
        {
            maxHeight = value;
        }
    }

    public float MinHeight
    {
        get
        {
            return minHeight;
        }

        set
        {
            minHeight = value;
        }
    }

    public bool UsingDirectionel
    {
        get
        {
            return usingDirectionel;
        }

        set
        {
            if (value && !CustomInputManager.instance)
            {
                Debug.Log("You don't have a CustomInputManager");
                usingDirectionel = false;
            }
            else
            {
                usingDirectionel = value;
            }
        }
    }

    #endregion

    /// <summary>
    /// Calcule le vecteur directionnel
    /// </summary>
    /// <returns></returns>
    public Vector3 CalculateMoveDirection()
    {
        Vector3 vectDirection = new Vector3();
        if (UsingDirectionel)
        {
            vectDirection = CustomInputManager.instance.GetDirection();
        }
        else if(target)
        {
            if (Vector3.Distance(target.position, transform.position) > distanceStop)
                vectDirection = target.position - transform.position;
            else
                target = null;
        }
        return vectDirection.normalized * speed;
    }

    #region Gravity

    /// <summary>
    /// exerce la gravité sur le personnage
    /// </summary>
    public virtual void Gravity()
    {
        if (Cc.velocity.y >= 0)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else if (Cc.velocity.y < 0)
        {
            moveDirection.y -= gravity * 2 * Time.deltaTime;
        }
    }

    public virtual void Gravity(float gravity)
    {
        if (Cc.velocity.y >= 0)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y -= gravity * 2 * Time.deltaTime;
        }
    }

    #endregion

    #region Jump Methods

    public void Jump()
    {
        if (transform.position.y < MaxHeight)
            moveDirection.y = jumpSpeed;
    }

    /// <summary>
    /// Jump with an additional force
    /// </summary>
    /// <param name="jumpForce"></param>
    public void JumpWithAdditionalForce(float jumpForce)
    {
        if (transform.position.y < MaxHeight)
            moveDirection.y = jumpForce + jumpSpeed;
    }

    /// <summary>
    /// use the jumpForce to make the jump
    /// </summary>
    /// <param name="jumpForce"></param>
    public void JumpWith(float jumpForce)
    {
        if (transform.position.y < MaxHeight)
            moveDirection.y = jumpForce;
    }

    /// <summary>
    /// mutlity the jumpSpeed by potentiel
    /// </summary>
    /// <param name="potentiel"></param>
    public void Jump(float potentiel)
    {
        if (transform.position.y < MaxHeight)
            moveDirection.y = jumpSpeed * potentiel;
    }

    public float calculateJumpHeight()
    {
        return ((jumpSpeed * jumpSpeed) / (2 * gravity) + jumpSpeed * Time.deltaTime) / 2;
    }

    #endregion

    public void rotation(Vector3 direction)
    {
        Vector3 rotation = new Vector3(direction.x, 0, direction.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation.normalized), speedRotate * Time.deltaTime);
    }

    public void setMaxAltitudeWithRef(float altitude)
    {
        MaxHeight = maxHeightReference + altitude;
    }




}