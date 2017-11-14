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
    private float aimFov = 24;

    [SerializeField]
    private WeaponAnimation weaponAnimation;

    [SerializeField]
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    private Camera viewmodelCamera;
    private float initialFov;

    private void Awake()
    {
        viewmodelCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        initialPosition = transform.position;
        initialFov = viewmodelCamera.fieldOfView;
    }

    private void Update()
    {
        if (canAimDownSights && !weaponAnimation.reloading)
        {
            if (Input.GetButton("Fire2"))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(initialPosition.x + downSightsPosition.x, initialPosition.y + downSightsPosition.y, initialPosition.z + downSightsPosition.z), Time.deltaTime * aimSpeed);
                viewmodelCamera.fieldOfView = Mathf.Lerp(viewmodelCamera.fieldOfView, aimFov, Time.deltaTime * aimSpeed);
                firstPersonController.isAiming = true;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * aimSpeed);
                viewmodelCamera.fieldOfView = Mathf.Lerp(viewmodelCamera.fieldOfView, initialFov, Time.deltaTime * aimSpeed);
                firstPersonController.isAiming = false;
            }
            
            weaponAnimation.aiming = Input.GetMouseButton(1);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * aimSpeed);
            viewmodelCamera.fieldOfView = Mathf.Lerp(viewmodelCamera.fieldOfView, initialFov, Time.deltaTime * aimSpeed);

            weaponAnimation.aiming = false;

            firstPersonController.isAiming = false;
        }
    }
}
