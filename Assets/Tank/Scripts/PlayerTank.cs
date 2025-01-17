using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTank : MonoBehaviour, IDamagable
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 5;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform barrel;
    [SerializeField] public int ammo = 10;
    [SerializeField] public int health = 10;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text healthText;

    private float torque;
    private float force;
    
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;
        

        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            ammo--;
            Instantiate(rocket, barrel.position + Vector3.up, barrel.rotation);
        }
        ammoText.text ="Ammo: " + ammo;
        healthText.text = "Health: " + health;
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }

    public void ApplyDamage(float damage)
    {
        
    }
}
