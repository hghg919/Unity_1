using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic.Prototype2
{
    public class PM_2 : MonoBehaviour
    {
        public float speed = 5.0f;
        public GameObject food;


        // Start는 첫 프레임 전에 호출됩니다
        void Start()
        {

        }

        // Update는 매 프레임마다 호출됩니다
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
            // Debug.Log($"입력받은 수평 값 : {horizontalInput}");
            transform.position = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Vector3 foodpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform(food, transform.position);
            }
        }
    }
}
