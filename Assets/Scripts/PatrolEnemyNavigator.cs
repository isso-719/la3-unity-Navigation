using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemyNavigator : MonoBehaviour
{
    public Transform[] wayPoints;
    int currentRoot;
    NavMeshAgent agent;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPosition = wayPoints[currentRoot].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            currentRoot += 1;
            if (currentRoot > wayPoints.Length - 1)
            {
                currentRoot = 0;
            }
            targetPosition = wayPoints[currentRoot].position;
            agent.SetDestination(targetPosition);
        }
    }
}
