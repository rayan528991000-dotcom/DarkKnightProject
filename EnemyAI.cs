using UnityEngine;
using UnityEngine.AI;

// Attach to enemy prefab with NavMeshAgent and collider.
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 100;
    public float chaseDistance = 10f;
    public float attackDistance = 1.6f;
    public int damage = 10;
    public float attackCooldown = 1.2f;
    public Transform target;

    private NavMeshAgent agent;
    private int currentHealth;
    private float lastAttackTime = -99f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        if (target == null && Camera.main != null)
        {
            var playerObj = GameObject.FindWithTag("Player");
            if (playerObj) target = playerObj.transform;
        }
    }

    void Update()
    {
        if (target == null) return;
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= attackDistance)
        {
            agent.isStopped = true;
            TryAttack();
        }
        else if (dist <= chaseDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;
        lastAttackTime = Time.time;
        // Implement damage to player (simple example)
        var player = target.GetComponent<PlayerHealth>();
        if (player != null) player.ApplyDamage(damage);
    }

    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        // Simple death behavior: disable and play effect (implement your own)
        gameObject.SetActive(false);
    }
}
