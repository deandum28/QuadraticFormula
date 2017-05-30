using UnityEngine;
using UnityEngine.UI; // To use the 'text' type, we must include this
using System.Collections;

namespace MinionMathMayhem_Ship
{
    public class LetterBox : MonoBehaviour
    {

        /*                         LETTER BOX
         * Within the Letter Box object, this will randomly select which letter index to select [A|B|C].
         *   This random generator chooses only the 'charactor' of the index: A, B, or C.  The output given is a char.
         * 
         * STRUCTURAL DEPENDENCY NOTES:
         *      GAME EVENT
         *        |_ Letter Box
         *        
         * INPUT \ OUTPUT
         *      INPUT:
         *          Access_Generate()
         *      OUTPUT:
         *          Access_SelectedIndex() {CHAR}
         *
         * 
         * Goals:
         *      Randomly select an index letter of the quadratic equation [A, B, C].
         */



        // Declarations and Initializations
        // ---------------------------------
            // Quadratic Equation Index Address
                private Text letterBox;
            // Selected Index
                private char indexChar;
            // Previous random number
                private int oldRand;
            // [NG] Store the index positions in the array; used for the randomizer and selecting
                private char[] indexPosArr = new char[3];
            // Accessors and Communication
                private GameController scriptGameController;
        // ----



        /// <summary>
        /// Signal Listener: Detected
        /// </summary>
        private void OnEnable()
        {
            // [NG] Retrieve the index positions and evaluate them accordingly
            ProblemBox.ReportIndexPosition += ReportedIndexPositions;
        } // OnEnable()



        /// <summary>
        /// Signal Listener: Deactivate
        /// </summary>
        private void OnDisable()
        {
            // [NG] Retrieve the index positions and evaluate them accordingly
            ProblemBox.ReportIndexPosition -= ReportedIndexPositions;
        } // OnDisable()



        /// <summary>
        /// [NG] Store the updated the index positions for later use.
        /// This will be useful for using a preferred randomization to select the rightmost indexs over the left most.
        /// </summary>
        /// <param name="indexHighlight">Which index we're selecting [A|B|C]</param>
        /// <param name="indexPosition">Where the index is located [L]eft or [R]ight</param>
        private void ReportedIndexPositions(char indexHighlight, char indexPosition)
        {
            switch (indexHighlight)
            {
                case 'A':
                    indexPosArr[0] = indexPosition;
                    break;
                case 'B':
                    indexPosArr[1] = indexPosition;
                    break;
                case 'C':
                    indexPosArr[2] = indexPosition;
                    break;
                default:
                    Debug.LogError("Incorrect indexHighlight was passed!  Please inspect this error!  Highlighter reported: " + indexHighlight);
                    break;
            } // switch
        } // ReportedIndexPositions()



        // Use this for initialization
        private void Awake()
        {
            // Reference initialization
                letterBox = GetComponent<Text>();
        } // Awake()



        // Select an index of the Quadratic Equation
        //  Example of Indexes: ( Ax^2 + Bx + C )
        private void Generate()
        {
            // Use the randomized var to choose which index to select
            switch (ComplexLevelRandomizer())
            {
                case 1:
                    letterBox.text = "A";
                    indexChar = 'A';
                    break;
                case 2:
                    letterBox.text = "B";
                    indexChar = 'B';
                    break;
                case 3:
                    letterBox.text = "C";
                    indexChar = 'C';
                    break;
                default:
                    letterBox.text = "ERR!"; // Display that there is an error in the box [NG]
                    indexChar = 'E';
                    Debug.LogError("!ERROR!: Failed to generate a legal letter for variable [ letterBox.text ]"); // Show that there was an error in the console [NG]
                    break;
            } // Switch
        } // Generate()



