using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private float interactDistance = 2f;

    private bool mouseOver;

    private Text interactText;

    private void OnMouseEnter()
    {
        mouseOver = true;

        interactText.enabled = Vector3.Distance(player.position, transform.position) < interactDistance;
    }

    private void OnMouseExit()
    {
        mouseOver = false;

        interactText.enabled = false;
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

        interactText = GameObject.FindWithTag("InteractText").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && mouseOver && Vector3.Distance(player.position, transform.position) < interactDistance)
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        interactText.enabled = false;
    }
}
