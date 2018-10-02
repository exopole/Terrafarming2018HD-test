using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEntryEnv : MonoBehaviour {

    public TerrainEnum terrain;

    public Collider barrage;

    private void OnTriggerEnter(Collider other)
    {
        var jetpack = other.gameObject.GetComponent<JetPackPlayer>();
        if (jetpack.Terrains.HasFlag(terrain) )
        {
            barrage.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        barrage.isTrigger = false;
    }
}
