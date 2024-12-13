using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAgent : BaseAgent 
{
    public Transform target;

    private void Start()
    {
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
