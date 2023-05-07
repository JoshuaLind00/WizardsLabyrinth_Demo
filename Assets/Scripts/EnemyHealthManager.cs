using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{

    public float enemyHealth;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider healthSlider;

    public ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
        healthSlider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CalculateHealth();

        if(enemyHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(enemyHealth <= 0)
        {
            Death();
        }
        if(enemyHealth > maxHealth)
        {
            enemyHealth = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return enemyHealth / maxHealth;
    }

    public void DamageEnemy(float damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    public void Death() {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
