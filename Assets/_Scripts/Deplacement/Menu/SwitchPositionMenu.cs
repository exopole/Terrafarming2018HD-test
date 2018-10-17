using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPositionMenu : MonoBehaviour {

    public Transform[] Positions;

    public PlayerMenuController player;


    public void Switch(int position)
    {
        if (player.behaviour.target)
        {
            player.behaviour.target = Positions[position];
        }
        else
        {
            player.targetMove = Positions[position];
        }
    }
}
