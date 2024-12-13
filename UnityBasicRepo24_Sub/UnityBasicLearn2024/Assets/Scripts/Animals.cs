using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic.Prototype2
{
    public class Animals : MonoBehaviour
    {
        public float speed = 3.0f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = transform.position + Vector3.back * speed * Time.deltaTime;

            // 충동했을 때

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("End"))
            {
                Debug.Log("게임오버");

            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("End"))
            {
                Debug.Log("충돌 종료");

            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.CompareTag("End"))
            {
                Debug.Log("충돌 진행 중");
            }
        }
    }
}
