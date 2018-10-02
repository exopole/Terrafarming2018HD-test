using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    #region editor variables

    public GameObject focus;

    public Vector3 offset;
    public float stepZoom;

    public float minDistance;
    public float maxDistance;

    public float smooth;

    public Text verticalText;
    public Text horizontalText;

    #endregion editor variables

    #region other variables

    [SerializeField]
    private float distance = 20;
    
    private float targetAngle = 0;
    private const float rotationAmount = 1.0f;

    [SerializeField]
    private float v = 45;

    [SerializeField]
    private float h = 45;

    private float z;


    #endregion other variables

    #region unity methods

    private void Awake()
    {
        setVerticalUI(v);
        setHorizontalUI(h);
        
    }

    private void Start()
    {
        offset = Quaternion.Euler(V, -H, Z) * new Vector3(0, 0, 1);
        transform.position = focus.transform.position - offset * Distance;
        transform.LookAt(focus.transform);
    }

    private void Update()
    {
        
        moveSmoothlyCam();
        RotateSmoothlyCam();
    }

    #endregion unity methods

    public void moveSmoothlyCam()
    {
        offset = Quaternion.Euler(V, -H, Z) * new Vector3(0, 0, 1);
        transform.position = Vector3.Lerp(transform.position, focus.transform.position - offset * Distance, smooth * Time.deltaTime);
    }

    public void RotateSmoothlyCam()
    {
        Vector3 lTargetDir = focus.transform.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * smooth);
    }

    public void moveCam()
    {
        offset = Quaternion.Euler(V, -H, Z) * new Vector3(0, 0, 1);
        transform.position = focus.transform.position - offset * Distance;
        transform.LookAt(focus.transform);
    }

    #region getter/setter

    public float V
    {
        get
        {
            return v;
        }

        set
        {
            v = Mathf.Clamp(value, 0, 90);
            setVerticalUI(v);
        }
    }

    public float H
    {
        get
        {
            return h;
        }

        set
        {
            h = (value < 0) ? value + 360 : (value > 360) ? value - 360 : value;
            setHorizontalUI(h);
        }
    }

    public float Z
    {
        get
        {
            return z;
        }

        set
        {
            z = value;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }

        set
        {
            distance = value;
        }
    }

    #endregion getter/setter

    #region UI

    public void setHorizontalUI(float value)
    {
        if (horizontalText != null)
        {
            horizontalText.text = value.ToString();
        }
    }

    public void setVerticalUI(float value)
    {
        if (verticalText != null)
        {
            verticalText.text = value.ToString();
        }
    }

    #endregion UI
}