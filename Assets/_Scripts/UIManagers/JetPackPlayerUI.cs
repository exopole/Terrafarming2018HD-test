using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPackPlayerUI : MonoBehaviour {

    public JetPackPlayer jetpack;

    public Text NameText, 
        puissanceText, 
        consoBoostText, 
        consoVolText, terrainText;


    /// <summary>
    /// objListTerrains : Object UI contenant la liste des terrains dans lequel le Jetpack peut aller
    /// </summary>
    public GameObject objListTerrains;
    /// <summary>
    /// UI_JetPack : UI regroupant toutes les infos du jetPack
    /// </summary>
    public GameObject UI_JetPack;

    private List<Text> terrainTextList;

    public Toggle canFly;


    /// <summary>
    /// Permet d'actualisé les infos du JetPack 
    /// </summary>
    public void SwitchJetPack()
    {
        if (NameText)
        {
            NameText.text = jetpack.JetPack.name;
        }
        if (puissanceText)
        {
            puissanceText.text = jetpack.JetPack.jumpForce.ToString();
        }
        if (consoBoostText)
        {
            consoBoostText.text = jetpack.JetPack.consoBoost.ToString();
        }
        if (consoVolText)
        {
            consoVolText.text = jetpack.JetPack.consoVol.ToString();
        }

        if (canFly)
        {
            canFly.isOn = jetpack.JetPack.canVol;
        }

        if (terrainText)
        {
            TransformEx.Clear(objListTerrains.transform);
            foreach (TerrainEnum val in Enum.GetValues(typeof(TerrainEnum)))
            {
                if (jetpack.Terrains.HasFlag(val))
                {
                    Text txt = Instantiate(terrainText);
                    txt.text = val.ToString();
                    txt.gameObject.transform.SetParent(objListTerrains.transform);
                    txt.rectTransform.localScale = new Vector3(1,1,1);
                }
            }
        }

    }

    /// <summary>
    /// Permet d'afficher ou non les infos contenu dans UI_JetPack
    /// </summary>
    /// <param name="tog"></param>
    public void ActivateDebug(Toggle tog)
    {
        UI_JetPack.SetActive(tog.isOn);
    }
}
