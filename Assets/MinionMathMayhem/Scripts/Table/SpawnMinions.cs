using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinionMathMayhem_Ship4 {
    public class SpawnMinions : MonoBehaviour {
        
        public bool isClickable = false;

        private Text number;
        private GameObject canonObject;
        private ProjectileShooting canonScript;


        private void Start() {
            number = gameObject.GetComponent<Text>();
            number.text = "0";
            canonObject = GameObject.FindGameObjectWithTag("canon");
            canonScript = canonObject.GetComponent<ProjectileShooting>();
        }

        private void OnMouseDown() {
            if(isClickable == true && GameObject.FindWithTag("Projectile") == null)
                canonScript.instantiatetProjectile(number.text);
        }

        public string getNumber() {
            return number.text;
        }

        public void setNumber(string x) {
            number.text = x;
        }
    }
}