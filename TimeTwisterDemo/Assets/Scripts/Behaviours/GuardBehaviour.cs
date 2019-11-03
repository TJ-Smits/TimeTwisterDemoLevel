using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;

    public Transform player;

    public float sightReach;

    public float fov;

    private GuardStates currentState;

    public enum GuardStates
    {
        Patrol,
        Chase,
        Attack,
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Vector3 newDestination = new Vector3(transform.position.x + Random.Range(0.0f, 1.0f), transform.position.y, transform.position.z + Random.Range(0.0f, 1.0f));
        _agent.SetDestination(newDestination);

        currentState = GuardStates.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GuardStates.Patrol: UpdatePatrolState(); break;
            case GuardStates.Chase: UpdateChaseState(); break;
        }
    }


    private void UpdatePatrolState()
    {
        if(_agent.remainingDistance <= _agent.stoppingDistance)
        {
            SetRandomDestinationForAgentNearTarget(transform, 5.0f, -5.0f);
        }


        if (Vector3.Distance(transform.position, player.position) < sightReach && LineOfSight(player))
        {
            currentState = GuardStates.Chase;
            Debug.Log("Switch to chase state");
        }
    }

    private void UpdateChaseState() 
    {
        SetRandomDestinationForAgentNearTarget(player, 1.0f, -1.0f);

        if (!LineOfSight(player))
        {
            currentState = GuardStates.Patrol;
            Debug.Log("Switch to patrol state");
        }
    }


    // Based on http://answers.unity3d.com/answers/20007/view.html
    // Modified by Willbl3pic
    /// <summary>
    /// Checks the line of sight to the target.
    /// </summary>
    /// <returns><c>true</c>, if there is line of sight to the target, <c>false</c> otherwise.</returns>
    /// <param name="target">Target.</param>
    bool LineOfSight(Transform target)
    {
        RaycastHit hit;
        if (Vector3.Angle(target.position - transform.position, transform.forward) <= fov &&
            Physics.Linecast(transform.position, target.position, out hit) &&
            hit.collider.transform == target)
        {
            return true;
        }
        return false;
    }

    private void SetRandomDestinationForAgentNearTarget(Transform target, float minPos, float maxPos)
    {
        Vector3 newDestination = new Vector3(
            target.position.x + UnityEngine.Random.Range(minPos, maxPos),
            target.position.y,
            target.position.z + UnityEngine.Random.Range(minPos, maxPos)
            );
        _agent.SetDestination(newDestination);
    }
}
