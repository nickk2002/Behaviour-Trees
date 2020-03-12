using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
