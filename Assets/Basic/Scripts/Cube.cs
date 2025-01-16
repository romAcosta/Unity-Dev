using UnityEngine;

public class Cube : MonoBehaviour
{

    void Awake()
    {
        
    }
   
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 position = transform.position;
        position.y += 1 * Time.deltaTime;
        transform.position = position;
        
    }
}
