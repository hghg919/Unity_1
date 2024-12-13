using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBasic.Prototype2
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 6f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Animal"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
