using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace UnityBasic
{
    public class TempMyCode : MonoBehaviour
    {
        /*
         * dog 
         * 개의 이름, string
         * 개의 나이, int
         * 개가 짖는 소리 void bark()
        */

        // 컴퍼넌트 스스로 자기자신의 기능을 실행하도록 다룬다.
        // 유니티 이벤트 함수 -> Life cycle 갖습니다.

        [System.Serializable]
        public class Dog
        {
            public string DogName;
            public int Age;

            public void Bark()
            {
                Debug.Log("왈왈!");
            }
        }

        public Dog myDog;

        // Start is called before the first frame update
        void Start()
        {
            ShowStatus();
        }

        private void ShowStatus()
        {
            Debug.Log($"나의 반려 동물의 이름 : {myDog.DogName}, 반려 동물의 나이 : {myDog.Age}");
            myDog.Bark();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ChnageDogName();
                ChangeDogAge();
                ShowStatus();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                ChnageDogName();
                ChangeDogAge();
                ShowStatus();
            }
        }

        public string ModifyName;
        public int ModifyAge;

        private void ChnageDogName()
        {
            myDog.DogName = ModifyName;
        }

        private void ChangeDogAge()
        {
            myDog.Age = ModifyAge;
        }
    } 
}