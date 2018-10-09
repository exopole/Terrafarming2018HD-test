using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour {

    public List<Toggle> togglesList;
    public GameObject UIObj;

    [SerializeField]
    private bool debug;

    public bool Debug {
        get => debug;
        set
        {
            debug = value;
            SetAllToggles(value);
            UIObj.SetActive(debug);
        }
    }

    private void Start()
    {
        SetAllToggles(debug);
        UIObj.SetActive(debug);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.M))
        {
            Debug = !debug;
        }
    }

    public void SetAllToggles(bool cond)
    {
        foreach (var togle in togglesList)
        {
            togle.isOn = cond;
        }
    }

    
}
