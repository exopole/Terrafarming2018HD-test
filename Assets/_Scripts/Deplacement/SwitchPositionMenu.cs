using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPositionMenu : MonoBehaviour {

    public Transform[] Positions;

    public BehaviourController behaviour;


    public void Switch(int position)
    {
        behaviour.target = Positions[position];
    }
}
