using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node 
{
    public enum Status{
        Running,
        Success,
        Failure,
        None,
    }
    protected Status status;
    protected virtual void Start()
    {
        status = Status.None;
    }
    protected virtual Status Execute()
    {
        return Status.None;
    }

    protected virtual void Exit()
    {
        
    }
    public virtual Status Tick()
    {
        if (status == Status.None)
            Start();
        status = Execute();
        if (status != Status.Running)
            Exit();
        return status;
    }
    

}
