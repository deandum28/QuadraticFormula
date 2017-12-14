using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinionMathMayhem_Ship4 {
    public class Identity : MonoBehaviour {

        public Text canvas;

        public void setIdentity(string x)
        {
            canvas.text = x;
        }
    }
}