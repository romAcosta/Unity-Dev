using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] float turnRate = 90;
    [SerializeField] float maxSpeed = 5;
    [SerializeField] GameObject rocket;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        float speed = Input.GetAxis("Vertical");
        
        transform.rotation *= Quaternion.AngleAxis(rotation * turnRate * Time.deltaTime, Vector3.up);
        transform.position += transform.rotation * Vector3.forward * speed * maxSpeed * Time.deltaTime;
        // transform.Translate(Vector3.forward * speed * maxSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(rocket, transform.position + Vector3.up, transform.rotation);
        }
    }
}
