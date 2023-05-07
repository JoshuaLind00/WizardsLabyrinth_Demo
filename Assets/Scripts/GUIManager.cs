using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    //[SerializeField] private TextMeshProUGUI timer_Txt;
    [SerializeField] private Image healthBar_Img;
    [SerializeField] private Image manaBar_Img;

    private int timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timer = 0;
        SetTimeDisplay();
    }

    private void SetTimeDisplay()
    {

    }


    #region Resource Bars

    public void UpdateHealthBar (float healthPercentage)
    {

    }

    #endregion

}
