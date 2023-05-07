using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GUITimer : MonoBehaviour
{
    bool timerActive = true;
    static float currentTime;
    Scene currentScene;
    public Text currentTimeText;
    public static float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentScene = SceneManager.GetActiveScene();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            finalTime = currentTime;
        }
        else if (currentScene.name != "MainScenDemo")
        {
            StopTimer();
            finalTime = currentTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }
    public void StartTimer()
    {
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
    }
    public static void ResetTimer()
    {
        currentTime = 0;
    }

}
