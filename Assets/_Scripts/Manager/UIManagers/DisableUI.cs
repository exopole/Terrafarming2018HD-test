using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableUI : MonoBehaviour {

    public GameObject UIObj;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.N))
        {
            UIObj.SetActive(!UIObj.activeInHierarchy);
        }
    }

}
