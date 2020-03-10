using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAi : MonoBehaviour
{
    BehaviourTree tree;

    private void Start()
    {
        tree = new BehaviourTree();
        Sequence seq = new Sequence();
        tree.radacina.AddNod(seq);
        //seq.AddNod()
    }
}
