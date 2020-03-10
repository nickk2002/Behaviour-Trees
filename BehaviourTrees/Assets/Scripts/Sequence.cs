using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    protected override void Start()
    {
        status = Status.Running;
    }
    protected override Status Execute()
    {
        foreach(Node nod in ListaNoduri)
        {
            Status status = nod.Tick();
            if (status == Status.Failure)
                return Status.Failure;
        }
        return Status.Success;
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
