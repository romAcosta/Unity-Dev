using UnityEngine;
using UnityEngine.EventSystems;

public class Destructable : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 10;
    [SerializeField] GameObject deathEffect;
    private bool destroyed = false;

    public void ApplyDamage(float damage)
    {
        if(destroyed) return;
        
        health -= damage;
        if (health <= 0)
        {
            destroyed = true;
            if(deathEffect != null)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
