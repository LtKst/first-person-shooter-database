using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    public void Explode()
    {
        Instantiate(explosion).transform.position = transform.position;
        Destroy(gameObject);
    }
}
