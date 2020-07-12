using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    public float lookRadius = 14f;

    public float strength = 1.0f;

    public float attackDelay = 0.5f;

    private float attackTimer = 0f;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (dist <= agent.stoppingDistance + 0.69f)
            {
                FaceTarget();

                if (attackTimer >= attackDelay)
                {
                    Attack();

                    attackTimer = 0;
                }
            }

            attackTimer += Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Attack()
    {
        PlayerManager.instance.player.GetComponent<Player>().Damage(strength);
    }

    public void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 4.5f);
    }
}
