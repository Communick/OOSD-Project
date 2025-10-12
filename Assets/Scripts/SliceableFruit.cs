using UnityEngine;
using EzySlice; // from EzySlice package
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SliceableFruit : MonoBehaviour
{
    [Header("Slicing")]
    public Material capMaterial; // assign in inspector
    public float pieceSeparation = 0.02f;
    public bool destroyOriginal = true;
    public bool addRigidbodyToPieces = true;
    public float addVelocityMultiplier = 1.0f;

    bool sliced = false;

    public void Slice(Vector3 planeWorldPosition, Vector3 planeWorldNormal, Vector3 bladeVelocity)
    {
        if (sliced) return; // prevent double slicing
        sliced = true;

        // Convert plane into local space of object? EzySlice expects world plane
        UnityEngine.Plane plane = new UnityEngine.Plane(planeWorldNormal.normalized, planeWorldPosition);

        // Do slice using EzySlice
        try
        {
            // EzySlice extension method on GameObject: returns SlicedHull
            SlicedHull hull = gameObject.Slice(planeWorldPosition, planeWorldNormal, capMaterial);

            if (hull == null)
            {
                Debug.Log("Slice returned null hull (maybe non-manifold mesh)");
                sliced = false;
                return;
            }

            // Create upper and lower hull GameObjects
            GameObject upper = hull.CreateUpperHull(gameObject, capMaterial);
            GameObject lower = hull.CreateLowerHull(gameObject, capMaterial);

            SetupPiece(upper, planeWorldNormal, bladeVelocity);
            SetupPiece(lower, -planeWorldNormal, bladeVelocity);

            // optional explosion/separation
            upper.transform.position += planeWorldNormal * pieceSeparation;
            lower.transform.position += -planeWorldNormal * pieceSeparation;

            if (destroyOriginal) Destroy(gameObject);
            else
            {
                // hide/disable original mesh so it doesn't show
                var mr = GetComponent<MeshRenderer>();
                if (mr) mr.enabled = false;
                var mf = GetComponent<MeshFilter>();
                if (mf) mf.mesh = null;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Slicing error: " + ex);
            sliced = false;
        }
    }

    void SetupPiece(GameObject piece, Vector3 pieceNormal, Vector3 bladeVelocity)
    {
        if (piece == null) return;

        // Make piece active, set layer and name
        piece.layer = gameObject.layer;
        piece.transform.position = piece.transform.position;
        piece.transform.rotation = gameObject.transform.rotation;
        piece.transform.localScale = gameObject.transform.localScale;

        // Remove any colliders from hull (EzySlice may leave none), then add MeshCollider
        // Add MeshCollider if mesh present
        MeshFilter mf = piece.GetComponent<MeshFilter>();
        if (mf)
        {
            MeshCollider mc = piece.AddComponent<MeshCollider>();
            mc.sharedMesh = mf.mesh;
            mc.convex = true; // convex necessary for non-kinematic rigidbody physics
        }

        // add Rigidbody
        if (addRigidbodyToPieces)
        {
            Rigidbody rb = piece.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            // small random angular impulse
            rb.AddTorque(Random.insideUnitSphere * 0.75f, ForceMode.Impulse);
            // apply initial velocity influenced by blade
            Vector3 velocity = bladeVelocity * addVelocityMultiplier;
            // small upward bias to separate pieces
            velocity += Vector3.up * 0.4f;
            rb.linearVelocity = velocity;
        }

        // Optionally add component to destroy pieces after some time
        Destroy(piece, 10f);
    }

    // If fruit uses SkinnedMeshRenderer, provide helper to bake mesh before slicing
    public Mesh BakeSkinnedMeshToMesh(SkinnedMeshRenderer smr)
    {
        Mesh m = new Mesh();
        smr.BakeMesh(m);
        return m;
    }
}
