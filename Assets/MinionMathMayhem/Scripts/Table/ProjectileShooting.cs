using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MinionMathMayhem_Ship4 {
    public class ProjectileShooting : MonoBehaviour {

        public Transform Target;
        public float firingAngle = 45.0f;
        public float gravity = 9.8f;

        public Transform Projectile;
        private Transform myTransform;

        public TargetController targetController;

        private int projectilesShot = 0;

        private bool activeShooting = true;

        void Awake() {
            myTransform = transform;
        }

        private void Start() {
            activeShooting = true;
            
        }

        void Update() {
            if (projectilesShot >= 2)
                projectilesShot = 0;
            if (Input.GetKeyDown(KeyCode.Space) && activeShooting == true) {
                deactivateShooting();
                targetController.deactivateTargeting();
                StartCoroutine(SimulateProjectile());
            }
        }


        IEnumerator SimulateProjectile() {
            GameObject projectile =  Instantiate(Resources.Load("Sphere"), gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            // Short delay added before Projectile is thrown
            yield return new WaitForSeconds(1.5f);

            // Move projectile to the position of throwing object + add some offset if needed.
            projectile.transform.position = myTransform.position + new Vector3(0, 0.0f, 0);

            // Calculate distance to target
            float target_Distance = Vector3.Distance(projectile.transform.position, Target.position);

            // Calculate the velocity needed to throw the object to the target at specified angle.
            float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

            // Extract the X  Y componenent of the velocity
            float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
            float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

            // Calculate flight time.
            float flightDuration = target_Distance / Vx;

            // Rotate projectile to face the target.
            projectile.transform.rotation = Quaternion.LookRotation(Target.position - projectile.transform.position);

            float elapse_time = 0;

            while (elapse_time < flightDuration) {
                projectile.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
                elapse_time += Time.deltaTime;
                yield return null;
            }
        }

        public int getShotsCount() {
            return projectilesShot;
        }

        public void increaseShotsCount() {
            projectilesShot++;
        }

        public void activateShooting() {
            activeShooting = true;
        }

        public void deactivateShooting() {
            activeShooting = false;
        }
    }
}