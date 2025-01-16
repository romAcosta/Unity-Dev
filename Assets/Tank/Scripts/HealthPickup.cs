using Unity.VisualScripting;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    [SerializeField] int healthAmount = 5;
    [SerializeField] GameObject effect;
    public void OnCollisionEnter(Collision collision)
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out PlayerTank component)) component.health += healthAmount;
            Destroy(gameObject);
            if (effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
        }
    }
        


}
