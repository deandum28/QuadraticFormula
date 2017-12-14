using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinionMathMayhem_Ship4
{
    public class GameEngine : MonoBehaviour
    {
        public ProblemBox equation;
        public GameObject[] targetMinions;
        public ProjectileShooting shootingController;
        public SpawnMinions[] numberProjectileMinions;
        public SpawnMinions[] xProjectileMinions;
        private int[] targetHit;

        private int indexA;
        private int indexB;
        private int indexC;

        private float discriminant;
        private float factorA;
        private float factorB;

        private string box1;
        private string box2;
        private string box3;
        private int box3Number;
        private string box4;
        private int box4Number;

        private int commonFactor1;
        private int commonFactor2;
        private int commonFactor3;
        private int commonFactor4;

        private int projectilesCount = 0;

        private int GameStateNumber = 1;
        private int GameStateX = 1;

        private void Start() { 
            GenerateNewProblem();
            targetHit = new int[4];
            for (int i = 0; i < 4; i++)
                targetHit[i] = 0;
        } // End Start

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E)) {
                GenerateNewProblem();
            }

            projectilesCount = shootingController.getShotsCount();
            if (projectilesCount % 2 == 0 && projectilesCount != 0)
                checkSuccess();
        } // End Update

        private void GenerateNewProblem() {
            GenerateEQN();
            Debug.ClearDeveloperConsole();
            Debug.Log("New Problem");
            GenerateBoxes();
            GenerateCommonFactors();
            UpdateTargets(targetMinions[0], box1);
            UpdateTargets(targetMinions[1], box2);
            UpdateTargets(targetMinions[2], box3);
            UpdateTargets(targetMinions[3], box4);
            setProjectilesNumbers();
            setProjectilesXs();
        } // End GenerateNewProblem

        private void GenerateEQN() {
            equation.Access_Generate();
            indexA = equation.Index_A;
            indexB = equation.Index_B;
            indexC = equation.Index_C;

            if (SolveEQN() == false)
                GenerateEQN();
        } // End GenerateEQN

        private bool SolveEQN() {
            discriminant = indexB * indexB - 4 * indexA * indexC;
            if (Mathf.Sqrt(discriminant) % 1 != 0)
                return false;
            
            float sqrtDiscriminant = Mathf.Sqrt(discriminant);

            factorA = (-1*indexB + sqrtDiscriminant) / 2 * indexA; factorA *= -1;
            factorB = (-1*indexB - sqrtDiscriminant) / 2 * indexA; factorB *= -1;
            return true;
        } // End SolveEQN

        private void UpdateTargets(GameObject target, string text) {
            Canvas textCanvas = target.gameObject.GetComponentInChildren<Canvas>();
            Text textCoef = textCanvas.gameObject.GetComponent<Text>();
            textCoef.text = text;
        } // End UpdateTargets

        private void GenerateBoxes() {
            box1 = indexA.ToString() + "X^2";
            box2 = indexC.ToString();

            int targetProd = indexA * indexC;
            int targetSum = indexB;

            int min = equation.getMinValue();
            int max = equation.getMaxValue();

            for (int i = min; i <= max; i++) {
                for (int j = min; j <= max; j++) {
                    if(i + j == targetSum && i * j == targetProd) {
                        int chances = Random.Range(0, 11);
                        if (chances <= 5)
                        {
                            box3 = i.ToString() + "X";
                            box3Number = i;
                            box4 = j.ToString() + "X";
                            box4Number = j;
                        }
                        else {
                            box4 = i.ToString() + "X";
                            box4Number = i;
                            box3 = j.ToString() + "X";
                            box3Number = j;
                        }
                        break;
                    }                     
                }
            }
        } // End Generate Boxes

        private void GenerateCommonFactors() {
            commonFactor1 = gcd(Mathf.Abs(box3Number), Mathf.Abs(indexC)); // |right
            if (box3Number < 0 && indexC < 0)
                commonFactor1 *= -1;
            commonFactor2 = gcd(Mathf.Abs(indexA), Mathf.Abs(box4Number)); // |left
            if (indexA < 0 && box4Number < 0)
                commonFactor2 *= -1;
            commonFactor3 = gcd(Mathf.Abs(indexA), Mathf.Abs(box3Number)); // -top 
            if (indexA < 0 && box3Number < 0)
                commonFactor3 *= -1;
            commonFactor4 = gcd(Mathf.Abs(box4Number), Mathf.Abs(indexC)); // -bootom
            if (box4Number < 0 && indexC < 0)
                commonFactor4 *= -1;

            Debug.Log("1st gcd is: " + commonFactor1.ToString());
            Debug.Log("2nd gcd is: " + commonFactor2.ToString());
            Debug.Log("3th gcd is: " + commonFactor3.ToString());
            Debug.Log("4th gcd is: " + commonFactor4.ToString());
        } // End Generate Common Factors

        private int gcd(int a, int b) {
            if (a == 0 || b == 0)
                return 0;
            if (a == b)
                return a;
            if (a > b)
                return gcd(a - b, b);
            return gcd(a, b - a);
        } // End GCD

        public void updateTargetArray(int index) {
            targetHit[index]++;
        }

        private void checkSuccess() {
            for (int i = 0; i < 4; i++) {
                if (targetHit[i] > 1) {
                    for (int j = 0; j < 4; j++)
                        targetHit[j] = 0;
                    Debug.Log("Incorrect - Restarting the level");
                }
            }

            if (targetHit[0] == 1 && targetHit[3] == 1 && targetHit[1] == 0 && targetHit[2] == 0) {
                Debug.Log("Correct");
                resetTargetArray();
            }
            else if (targetHit[1] == 1 && targetHit[3] == 1 && targetHit[0] == 0 && targetHit[2] == 0) {
                Debug.Log("Correct");
                resetTargetArray();
            }
            else if (targetHit[1] == 1 && targetHit[2] == 1 && targetHit[0] == 0 && targetHit[3] == 0) {
                Debug.Log("Correct");
                resetTargetArray();
            }
            else if (targetHit[0] == 1 && targetHit[2] == 1 && targetHit[1] == 0 && targetHit[3] == 0) {
                Debug.Log("Correct");
                resetTargetArray();
            }
            else {
                for (int i = 0; i < 4; i++)
                    targetHit[i] = 0;
                Debug.Log("Incorrect - Restarting the level");
            }
        }

        private void resetTargetArray() {
            for (int i = 0; i < 4; i++)
                targetHit[i] = 0;
        }

        private void setProjectilesNumbers() {
            int correctMinion = Random.Range(0, 2);
            if (GameStateX == 1)
                numberProjectileMinions[correctMinion].setNumber(commonFactor3.ToString());
            else numberProjectileMinions[correctMinion].setNumber(commonFactor4.ToString());

            for (int i = 0; i < numberProjectileMinions.Length; i++)
            {
                if (correctMinion != i)
                {
                    int randomIndex = Random.Range(equation.getMinValue(), equation.getMaxValue());
                    numberProjectileMinions[i].setNumber(randomIndex.ToString());
                }
            }
        }


        private void setProjectilesXs() {
            int correctMinion = Random.Range(0, 2);
            if (GameStateX == 1)
                xProjectileMinions[correctMinion].setNumber(commonFactor3.ToString() + "X");
            else xProjectileMinions[correctMinion].setNumber(commonFactor4.ToString() + "X");

            for (int i = 0; i < xProjectileMinions.Length; i++) {
                if(correctMinion != i) {
                    int randomIndex = Random.Range(equation.getMinValue(), equation.getMaxValue());
                    xProjectileMinions[i].setNumber(randomIndex.ToString() + "X");
                }
            }
        }

    }
}
