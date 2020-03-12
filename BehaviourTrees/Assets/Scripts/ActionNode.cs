using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionNode : Node
{
    
  

    public ActionNode(Func<Status> execute, Action start = null, Action exit = null) : base(execute, start, exit)
    {

    }

    protected override void Start()
    {
        base.Start();
    }
 
    protected override Status Execute()
    {
        return base.Execute();
    }

    protected override void Exit()
    {

        base.Exit();
    }
    public override Status Tick()
    {
        Status status = base.Tick();
        return status;
        
    }


}
