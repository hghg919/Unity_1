using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic
{
    public class cameraMove : MonoBehaviour
    {
        public GameObject target; // 카메라가 쪼ㅉ아갈 대상

        private Vector3 offset; // 카메라와 대상의 시작 거리

        // Start is called before the first frame update
        void Start()
        {
            offset = transform.position - target.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.transform.position + offset;
        }
    }
}
