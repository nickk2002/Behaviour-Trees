using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviourTree
{  
    public Composite radacina;
    
    public BehaviourTree()
    {
        radacina = new Composite();

    }
    public void Run()
    {
        radacina.Tick();
    }

}

