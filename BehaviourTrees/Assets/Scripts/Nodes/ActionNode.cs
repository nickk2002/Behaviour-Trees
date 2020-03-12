using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionNode : Node
{


    Delegate executeFunc;
    public ActionNode(Delegate execute, Action start = null, Action exit = null, params object[] args) : base(execute, start, exit,args)
    {

    }
    public ActionNode(GameObject currentBot, Vector3 destination, float stoppingDistance = 0.1f, float speed = 3.5f, float turningSpeed = 120f)
    {

    }

    protected override void Start()
    {
        base.Start();
    }
    public override Status Execute()
    {
        return base.Execute();
    }

    protected override void Exit()
    {

        base.Exit();
    }
    public override Status Evaluate()
    {
        Status status = base.Evaluate();
        return status;
        
    }


}
