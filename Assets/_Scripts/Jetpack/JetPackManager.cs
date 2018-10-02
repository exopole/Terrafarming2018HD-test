using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackManager : MonoBehaviour {

    /// <summary>
    /// Liste des scriptable Obj des jetPacks
    /// </summary>
    public JetPackSO[] jetPacks;
    /// <summary>
    /// Les touches associé aux jetPack
    /// </summary>
    public KeyCode[] asignKeycode;

    public JetPackPlayer jetPackPlayer;
    public JetPackPlayerUI jetpackUI;


    #region monobehavour methods
    private void Start()
    {
        SwitchJetPack(0);
    }

    private void Update()
    {
        DetectChangeJetPack();
    }

    #endregion

    /// <summary>
    /// Detecte s'il faut changer de jetPack
    /// </summary>
    private void DetectChangeJetPack()
    {
        int i = 0;
        int length= asignKeycode.Length;
        while (i < length && !Input.GetKeyDown(asignKeycode[i]))
        {
            i++;
        }
        if(i < length)
        {
            SwitchJetPack(i);
        }
    }

    /// <summary>
    /// Change de JetPack (UI + Player)
    /// </summary>
    /// <param name="index"></param>
    private void SwitchJetPack(int index)
    {
        jetPackPlayer.JetPack = jetPacks[index];
        jetpackUI.SwitchJetPack();

    }


}
