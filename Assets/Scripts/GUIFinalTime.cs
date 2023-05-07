using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GUIFinalTime : MonoBehaviour
{
    public Text finalTimeText;
    float final;

    void Start()
    {
        final = GUITimer.finalTime;
    }

    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(final);
        finalTimeText.text = "Total Time: \n" + time.ToString(@"mm\:ss\:fff");
    }
}
