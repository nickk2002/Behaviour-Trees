using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite : Node
{
    protected List<Node> ListaNoduri;
    public void AddNod(Node nod)
    {
        ListaNoduri.Add(nod);
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override Status Execute()
    {
        return base.Execute();
    }
    public override Status Tick()
    {
        return base.Tick();
    }

    protected override void Exit()
    {
        base.Exit();
    }


}
