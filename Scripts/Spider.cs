using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    public NavMeshAgent _agent;
    [SerializeField]public Transform _player;
    public LayerMask ground, player;
    public GameObject sephere;


    public Vector3 destinationPoint;
    private bool destinationPointSet;
    public float walkPointRange;


    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float health = 120;

    private void Awake()
    {
        //_player = GameObject.Find("PlayerObj").transform;
        _agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, attackRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, sightRange, player);

        if (!playerInAttackRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), .5f);
        }
    }

    private void Patroling()
    {
        if (!destinationPointSet)
        {
            SearchWalkPoint();
        }

        if (destinationPointSet)
        {
            _agent.SetDestination(destinationPoint);
        }

        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;

        if(distanceToDestinationPoint.magnitude < 1f)
        {
            destinationPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(destinationPoint, -transform.up, 2f, ground))
        {
            destinationPointSet = true;
        }
       
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        if (!alreadyAttacked)
        {
           
           Rigidbody rb = Instantiate(sephere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
             
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
            rb.AddForce(transform.up * 7f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void DestroyEnemy()
    {
       Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, attackRange);
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 120;
    }

   
}
