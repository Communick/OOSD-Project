using UnityEngine;

public class FruitPropulsionBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody fruit;
    public int force = 150;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fruit.linearVelocity = Vector3.zero;
        fruit.AddForce((new Vector3(0, 0, 0) - transform.position) * force);
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

