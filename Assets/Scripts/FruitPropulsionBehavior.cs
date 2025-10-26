using UnityEngine;

public class FruitPropulsionBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody fruit;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fruit.linearVelocity = Vector3.zero;
        Vector3 direction = (new Vector3(0, 0, 1) - transform.position).normalized;
        fruit.AddForce(direction * force, ForceMode.Impulse);
        if (Time.timeSinceLevelLoad < 1)
        {
            Destroy(gameObject, 0.001f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}

