using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameManager1 : MonoBehaviour
{
    public static InGameManager1 instance;

    public PlayerController1 playerController;
    public Animator InterfaceAnimator;

    public bool isPlanting;

    public CameraController cameraControllerPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}