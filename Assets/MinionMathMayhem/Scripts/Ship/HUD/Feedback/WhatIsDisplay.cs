using UnityEngine;
using System.Collections;


namespace MinionMathMayhem_Ship
{
    public class WhatIsDisplay : MonoBehaviour
    {
        /*                      WHAT IS DISPLAY [HUD'ish]
         * Within this script, this will activate the 'WHAT IS...' animation within the animator.  In addition, this will also display the current selected index [A, B, C] with the 'WHAT IS...' message.
         * 
         * 
         * GOALS:
         *  Display the 'WHAT IS...' with the index [A|B|C] message on to the screen.
         */



        // Declarations and Initializations
        // ---------------------------------
            // Text Object: What Is
                public GameObject whatIsTextbox;
            // Animation: What Is
                private Animator whatIsAnim;
            // Text Object: Index Char
                public GameObject eventLetterTextbox;
            // Animation: Index Char
                private Animator eventLetterAnim;

        private bool mustPauseHere = false;
        private bool gamePaused = false;

        // Quadratic Formula Animation
        public GameObject QuadraticFormula;
        private Animator FormulaAnimator;
        // ----

        public GameObject TextToShowOnPause;
        public float SecondsToPause;



        // This function will be called when the actor has been activated within the virtual world.
        void Awake()
        {
            // Initialize the internal object's components
                whatIsAnim = whatIsTextbox.GetComponent<Animator>();
                eventLetterAnim = eventLetterTextbox.GetComponent<Animator>();
                FormulaAnimator = QuadraticFormula.GetComponent<Animator>();
                TextToShowOnPause.SetActive(false);
        } // Awake()

        void Update()
        {
            if (mustPauseHere == true)
            {
                gamePaused = true;
                mustPauseHere = false;
                StartCoroutine(WaitForUser(SecondsToPause));
            }

            if(Input.anyKey && gamePaused == true)
            {
                gamePaused = false;
                mustPauseHere = false;
                TextToShowOnPause.SetActive(false);
                Time.timeScale = 1;
                AudioListener.volume = 1;
            }
        }

        // Plays the what is "A, B, or C" animation
        private IEnumerator NextLetterEventPlay(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            whatIsAnim.SetTrigger("Slide");
            eventLetterAnim.SetTrigger("SlideIn");
            FormulaAnimator.SetTrigger("ShakeFormula");
        } // NextLetterEventPlay()

        private IEnumerator WaitForUser(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            AudioListener.volume = 0;
            Time.timeScale = 0;
            Cursor.visible = true;
            TextToShowOnPause.SetActive(true);
        }

        // Allow other objects to gain access to the 'NextLetterEventPlay' function.
        public void Access_NextLetterEventPlay(float waitTime)
        {
            mustPauseHere = true;
            StartCoroutine(NextLetterEventPlay(waitTime));

        } // Access_NextLetterEventPlay()
    } // End of Class
} // Namespace