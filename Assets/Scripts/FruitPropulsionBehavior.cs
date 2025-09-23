using UnityEngine;

public class FruitPropulsionBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody fruit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0f);
        fruit.linearVelocity = Vector3.zero;
        if (Random.Range(0, 10) < 5)
        {
            fruit.AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
        }
        else
        {
            fruit.AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
