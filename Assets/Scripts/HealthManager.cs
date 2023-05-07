using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;
    public float regen;

    // Update is called once per frame
    void Update()
    {

        if(healthAmount <= 0)
        {
            /*FindObjectOfType<GUITimer>().ResetTimer();
            healthRecovery(300);
            FindObjectOfType<ManaManager>().manaFill(100);*/
            SceneManager.LoadScene("EndScene");

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            takeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            healthRecovery(10);
        }
        healthRegen(regen);
        
    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void healthRecovery(float heal)
    {
        healthAmount += heal;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100;
    }
    public void healthRegen(float regenAmount)
    {
        healthAmount += regenAmount * Time.deltaTime;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100;
    }

}
