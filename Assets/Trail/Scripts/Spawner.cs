using UnityEngine;

// Class responsible for spawning objects and applying forces to them
public class Spawner : MonoBehaviour
{
    // Reference to the prefab that will be spawned
    public GameObject prefab;
    // Amount of force to apply to spawned objects
    public float force = 10;

    void Update()
    {
        // Check if space key is being held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Instantiate a new object at the spawner's position and rotation
            var go = Instantiate(prefab, transform.position, Quaternion.identity);
            
            // Add a random force to the spawned object in a random direction
            // Random.insideUnitSphere returns a random point inside a sphere with radius 1
            // ForceMode.VelocityChange applies instant velocity change without considering mass
            go.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * force);
            
            // Destroy the spawned object after 3 seconds to prevent memory/performance issues
            Destroy(go,3f);
        }
    }
}
