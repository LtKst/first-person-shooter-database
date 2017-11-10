using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent navMeshAgent;
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        if (target != null && navMeshAgent.enabled && Vector3.Distance(transform.position, target.position) > 5)
        {
            navMeshAgent.SetDestination(target.position);
            enemyAnimation.UpdateAnimation(navMeshAgent.speed);
        }
    }
}
