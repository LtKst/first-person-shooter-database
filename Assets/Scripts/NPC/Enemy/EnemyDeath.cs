using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    private EnemyAudio enemyAudio;

    private List<Rigidbody> rigidBodies = new List<Rigidbody>();

    private bool isDead = false;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    [SerializeField]
    private AudioClip deathClip;

    private void Awake()
    {
        enemyAudio = GetComponent<EnemyAudio>();

        for (int i = 0; i < transform.GetComponentsInChildren<Rigidbody>().Length; i++)
        {
            rigidBodies.Add(transform.GetComponentsInChildren<Rigidbody>()[i]);
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        // pls fix
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Animator>().enabled = false;

        for (int i = 0; i < rigidBodies.Count; i++)
        {
            rigidBodies[i].isKinematic = false;
        }

        enemyAudio.PlayClip(deathClip);

        isDead = true;
    }
}
