using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    //Waypoint
    NavMeshAgent agent;
    public Transform[] wayPoints;
    int wayPointIndex;
    Vector3 target;
    Transform targetLocation;

    //FOV
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public GameObject targetRef;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool canSeePlayer;

    public float walkSpeed;
    public float runSpeed;
    public float damageMultiplier = 1;

    GameObject key;
    bool keyExists;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();

        targetRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        canSeePlayer = false;
        key = GameObject.Find("Exit_GateKey");
        keyExists = (GameObject.Find("Exit_GateKey") != null);

    }

    void Update()
    {
        updateKeyExistance();
        if(Vector3.Distance(transform.position, target) < 1 && !canSeePlayer){
            IterateWaypointIndex();
            Debug.Log("Current Waypoint is :" + wayPointIndex);
            UpdateDestination();
            this.gameObject.transform.LookAt(target);
            agent.speed = walkSpeed;
        }
        else if (canSeePlayer)
        {
            targetLocation = targetRef.transform;
            UpdateDestination();
            Vector3 direction = (targetLocation.position - transform.position).normalized;
            this.gameObject.transform.LookAt(targetLocation);
            agent.speed = runSpeed;
        }
        else if (!keyExists) //Start Swarm Mode
        {
            canSeePlayer = true;
            Debug.Log("Swarm Mode : Activated");
            targetLocation = targetRef.transform;
            UpdateDestination();
            Vector3 direction = (targetLocation.position - transform.position).normalized;
            this.gameObject.transform.LookAt(targetLocation);
            agent.speed = runSpeed+2;
        }
       
    }

    //Waypoint
    void UpdateDestination()
    {
        if (!canSeePlayer)
        {
            target = wayPoints[wayPointIndex].position;
        }
        else if (canSeePlayer)
        {
            target = targetRef.transform.position;
        }

        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        if (!canSeePlayer)
        {
            wayPointIndex = wayPointIndex + 1;
            if (wayPointIndex == wayPoints.Length)
            {
                wayPointIndex = 0;
            }
        }
    }


    //FOV
    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < viewAngle/2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    canSeePlayer = true;
                    Debug.Log("Player spoted by enemy!");
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            Debug.Log("Enemy has lost sight of you");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (keyExists)
            {
                FindObjectOfType<HealthManager>().takeDamage(2 * damageMultiplier);
            }
            else
            {
                FindObjectOfType<HealthManager>().takeDamage((3 * damageMultiplier)+1);
            }
        }
        if (collision.gameObject.GetComponent<ProjectileController>())
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    //Swarm Mode
    private void updateKeyExistance()
    {
        if (GameObject.Find("Exit_GateKey") != null)
        {
            keyExists = true;
        }
        else
        {
            keyExists = false;
        }
    }

}
