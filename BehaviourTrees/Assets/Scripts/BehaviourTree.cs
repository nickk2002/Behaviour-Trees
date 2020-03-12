using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviourTree
{  
    public Node radacina;
    
    public BehaviourTree()
    {
        radacina = new Node();

    }
    public BehaviourTree(Node node)
    {
        radacina = node;

    }
    public void Run()
    {
        if(radacina.CurrentStatus == Status.Running || radacina.CurrentStatus == Status.None)
            radacina.Evaluate();
    }

}

