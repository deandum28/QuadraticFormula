using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinionMathMayhem_Ship
{
    public class DisableGeneralEquation : MonoBehaviour
    {
        public GameObject equation;
        public AI_GameChallenge AIComplexity;

        // Update is called once per frame
        void Update()
        {
            if (AIComplexity.getComplex() == true)
                equation.SetActive(false);
            else equation.SetActive(true);
        }
    }
}