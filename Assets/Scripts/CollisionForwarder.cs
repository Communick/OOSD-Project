using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionForwarder : MonoBehaviour
{
    [SerializeField]
    private GameOver_and_UI UIscreen;
    [SerializeField]
    private GameObject player;
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
            player.GetComponent<AudioSource>().Play();
        }
        if (collider.CompareTag("3PointFruit"))
        {
            UIscreen.UpdateScore(3);
            player.GetComponent<AudioSource>().Play();
        }
        if (collider.CompareTag("Bomb"))
        {
            Destroy(collider.gameObject);
            collider.GetComponent<AudioSource>().Play();
            UIscreen.LifeCounter(-1);
        }
        if (collider.CompareTag("Pearto"))
        {
            UIscreen.UpdateScore(5);
            player.GetComponent<AudioSource>().Play();
        }
    }
}
