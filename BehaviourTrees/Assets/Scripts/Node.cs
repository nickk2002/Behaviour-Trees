using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Node
{
    public enum Status
    {
        Running,
        Success,
        Failure,
        None,
    }
    protected Status status = Status.None;
    protected Action startAction;
    protected Func<Status> executeAction;
    protected Action exitAction;
    protected string nameStart, nameExecute, nameExit;
    public Node()
    {
        status = Status.None;
    }
    public Node(Func<Status> execute, Action start = null, Action exit = null)
    {
        startAction = start;
        executeAction = execute;
        exitAction = exit;
        nameStart = start?.Method.Name;
        nameExecute = execute.Method.Name;
        nameExit = exit?.Method.Name;

    }
    protected virtual void Start()
    {
        if (startAction != null)
        {
            Debug.Log("Starting : " + nameStart);
            startAction?.Invoke();
        }
    }
    protected virtual Status Execute()
    {
        Debug.Log("Executing : " + nameExecute);
        return executeAction.Invoke();
    }

    protected virtual void Exit()
    {
        if (exitAction != null)
        {
            Debug.Log("Exiting : " + nameExit);
            exitAction?.Invoke();
        }
    }
    public virtual Status Tick()
    {
        if (status == Status.None)
            Start();
        status = Execute();
        if (status != Status.Running)
        {
            Exit();
            if (nameExecute != null)
            {
                Debug.Log("The status exiting for : " + nameExecute + " is : " + status);
            }else
                Debug.Log("The status exiting for composite : " + this.GetType().Name + " " + status);
        }
        return status;
    }


}

