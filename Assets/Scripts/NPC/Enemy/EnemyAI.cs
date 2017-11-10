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
        if (navMeshAgent.enabled && target != null)
        {
            navMeshAgent.SetDestination(target.position);
            enemyAnimation.UpdateAnimation(navMeshAgent.speed);
        }
    }
}
