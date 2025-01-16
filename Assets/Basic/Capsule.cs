using UnityEngine;

public class Capsule : MonoBehaviour
{
    [Range(1,10)] public float speed = 1f;

    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 vel = new Vector3();
        vel.x = Input.GetAxis("Horizontal");
        vel.z = Input.GetAxis("Vertical");
        transform.position += vel * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
