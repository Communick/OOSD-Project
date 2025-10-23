using UnityEngine;
using EzySlice;
using System.Collections.Generic;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private LayerMask sliceableLayer;
    [SerializeField] private Transform startSlicePoint;
    [SerializeField] private Material crossSectionMaterial;
    [SerializeField] private int cutForce = 2000;
    [SerializeField] private VelocityEstimator velocityEstimator;
    [SerializeField] private Transform bladeTip;
    [SerializeField] private GameOver_and_UI UIscreen;

    private HashSet<GameObject> recentlySliced = new HashSet<GameObject>();
    private float sliceCooldown = 0.15f;

    public bool started;

    void Start()
    {
        started = false;
    }

    void FixedUpdate()
    {
        if (Physics.Linecast(startSlicePoint.position, bladeTip.position, out RaycastHit hit, sliceableLayer))
        {
            GameObject target = hit.collider.gameObject;
            if (!recentlySliced.Contains(target))
            {
                StartCoroutine(RegisterSliceCooldown(target)); // Marque cet objet comme "deja coupe" pendant un court delai
                SliceObject(target);
            }
        }
    }

    private  IEnumerator RegisterSliceCooldown(GameObject obj)
    {
        recentlySliced.Add(obj);
        UIscreen.comboMult += 1;
        yield return new WaitForSeconds(sliceCooldown);
        recentlySliced.Remove(obj);
    }

    public void SliceObject(GameObject target)
    {
        if (target == null) return;

        // Fruit normal
        SlicedHull hull = target.Slice(target.transform.position, Vector3.up, crossSectionMaterial);
        if (hull == null) return;

        GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
        GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);

        Rigidbody originalRb = target.GetComponent<Rigidbody>();
        Vector3 originalVelocity = originalRb ? originalRb.linearVelocity : Vector3.zero;
        Vector3 originalAngularVelocity = originalRb ? originalRb.angularVelocity : Vector3.zero;

        AddPhysicsToSlice(upperHull, originalVelocity, originalAngularVelocity);
        AddPhysicsToSlice(lowerHull, originalVelocity, originalAngularVelocity);

        Destroy(target);
    }


    private void AddPhysicsToSlice(GameObject slicedObject, Vector3 inheritedVelocity, Vector3 inheritedAngularVelocity)
    {
        if (slicedObject == null) return;

        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        SphereCollider sc = slicedObject.AddComponent<SphereCollider>();

        rb.linearVelocity = inheritedVelocity;
        rb.angularVelocity = inheritedAngularVelocity;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 5f);
        rb.AddTorque(Random.insideUnitSphere * 3f, ForceMode.Impulse);
        Destroy(slicedObject, 8f);
    }
}
