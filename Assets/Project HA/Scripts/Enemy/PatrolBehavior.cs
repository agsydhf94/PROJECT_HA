using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : StateMachineBehaviour
{
    float timer = 0;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent navMeshAgent;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("EnemyWaypoints").transform;
        foreach (Transform wayPointElements in wayPointsObject)
        {
            wayPoints.Add(wayPointElements);
        }
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(wayPoints[0].position);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }

    
}
