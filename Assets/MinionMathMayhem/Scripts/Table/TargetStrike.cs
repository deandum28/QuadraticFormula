using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinionMathMayhem_Ship4 {
    public class TargetStrike : MonoBehaviour {

        public GameEngine gameEngine;
        public ProjectileShooting projectileController;
        public TargetController targetController;


        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag == "Projectile") {
                projectileController.deactivateShooting();
                targetController.deactivateTargeting();
                StartCoroutine(TouchDown(other));
           } 
                
        }
        //TODO: Change the collision. The projectile should identify if it hit the minion not the other way. With this, it will be able to determine if it was a miss hit.
        IEnumerator TouchDown(Collider other) {
            projectileController.increaseShotsCount();
            if (gameObject.tag == "TopLeft")
            { gameEngine.updateTargetArray(0); Debug.Log("Minion Hit: " + gameObject.tag); }

            if (gameObject.tag == "BottomRight")
            { gameEngine.updateTargetArray(1); Debug.Log("Minion Hit: " + gameObject.tag); }

            if (gameObject.tag == "TopRight")
            { gameEngine.updateTargetArray(2); Debug.Log("Minion Hit: " + gameObject.tag); }

            if (gameObject.tag == "BottomLeft")
            { gameEngine.updateTargetArray(3); Debug.Log("Minion Hit: " + gameObject.tag); }

            yield return new WaitForSeconds(1f);
            Destroy(other.gameObject);
            yield return new WaitForSeconds(1f);
            projectileController.activateShooting();
            targetController.activateTargeting();
        }
    }
}