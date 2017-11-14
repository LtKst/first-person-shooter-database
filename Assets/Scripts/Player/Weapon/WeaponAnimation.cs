using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public bool aiming;
    public bool shooting;
    public bool reloading;

    private void Update()
    {
        animator.SetBool("aiming", aiming);
        animator.SetBool("shooting", shooting);
        animator.SetBool("reloading", reloading);
    }
}
