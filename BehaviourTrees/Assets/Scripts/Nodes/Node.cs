using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Node
{

    protected Status currentStatus = Status.None;
    protected Action startAction;
    protected Delegate executeDelegate;
    protected Action exitAction;
    protected string nameStart, nameExecute, nameExit;
    private object[] executeArgs;

    public Status CurrentStatus
    {
        get { return currentStatus; }
    }
    public Node()
    {
        currentStatus = Status.None;
    }
    public Node(Delegate execute, Action start = null, Action exit = null, params object[] args)
    {
        startAction = start;
        executeDelegate = execute;
        exitAction = exit;
        nameStart = start?.Method.Name;
        nameExecute = execute.Method.Name;
        nameExit = exit?.Method.Name;
        executeArgs = args;
    }
    protected virtual void Start()
    {
        if (startAction != null)
        {
            Debug.Log("Starting : " + nameStart);
            startAction.Invoke();
        }
    }
    private Status GetDelegateResult(Delegate function,params object[] arguments)
    {
        return (Status)function.DynamicInvoke(arguments);
    }
    public virtual Status Execute()
    {
        return GetDelegateResult(executeDelegate,executeArgs);
    }

    protected virtual void Exit()
    {
        if (exitAction != null)
        {
            Debug.Log("Exiting : " + nameExit);
            exitAction.Invoke();
        }
    }
    public virtual Status Evaluate()
    {
        
        if (currentStatus == Status.None)
            Start();
        currentStatus = Execute();
    
        if (nameExecute != null)
        {
            Debug.Log("The status exiting for : " + nameExecute + " is : " + currentStatus);
        }else
            Debug.Log("The status exiting for composite : " + this.GetType().Name + " " + currentStatus);
        if (currentStatus != Status.Running)
        {
            Exit();
        }
        return currentStatus;
    }


}

