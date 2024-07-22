using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : StateMachineBehaviour
{
    float timer = 0;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent navMeshAgent;
    private int lastSelectedIndex = -1;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        GameObject[] wayPointsObject = GameObject.FindGameObjectsWithTag("EnemyWaypoints");
        foreach (GameObject wayPointElements in wayPointsObject)
        {
            wayPoints.Add(wayPointElements.transform);
        }
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        int randomIndex = Random.Range(0, wayPoints.Count);
        while (randomIndex == lastSelectedIndex)
        {
            randomIndex = Random.Range(0, wayPoints.Count);
        }
        lastSelectedIndex = randomIndex;
        navMeshAgent.SetDestination(wayPoints[randomIndex].position);
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
