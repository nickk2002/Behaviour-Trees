using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class MovementAI
{
    public class GoToLocation {

        static void Initial(GameObject currentBot, Vector3 destination, float stoppingDistance = 0.1f, float speed = 3.5f, float turningSpeed = 120f)
        {
            NavMeshAgent agent = currentBot.GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("The agent : " + currentBot + " does not have a navmeshagent script on it");
            }
            else
            {
                agent.speed = speed;
                agent.angularSpeed = turningSpeed;
                agent.SetDestination(destination);
            }
        }
        public static Status Execute(GameObject currentBot, Vector3 destination, float stoppingDistance = 0.1f)
        {
            NavMeshAgent agent = currentBot.GetComponent<NavMeshAgent>();
            if (agent == null) {
                Debug.LogError("The agent : " + currentBot + " does not have a navmeshagent script on it or there is no initial called in action node");
                return Status.Failure;
            }
            if (agent.stoppingDistance > stoppingDistance)
                return Status.Running;
            else
            {
                agent.isStopped = true;
                return Status.Success;
            }

        }
    }
}
