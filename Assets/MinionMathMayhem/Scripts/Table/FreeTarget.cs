using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MinionMathMayhem_Ship4 {
    public class FreeTarget : MonoBehaviour {

        private bool free = true;

        private void Start() {
            free = true;
        }

        public bool isFree() {
            return free;
        }


    }
}
