using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionForwarder : MonoBehaviour
{
    private int HP;
    private int score;
    [SerializeField]
    private GameOver_and_UI UIscreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        // get closest point
        /*Vector3 contactPoint = collider.ClosestPoint(bladeTip.position);
        Vector3 contactNormal = (contactPoint - bladeTip.position).normalized;
        TrySliceFromCollider(collider, contactPoint, contactNormal);*/
        if (collider.CompareTag("1PointFruit"))
        {
            //SliceOBJ(collision.gameObject);
            score++;
            UIscreen.UpdateScore(score);
        }
        if (collider.CompareTag("3PointFruit"))
        {
            //SliceOBJ(collision.gameObject);
            score += 3;
            UIscreen.UpdateScore(score);
        }
        if (collider.CompareTag("Bomb"))
        {
            collider.GetComponent<ParticleSystem>().Play();
            Destroy(collider.gameObject);
            HP--;
            UIscreen.LifeCounter(HP);
        }
        if (collider.CompareTag("Pearto"))
        {
            //SliceOBJ(collision.gameObject);
            score += 5;
            UIscreen.UpdateScore(score);
        }
    }
}
