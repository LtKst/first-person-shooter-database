using UnityEngine;

public class AimDownSights : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField]
    private Vector3 downSightsPosition;

    public bool canAimDownSights = true;

    [SerializeField]
    private float aimSpeed = 10;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (canAimDownSights)
        {
            if (Input.GetMouseButton(1))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(initialPosition.x + downSightsPosition.x, initialPosition.y + downSightsPosition.y, initialPosition.z + downSightsPosition.z), Time.deltaTime * aimSpeed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * aimSpeed);
            }

            animator.SetBool("aiming", Input.GetMouseButton(1));
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * aimSpeed);
            animator.SetBool("aiming", false);
        }
    }
}
