using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip deathClip;

    private bool isDead = false;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(GameObject.FindWithTag("Player").transform.position);
            animator.SetFloat("speed", navMeshAgent.speed);
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        navMeshAgent.enabled = false;
        animator.enabled = false;

        for (int i = 0; i < transform.GetComponentsInChildren<Rigidbody>().Length; i++)
        {
            transform.GetComponentsInChildren<Rigidbody>()[i].isKinematic = false;
            audioSource.PlayOneShot(deathClip);
        }

        isDead = true;
    }
}
