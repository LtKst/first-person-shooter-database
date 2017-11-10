using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private float interactDistance = 2f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && Vector3.Distance(transform.position, player.position) < interactDistance)
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        print("woah");
    }
}
