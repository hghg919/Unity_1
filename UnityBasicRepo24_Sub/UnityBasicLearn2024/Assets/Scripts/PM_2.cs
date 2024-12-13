using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic.Prototype2
{
    public class PM_2 : MonoBehaviour
    {
        public float speed = 5.0f;
        public GameObject food;


        // Start�� ù ������ ���� ȣ��˴ϴ�
        void Start()
        {

        }

        // Update�� �� �����Ӹ��� ȣ��˴ϴ�
        void Update()
        {
            if(transform.position.x < -15)
            {
                transform.position = new Vector3(-15,transform.position.y, transform.position.z);
            }
            if(transform.position.x > 15)
            {
                transform.position = new Vector3(15, transform.position.y, transform.position.z);
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            // Debug.Log($"�Է¹��� ���� �� : {horizontalInput}");
            transform.position = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Vector3 foodpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform(food, transform.position);
            }
        }
    }
}
