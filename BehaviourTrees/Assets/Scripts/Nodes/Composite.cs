using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite : Node
{
    protected List<Node> ListaNoduri;
    public Composite()
    {
        ListaNoduri = new List<Node>();
    }
    public void AddNod(Node nod)
    {
        ListaNoduri.Add(nod);
    }
    protected override void Start()
    {
      
    }
    public override Status Execute()
    {
        return base.Execute();
    }
    public override Status Evaluate()
    {
        //Debug.Log("Status of composite : " + this.GetType().Name + " " + status);
        return base.Evaluate();
    }

    protected override void Exit()
    {
        
    }
}
