using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MinionMathMayhem_Ship
{
	public class DestroyMinion2 : MonoBehaviour
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
				Debug.Log ("The number is:" + cacheNumber);
				if (cacheNumber == 12) {
					StartCoroutine (Activation ());
				} else if (cacheNumber != 12) {
					Score.ScoreUpdate_Incorrect += "1";
				}
				Destroy (actor.gameObject);
				GameEventSignal ();
			}
		}


		IEnumerator Activation()
		{
			Score.ScoreUpdate_Correct += 1;
			yield return new WaitForSeconds(5);
			Minion2.SetActive (true); 
			Exit2.SetActive (true);
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