using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAni : MonoBehaviour
{
    private Animator animator;

    public string boolName;

    // Start is called before the first frame update
    void Start()
    {
        // animator ������ (�� �ڽ��� ��ũ��Ʈ ������Ʈ�� ��ġ)������Ʈ�� ã�Ƽ� �־��.
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool current = animator.GetBool(boolName);
            animator.SetBool(boolName, !current);
        }
    }
}

public class boxAni : TestAni
{
    
}
