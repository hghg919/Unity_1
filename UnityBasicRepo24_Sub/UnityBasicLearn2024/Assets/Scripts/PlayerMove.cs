using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic
{
    public class PlayerMove : MonoBehaviour
    {
        public float speed = 5f;
        public float speedModfier = 0.2f;

        public int turnspeed = 45;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(speed * Vector3.forward * Time.deltaTime * vertical);
            transform.Rotate(Vector3.up, turnspeed * horizontal * Time.deltaTime);

            // 컴포넌트 위치 변경
            // transform.position += speed * Vector3.forward * Time.deltaTime; // new Vector3(1,0,0)
        }
    }
}
