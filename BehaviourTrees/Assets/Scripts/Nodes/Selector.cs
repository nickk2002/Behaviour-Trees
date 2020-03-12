using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public Selector(List<Node>nodeList)
    {
       
       ListaNoduri = nodeList;
    }
    protected override void Start()
    {
        base.Start();
    }
    public override Status Execute()
    {
        foreach(Node nod in ListaNoduri)
        {
            switch (nod.Evaluate())
            {
                case Status.Failure:
                    continue;
                case Status.Success:
                    currentStatus = Status.Success;
                    return currentStatus;
                case Status.Running:
                    currentStatus = Status.Running;
                    return currentStatus;
                
            }
        }
        currentStatus = Status.Failure;
        return currentStatus;
    }

    protected override void Exit()
    {
        base.Exit();
    }

  
}
