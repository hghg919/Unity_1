using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic.Prototype2
{
    public class SpawnAinmal : MonoBehaviour
    {
        [Header("몬스터 소환 세팅")]
        public GameObject animalPrefab;
        public float spawnTime = 3f;
        private float cheakTime = 0f;

        public int limatX = 17;

        // Start is called before the first frame update
        void Start()
        {
            Instantiate(animalPrefab);
        }

        // Update is called once per frame
        void Update()
        {
            // 대기 시간

            spawnAinmals();
        }

        private void spawnAinmals()
        {
            cheakTime += Time.deltaTime;

            if (cheakTime >= spawnTime)
            {
                cheakTime = 0f;

                int randomX = Random.Range(-limatX, limatX);

                Vector3 spwanPos = new Vector3(randomX, 0, 19);

                Instantiate(animalPrefab, spwanPos, animalPrefab.transform.rotation);
            }
        }
    }
}
