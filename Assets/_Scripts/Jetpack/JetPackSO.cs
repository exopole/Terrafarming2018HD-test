using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects, CreateAssetMenu(fileName = "JetPackSO", menuName = "JetPack", order = 1)]
public class JetPackSO : ScriptableObject
{
    [CanEditMultipleObjects]
    public float jumpForce;
    [SerializeField, HideInInspector]
    private TerrainEnum terrains;
    public int consoBoost, consoVol;
    public bool canVol;


    public TerrainEnum Terrain { get; set; }

}
