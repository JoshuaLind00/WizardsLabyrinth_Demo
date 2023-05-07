using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 FirePoint;
    
    
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float projectileDistance;

    public float damage = 5;

    void Start()
    {
        FirePoint = transform.position;
        //Destroy(gameObject, damage);
    }

    private void Update()
    {
        moveProjectile();
        if (Vector3.Distance(FirePoint, transform.position) > projectileDistance)
        {
            Destroy(this.gameObject);
        }
    }

    void moveProjectile()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        
    }
    void OnCollisionEnter(Collision collisionData)
    {
        
        if (collisionData.collider.tag != "Player" && collisionData.collider.tag != "Projectile")
        {
            Destroy(gameObject);
        }
        if(collisionData.gameObject.TryGetComponent<EnemyHealthManager>(out EnemyHealthManager enemyComponent))
        {
            enemyComponent.DamageEnemy(damage);
        }
    }
}
