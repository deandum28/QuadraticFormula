using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MinionMathMayhem_Ship
{
	public class DestroyMinion23 : MonoBehaviour
	{
		private int cacheNumber;
		public delegate void ToggleGameEventSignal();
		public static event ToggleGameEventSignal GameEventSignal;


		public GameObject Minion2, Minion3;
		public GameObject Exit2, Exit3;

		private void OnTriggerEnter(Collider actor)
		{
			if (actor.gameObject.tag == "Minion") {
				cacheNumber = RetrieveActorIdentity (actor);
				// Send a signal to GameEvent to execute
				Debug.Log ("The number is:" + cacheNumber);
				if (cacheNumber == 4) {
					Score.ScoreUpdate_Correct += 1;
					Debug.Log ("You Won");
				} else if (cacheNumber != 4) {
					Score.ScoreUpdate_Incorrect += 1;
				}
				Destroy (actor.gameObject);
				GameEventSignal ();
			}
		}
			
		private int RetrieveActorIdentity(Collider actorObject)
		{
			GameControllerMinion tempData = actorObject.gameObject.GetComponent<GameControllerMinion>();
			return (tempData.MinionNumber);

		}
		public int ActorIdentity
		{
			get {
				return cacheNumber;
			} 
		}
	}
}