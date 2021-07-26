using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviourOnPatrol : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;
 
    private int locationIndex = 0;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }
    
    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        { 
            locations.Add(child);
        }
    }
    
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            agent.destination = player.position;
            Debug.Log("Enemy detected!");
        }
    }
}
