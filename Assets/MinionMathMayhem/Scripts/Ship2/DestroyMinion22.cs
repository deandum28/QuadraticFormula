using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


namespace MinionMathMayhem_Ship
{
	public class DestroyMinion22 : MonoBehaviour
	{
		private int cacheNumber;
		public delegate void ToggleGameEventSignal();
		public static event ToggleGameEventSignal GameEventSignal;


		public GameObject Minion2, Minion3, SpawnNewMinon;
		public GameObject Exit2, Exit3;
		public Text score;


		private void OnTriggerEnter(Collider actor)
		{
			if (actor.gameObject.tag == "Minion") {
				cacheNumber = RetrieveActorIdentity (actor);
				// Send a signal to GameEvent to execute
				Debug.Log ("The number is:" + cacheNumber);
				if (cacheNumber == 6) {
					StartCoroutine (Activation ());
				} else if (cacheNumber != 6) {
					IncorrectScore ();
				}
				Destroy (actor.gameObject);
				GameEventSignal ();
			}
		}


		IEnumerator Activation()
		{
			CorrectScore ();
			SpawnNewMinon.transform.GetChild (1).gameObject.SetActive (true);
			yield return new WaitForSeconds(2);
			SpawnNewMinon.transform.GetChild (0).gameObject.SetActive (true);
			SpawnNewMinon.transform.GetChild (1).gameObject.SetActive (false);
			yield return new WaitForSeconds(1f);
			Minion3.SetActive (true); 
			Exit3.SetActive (true);
		}

		private void CorrectScore(){
			string UserScore = score.text.ToString ();
			int newS = int.Parse (UserScore);
			newS += 5;
			score.text = newS.ToString ();
		}

		private void IncorrectScore(){
			string UserScore = score.text.ToString ();
			int newS = int.Parse (UserScore);
			newS -= 1;
			score.text = newS.ToString() ;
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