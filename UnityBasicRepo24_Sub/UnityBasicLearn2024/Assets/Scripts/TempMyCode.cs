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
         * ���� �̸�, string
         * ���� ����, int
         * ���� ¢�� �Ҹ� void bark()
        */

        // ���۳�Ʈ ������ �ڱ��ڽ��� ����� �����ϵ��� �ٷ��.
        // ����Ƽ �̺�Ʈ �Լ� -> Life cycle �����ϴ�.

        [System.Serializable]
        public class Dog
        {
            public string DogName;
            public int Age;

            public void Bark()
            {
                Debug.Log("�п�!");
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
            Debug.Log($"���� �ݷ� ������ �̸� : {myDog.DogName}, �ݷ� ������ ���� : {myDog.Age}");
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