using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgMusicController : MonoBehaviour
{
    public static BgMusicController BgInstance;

    private void Awake()
    {
        if(BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "InstructionScene" && SceneManager.GetActiveScene().name != "StartScene")
        {
            Destroy(this.gameObject);
        }
    }
}
