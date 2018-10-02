using UnityEngine;
using System.Collections;

public class CustomInputManager : MonoBehaviour
{
    public KeyCode[] forwardkeyList;
    public KeyCode[] backwardKeyList;
    public KeyCode[] rightKeyList;
    public KeyCode[] leftKeyList;
    public KeyCode actionKey = KeyCode.Space;
    public KeyCode jumpKey = KeyCode.J;

    public static CustomInputManager instance;
    public GameObject actionButtonVisual;
    public AudioSource actionBtnAudioS;
    public AudioClip showActionBtnSnd;
    public AudioClip hideActionBtnSnd;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (PlayerPrefs.GetString("Keyboard") != "azerty")
            {
                forwardkeyList[0] = KeyCode.W;
                rightKeyList[0] = KeyCode.A;
            }


        }
    }

    public void ShowHideActionButtonVisual(bool show)
    {
        actionButtonVisual.SetActive(show);
        if (show)
        {
            actionBtnAudioS.PlayOneShot(hideActionBtnSnd);
        }
    }

    public Vector3 GetDirection()
    {
        Vector3 direction = new Vector3();

        if (GetForwardKey())
        {
            //direction.z = 1;
            direction += InGameManager.instance.cameraControllerPlayer.transform.forward;
        }
        if (GetBackwardKey())
        {
            direction -= InGameManager.instance.cameraControllerPlayer.transform.forward;
        }
        if (GetLeftKey())
        {
            direction -= InGameManager.instance.cameraControllerPlayer.transform.right;
        }
        if (GetRightKey())
        {
            direction += InGameManager.instance.cameraControllerPlayer.transform.right;
        }

        direction.y = 0;

        return direction;
    }

    public bool IsMoving()
    {
        return GetForwardKey() || GetBackwardKey() || GetLeftKey() || GetRightKey();
    }

    public bool GetKeyInList(KeyCode[] keylist)
    {

        bool resultat;
       
        foreach (KeyCode key in keylist)
        {
            resultat = Input.GetKey(key);
            if (Input.GetKey(key))
            {
                return true;
            }
                
        }
        return false;
    }


    public bool GetForwardKey()
    {
        return GetKeyInList(forwardkeyList);
    }
    public bool GetBackwardKey()
    {
        return GetKeyInList(backwardKeyList);
    }

    public bool GetLeftKey()
    {
        return GetKeyInList(leftKeyList);
    }
    public bool GetRightKey()
    {
        return GetKeyInList(rightKeyList);
    }

}