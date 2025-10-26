using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionForwarder : MonoBehaviour
{
    [SerializeField]
    private GameOver_and_UI UIscreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponent<ParticleSystem>().Play();
        if (collider.CompareTag("1PointFruit"))
        {
            
            UIscreen.UpdateScore(1);
            
        }
        if (collider.CompareTag("3PointFruit"))
        {
            
            UIscreen.UpdateScore(3);
        }
        if (collider.CompareTag("Bomb"))
        {
            Destroy(collider.gameObject);
            UIscreen.LifeCounter(-1);
        }
        if (collider.CompareTag("Pearto"))
        {
            UIscreen.UpdateScore(5);
        }
    }
}
