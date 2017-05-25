﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MinionMathMayhem_Ship
{
    public class FinalDestroyerShip2 : MonoBehaviour
    {

        /*                      FINAL DESTROYER
         * When the actor triggers the exit object, this class will simply cache the actor's identity number and kill the actor from the scene.
         *   The cached identity will be used from another script that is required for the game.
         * 
         * 
         * GOALS:
         *  Fetch the actor's uniquely self-assigned number and cache it.
         *  Cached ID will be accessible for other outside scripts within the same namespace.
         *  Destroy the actor
         */


        // Declarations and Initializations
        // ---------------------------------
            // Cached integer from the actor
                private int cacheNumber;
            // Game Event Broadcast \ Delegate Event
                public delegate void ToggleGameEventSignal();
                public static event ToggleGameEventSignal GameEventSignal;
        // ----

		private string sceneName;

		public void Awake(){
			Scene currentScene = SceneManager.GetActiveScene ();
			sceneName = currentScene.name;
		}

        // During the collision, handle the proper protocol for handling the actor
        private void OnTriggerEnter(Collider actor)
        {
			//	cacheNumber = RetrieveActorIdentity(actor);
				Destroy (actor.gameObject);
        }
			
        // This function is designed to fetch the uniquely self-assigned number from the actor.
        private int RetrieveActorIdentity(Collider actorObject)
        {
            // Fetch the minion's unique script.
                Minion_Identity tempData = actorObject.gameObject.GetComponent<Minion_Identity>();
            // Fetch and return the minion's uniquely assigned number.
                return (tempData.MinionNumber);
        } // RetrieveActorIdentity()



        // This accessor will allow outside script's to retrieve the actor's number.
        public int ActorIdentity
        {
            get {
                    return cacheNumber;
                } // get
        } // ActorIdentity
    } // End of Class
} // Namespace