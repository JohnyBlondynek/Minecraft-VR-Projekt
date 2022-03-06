using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class AIMovement : MonoBehaviour
{
    int speed;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Transform[] Waypints;
    public int WayPointIndex;
    public bool RandomWaypint;
    public FieldOfView fieldOfView;
    public Animator[] animators;
    public int zdrowie;
    public void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.GetComponent<Rigidbody>();
        Waypints[0] = GameObject.Find("Waypint").transform;
        zdrowie = 3;
    }
    public float szukanie=3;
    bool czyn;
    private void Update()
    {
        if (zdrowie <= 0)
        {
            FindObjectOfType<Player>().punkty++;
            Destroy(gameObject);
            FindObjectOfType<spawnZombie>().ograniczenia--;
        }
        if (!czyn)Move();
        else
        {
            agent.enabled = false;
        }
    }
    void Move()
    {
        //Check for sight and attack range
        ChasePlayer();
        agent.speed = speed;
    }
    void szukanieGracza()
    {
        szukanie = 0;
    }

    private void Patroling()
    {
        speed = 3;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
            if (RandomWaypint)
            {
                WayPointIndex = Random.Range(0, Waypints.Length);
            }
            else
            {
                if (WayPointIndex < Waypints.Length) WayPointIndex++;
                if (WayPointIndex == Waypints.Length) WayPointIndex = 0;
            }
            walkPoint = new Vector3(Waypints[WayPointIndex].transform.position.x, Waypints[WayPointIndex].transform.position.y, Waypints[WayPointIndex].transform.position.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        speed = 7;
       agent.SetDestination(player.position);
        szukanie += 1 * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sword") zdrowie--;
    }
}
