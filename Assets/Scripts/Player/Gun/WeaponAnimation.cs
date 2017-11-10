using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void SetReloadingAnimation(bool reloading)
    {
        animator.SetBool("reloading", reloading);
    }

    public void SetAimingAnimation(bool aiming)
    {
        animator.SetBool("aiming", aiming);
    }

    public float CurrentAnimationLength
    {
        get
        {
            return animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}
