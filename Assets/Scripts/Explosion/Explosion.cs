using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 5f;
    public float power = 10f;

    private void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3f);
        }
    }
}