        /// <summary>
        ///     This function will avoid repetition with the previous old random generated sequence
        /// </summary>
        /// <param name="randMin">
        ///     Minimum integer value for random range
        /// </param>
        /// <param name="randMax_EXCLUSIVE">
        ///     Maximum [EXCLUSIVE] integer value for the random range
        /// </param>
        /// <returns>
        ///     Returns a new random value that shouldn't be the 
        /// </returns>
        private int MoreRandomWithRandomThatIsRandom(int randMin = 1, int randMax_EXCLUSIVE = 4)
        {
            int newRand;

            // Make sure that the previously generated random number does is not the same as the newly generated number
            do
            {
                newRand = Random.Range(randMin, randMax_EXCLUSIVE);

            } while (newRand == oldRand);

            // Store the new value to the previously generated sequence
                oldRand = newRand;

            return oldRand;
        } // MoreRandomWithRandomThatIsRandom()



        /// <summary>
        /// [NG] This will try to prefer randomizations in favor of the right most if possible
        /// If the equation is not dynamic, then the previous randomization algorithm is used instead.
        /// </summary>
        /// <returns>Returns the selected index; untranslated</returns>
        private int ComplexLevelRandomizer()
        {
            int equationState = ComplexCheckState();    // Retain the equation state

            if (equationState == 0 || equationState == 3)   // Equation is simplified; use older algorithm
                return MoreRandomWithRandomThatIsRandom();
            else if (equationState == 1)                    // Evaluates the lonely index
                return ComplexLevelRandomizer_OneIndex();
            else                                            // Two indexes are on the right side
                return ComplexLevelRandomizer_TwoIndexes();
        } // ComplexLevelRandomizer()



        /// <summary>
        /// This function will determine if the lonely index is selectable or if the older randomizer must be used
        /// </summary>
        /// <returns>
        /// Returns the selected index</returns>
        private int ComplexLevelRandomizer_OneIndex()
        {
            int lonelyIndex = 0;                        // Used for finding the index that is on the right

            for (int i = 0; i < indexPosArr.Length; i++)// Scan array and find the index that is on the right
                if (indexPosArr[i] == 'R')
                    lonelyIndex = i;                    // Found the index; store it for future evaluations

            if ((lonelyIndex + 1) == oldRand)                 // If we already used it, use the older randomizer
                return MoreRandomWithRandomThatIsRandom();// NOTE: This might not always work at first try due to the two use limit.
                                                          //    But this will work at the second time this is evaluated.
            else
            {
                oldRand = lonelyIndex + 1;              // Use that lonely index
                return oldRand;
            } // else
        } // ComplexLevelRandomizer_OneIndex()



        /// <summary>
        ///     Finds the index to select that are on the right side but also avoid duplication
        /// </summary>
        /// <returns>
        /// Returns the specific index that fits the criteria.
        /// </returns>
        private int ComplexLevelRandomizer_TwoIndexes()
        {
            for (int i = 0; i < indexPosArr.Length; i++)            // Scan the array
                if ((indexPosArr[i] == 'R') && (i + 1 != oldRand))  // If the array index contains 'R' and was not previously selected
                {
                    oldRand = (i + 1);                              // Use it
                    return oldRand;
                } // if

            return -1;      // To avoid compiling errors; if -1 is returned then something went horribly wrong.
        } // ComplexLevelRandomizer_TwoIndexes()



        /// <summary>
        /// [NG] This will evaluate if the indexes are dynamic or simplified
        /// </summary>
        /// <returns>
        /// 0 = All indexes are simplified (Ax^2 + Bx + C = 0  OR  0 = Ax^2 + Bx + C)
        /// 1 = Only one index is on the right
        /// 2 = Two indexes are on the right
        /// 3 = All indexes are on the right
        /// </returns>
        private int ComplexCheckState()
        {
            int numIndex = 0;                               // This will store how many indexes are on the right side

            for (int i = 0; i < indexPosArr.Length; i++)    // Evaluate what indexes are on the right side
                if (indexPosArr[i] == 'R')
                    numIndex++;

            return numIndex;                                // Return how many indexes were on the right side
        } // ComplexCheckState()



        // This function will call the generator function (which is private).
        public void Access_Generate()
        {
            Generate();
        } // Access_Generate()



        // This function will allow other scripts to determine what index is selected.
        public char Access_SelectedIndex
        {
            get {
                    return indexChar;
                } // get
        } // Access_SelectedIndex
    } // End of Class
} // Namespace