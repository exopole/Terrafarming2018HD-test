using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour {

	public KeyCode[] mineraisInfinis;


	// Update is called once per frame
	void Update () {
        
        int i = 0;
        int lengthMineraisInfinis = mineraisInfinis.Length;

        while (i < lengthMineraisInfinis && Input.GetKey(mineraisInfinis[i]))
            i++;
        
        if(i == lengthMineraisInfinis)
            ResourcesManager.instance.ChangeRawOre(1000);
        
    }
}
