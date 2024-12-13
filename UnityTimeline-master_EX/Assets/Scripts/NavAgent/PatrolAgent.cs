using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAgent : BaseAgent
{
    public Transform[] targets;
    int targetIndex = -1;

    Action onComplete;

    // Start is called before the first frame update
    void Start()
    {
        onComplete += SetTarget;
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //    SetTarget();
        //}

        if(agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            float remainDistance = agent.remainingDistance;

            if(remainDistance <= agent.stoppingDistance)
            {
                onComplete?.Invoke();
            }
        }
    }

    void SetTarget()
    {
        targetIndex = (targetIndex + 1) % targets.Length;

        agent.SetDestination(targets[targetIndex].position);
    }
}
