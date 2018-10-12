using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "JetPackSO", menuName = "JetPack", order = 1)]
public class JetPackSO : ScriptableObject
{
    public float jumpForce;
    public int consoBoost, consoVol;
    [SerializeField]
    public int terrainsValue;
    public bool canVol;


    public TerrainEnum Terrain {
        get
        {
            return (TerrainEnum)terrainsValue;
        }
        set
        {
            terrainsValue = (int)value;
        }
    }
}
