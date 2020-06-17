using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float patrolTime = 15.0f; // time in seconds to wait before seeking a new patrol destination
    public float aggroRange = 10; // distance in scene units below which the NPC will increase speed and seek the player
    public Transform[] waypoints; // collection of waypoints which define a patrol area

    int index; // the current waypoint index in the waypoints array
    float speed, agentSpeed; // current agent speed and NavMeshAgent component speed
    Transform player; // reference to the player object transform

    Animator animator; // reference to the animator component
    NavMeshAgent agent; // reference to the NavMeshAgent

    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) { agentSpeed = agent.speed; }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypoints.Length);

        StartCoroutine(tick());

        if(waypoints.Length > 0)
        {
            StartCoroutine(patrol());

        }
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }


    IEnumerator tick()
    {
        while (true)
        {
            agent.speed = agent.speed / 2;
            agent.destination = waypoints[index].position;

            if(player != null && Vector3.Distance(transform.position, player.position) < aggroRange)
            {
                agent.destination = player.position;
                agent.speed = agentSpeed;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator patrol()
    {
        while (true)
        {
        index = index == waypoints.Length - 1 ? 0 : index + 1;

        yield return new WaitForSeconds(patrolTime);
        }
    }
}
