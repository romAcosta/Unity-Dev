using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] bool destroyOnHit = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable target))
        {
            target.ApplyDamage(damage);
        }
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    } 
}
