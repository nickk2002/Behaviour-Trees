using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class TestAi : MonoBehaviour
{
    NavMeshAgent agent;
    BehaviourTree tree;
    MeshRenderer mesh;
    Rigidbody rigidbody;
    Vector3 random = new Vector3(0, 0, 0);
    void GoToLocationStart()
    {

        agent.SetDestination(random);
    }
    Status GoToLocation()
    {
        if (Vector3.Distance(transform.position, random) > 3f)
        {
            return Status.Running;
        }

        if (agent.remainingDistance <= 3f)
        {
            agent.isStopped = true;
            return Status.Success;
        }

        return Status.Failure;
    }
    Quaternion initial, reach;
    float initialTime;
    void StartRotate()
    {
        initialTime = Time.time;
        initial = transform.rotation;
        reach = initial * Quaternion.Euler(0, 120, 0);
    }
    Status RotateObj()
    {
        transform.rotation = Quaternion.Slerp(initial, reach, (Time.time - initialTime) / 3f);
        if (Mathf.Abs(transform.eulerAngles.y - initial.eulerAngles.y - 120f) < 2f)
        {
            return Status.Success;
        }
        return Status.Running;
    }
    Status Jump()
    {
        rigidbody.AddForce(10, 0, 0, ForceMode.Impulse);
        if (transform.position.z >= 10)
            return Status.Success;
        return Status.Running;
    }
    float timeStart;
    Color initialCol;
    void StartChangeColor()
    {
        timeStart = Time.time;
        initialCol = mesh.material.color;
    }
    Status ChangeColor()
    {
        mesh.material.color = Color.Lerp(initialCol, Color.black, (Time.time - initialTime) / 10f);
        if (mesh.material.color == Color.black)
            return Status.Success;
        if (Time.time - timeStart >= 10f)// daca schimbi aici in 5f o sa dea failure poti testa;
            return Status.Failure;
        return Status.Running;
    }
    Status Ceva(int a)
    {
        return Status.None;
    }

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        tree = new BehaviourTree
        (
            new Sequence(
                new List<Node>{ 
                   
                    new ActionNode((Func<Status>)GoToLocation,GoToLocationStart,null,10),
                    new ActionNode((Func<Status>)RotateObj,StartRotate),
                    new Sequence(
                        new List<Node>
                        {
                            new ActionNode((Func<Status>)ChangeColor,StartChangeColor),
                        }
                    )
                }
             )
        );
       

    }
    private void Update()
    {
        tree.Run();
    }

}
