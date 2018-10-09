using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "JetPackSO", menuName = "JetPack", order = 1)]
public class JetPackSO : ScriptableObject
{
    public float jumpForce;
    [SerializeField, HideInInspector]
    private TerrainEnum terrains;
    public int consoBoost, consoVol;
    [SerializeField]
    private int terrainsTest;
    public bool canVol;


    public TerrainEnum Terrain { get; set; }
    public int TerrainsTest { get => terrainsTest; set => terrainsTest = value; }
}
