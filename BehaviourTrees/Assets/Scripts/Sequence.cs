using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{

    private Status executeStatus, childStatus;
   
    public Sequence(List<Node>nodeList)
    {
        ListaNoduri = nodeList;
    }

    protected override void Start()
    {
        GameManager.Instance.StartCoroutine(realExecution());
    }


    IEnumerator Recursive(Node nod)
    {
        while (true)
        {
            childStatus = nod.Tick();
            if (childStatus == Status.Running)
            {
                yield return new WaitForEndOfFrame();
            }
            else
            {
                Debug.Log("has finished coroutine");
                break;
            }
        }
    }
    IEnumerator realExecution()
    {
        foreach (Node nod in ListaNoduri)
        {
            yield return GameManager.Instance.StartCoroutine(Recursive(nod));
            
            if (childStatus == Status.Failure)
            {
                executeStatus = Status.Failure;
            }
            else if (childStatus == Status.Running || childStatus == Status.Success)
                executeStatus = Status.Running;
            Tick();
            if (executeStatus == Status.Failure)
                yield break;
        }

    }
    protected override Status Execute()
    {
        return executeStatus;
    }
    protected override void Exit()
    {
        base.Exit();
    }
    public override Status Tick()
    {
        return base.Tick();
    }
}
