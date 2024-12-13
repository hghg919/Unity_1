using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAgent : BaseAgent
{
    RaycastHit rayHit = new RaycastHit();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray.origin, ray.direction, out rayHit))
            {
                agent.destination = rayHit.point;
            }
        }
    }
}
