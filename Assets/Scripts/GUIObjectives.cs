using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GUIObjectives : MonoBehaviour
{

    public Text ObjectiveText;
    
    void Update()
    {
        if (GameObject.Find("Exit_GateKey") != null)
        {
            ObjectiveText.text = "Find the Key";
        }
        else
        {
            ObjectiveText.text = "Exit the Maze";
        }
    }
}
