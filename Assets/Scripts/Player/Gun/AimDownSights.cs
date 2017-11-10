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

    private Camera _camera;
    private float initialFov;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        initialPosition = transform.position;
        initialFov = _camera.fieldOfView;
    }

    private void Update()
    {
        if (canAimDownSights)
        {
            if (Input.GetButton("Fire2"))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(initialPosition.x + downSightsPosition.x, initialPosition.y + downSightsPosition.y, initialPosition.z + downSightsPosition.z), Time.deltaTime * aimSpeed);
                _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, aimFov, Time.deltaTime * aimSpeed);
                firstPersonController.isAiming = true;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * aimSpeed);
                _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, initialFov, Time.deltaTime * aimSpeed);
                firstPersonController.isAiming = false;
            }
            
            weaponAnimation.SetAimingAnimation(Input.GetMouseButton(1));
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * aimSpeed);
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, initialFov, Time.deltaTime * aimSpeed);
            weaponAnimation.SetAimingAnimation(false);

            firstPersonController.isAiming = false;
        }
    }
}
