using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] int ammoAmount = 5;
    [SerializeField] GameObject effect;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out PlayerTank component)) component.ammo += ammoAmount;
            Destroy(gameObject);
            if (effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
        }
    }
        


}
