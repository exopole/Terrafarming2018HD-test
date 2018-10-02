using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
