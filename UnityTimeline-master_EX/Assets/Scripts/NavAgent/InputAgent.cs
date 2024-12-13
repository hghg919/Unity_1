using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAgent : BaseAgent
{
    Transform cam;
    Vector2 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        inputVector = new Vector2(horizontal,vertical);

        // ���� * �ӷ� * �ð�
        Vector3 dirVec = cam.right * inputVector.x
            + cam.forward * inputVector.y;

        agent.SetDestination(transform.position + dirVec.normalized);
    }
}
