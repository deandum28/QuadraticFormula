using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinionMathMayhem_Ship4 {
    public class TargetController : MonoBehaviour {

        public float movementSpeed = 75.0f;

        private bool activeTargeting = true;

        private void Start() {
            activeTargeting = true;
            
        }

        void Update()
        {
            if (activeTargeting == true)
            {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

                transform.Translate(x, 0, z);
            }
        }

        public void activateTargeting() {
            activeTargeting = true;
        }

        public void deactivateTargeting() {
            activeTargeting = false;
        }
    }
}
