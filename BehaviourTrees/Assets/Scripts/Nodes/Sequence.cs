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
        
    }

    public override Status Execute()
    {
        
        foreach(Node node in ListaNoduri)
        {
            switch (node.Evaluate())
            {
                case Status.Failure:
                    currentStatus = Status.Failure;
                    return currentStatus;
                case Status.Success:
                    continue;
                case Status.Running:
                    currentStatus = Status.Running;
                    return currentStatus; /// daca deja este unul running inseamna ca si sequence e running
            }
        }
        return Status.Success;
    }
    protected override void Exit()
    {
        base.Exit();
    }
    public override Status Evaluate()
    {
        return base.Evaluate();
    }
}
