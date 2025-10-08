using UnityEngine;
using EzySlice;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform startSlicePoint;
    [SerializeField]
    private Transform endSlicePoint;
    [SerializeField]
    private Material crossSectionMaterial;
    [SerializeField]
    private LayerMask sliceableLayer;
    [SerializeField]
    private VelocityEstimator velocityEstimator;
    [SerializeField]
    private float cutforce;
    private int HP;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = 3;
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("1PointFruit"))
        {
            Slice(collision.gameObject);
            score++;
            // Add Point Logic to Text
        }
        if (collision.gameObject.CompareTag("3PointFruit"))
        {
            Slice(collision.gameObject);
            score += 3;
            // Add Point Logic to Text
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
            HP--;
        }
        if (collision.gameObject.CompareTag("Pearto"))
        {
            Slice(collision.gameObject);
            score += 5;
            // Add Point Logic to Text (5 points)
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            target.GetComponent<ParticleSystem>().Play();

            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSliceComponent(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSliceComponent(lowerHull);

            Destroy(target);
        }
    }

    public void SetupSliceComponent(GameObject slicedObject)
    {
        Rigidbody rigidbody = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rigidbody.AddExplosionForce(cutforce, slicedObject.transform.position, 1);
    }
}
