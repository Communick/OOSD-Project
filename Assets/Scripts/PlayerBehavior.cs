using UnityEngine;
using EzySlice;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private LayerMask sliceableLayer;
    [SerializeField]
    private Transform startSlicePoint;
    [SerializeField]
    private Material crossSectionMaterial;
    [SerializeField]
    private int cutforce = 2000;
    [SerializeField]
    private VelocityEstimator velocityEstimator;
    public Transform bladeTip;
    [SerializeField]
    private GameOver_and_UI UIscreen;
    public bool started = false;

    public float minCuttingSpeed = 1.5f;

    Vector3 lastTipPos;
    Vector3 tipVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bladeTip == null) bladeTip = transform; // fallback
        lastTipPos = bladeTip.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = bladeTip.position;
        tipVelocity = (pos - lastTipPos) / Mathf.Max(Time.deltaTime, 1e-6f);
        lastTipPos = pos;
    }
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, bladeTip.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            SliceOBJ(target);
        }
    }

    // If your BladeTrigger is a separate trigger object with OnTriggerEnter, you can call this there.
    // We'll provide a trigger helper: call TrySliceFromCollision with collision contact.
    /*public void TrySliceFromCollider(Collider other, Vector3 contactPoint, Vector3 contactNormal)
    {
        // Only slice on matching layer
        if (((1 << other.gameObject.layer) & sliceableLayer.value) == 0) return;

        if (tipVelocity.magnitude < minCuttingSpeed) return; // too slow to cut

        // Compute plane using blade's local orientation:
        Vector3 planeNormal = transform.up; // or transform.right depending on blade orientation
        // Use direction of swing to orient plane better:
        if (tipVelocity.sqrMagnitude > 0.01f)
        {
            // plane normal can be cross product between blade direction and swing direction for sharp plane
            Vector3 bladeForward = transform.forward;
            planeNormal = Vector3.Cross(bladeForward, tipVelocity).normalized;
            if (planeNormal.sqrMagnitude < 0.01f) planeNormal = transform.up;
        }

        // Slight offset so plane doesn't exactly slice at contact.
        Vector3 planePos = contactPoint + planeNormal;

        // try to get SliceableFruit on other
        SliceableFruit sf = other.GetComponentInParent<SliceableFruit>();
        if (sf == null) sf = other.GetComponent<SliceableFruit>();
        if (sf != null)
        {
            sf.Slice(planePos, planeNormal, tipVelocity);
        }
        else
        {
            // If object not using SliceableFruit component, try slice with static helper
            var helper = other.GetComponentInParent<SliceableFruit>(); // optional
        }
    }*/

    public void SliceOBJ(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planenormal = Vector3.Cross(bladeTip.position - startSlicePoint.position, velocity);
        planenormal.Normalize();

        SlicedHull hull = target.Slice(bladeTip.position, planenormal);

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
