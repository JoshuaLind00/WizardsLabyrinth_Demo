using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public Image manaBar;
    public float manaAmount = 100;
    public float regen;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            manaLoss(10);
        }
        if (Input.GetKey(KeyCode.F))
        {
            manaRecovery(regen * 10);
        }
        else
        {
            manaRecovery(regen);
        }

    }

    public void manaLoss(float cost)
    {
        if (manaAmount >= cost)
        {
            manaAmount -= cost;
            manaBar.fillAmount = manaAmount / 100;
        }
    }

    public void manaRecovery(float regenAmount)
    {
        manaAmount += regenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0, 100);
        manaBar.fillAmount = manaAmount / 100;
    }

    public void manaFill(float fillAmount)
    {
        manaAmount += fillAmount;
        manaAmount = Mathf.Clamp(manaAmount, 0, 100);
        manaBar.fillAmount = manaAmount / 100;
    }
}
