using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MinionMathMayhem_Ship
{
	public class DestroyMinion23 : MonoBehaviour
	{
		private int cacheNumber;
		public delegate void ToggleGameEventSignal();
		public static event ToggleGameEventSignal GameEventSignal;


		public GameObject Minion2, Minion3, SpawnNewMinon;
		public GameObject DeleteQuestion;
		public GameObject Exit2, Exit3;
		public Text score;

		private void OnTriggerEnter(Collider actor)
		{
			if (actor.gameObject.tag == "Minion") {
				cacheNumber = RetrieveActorIdentity (actor);
				// Send a signal to GameEvent to execute
				Debug.Log ("The number is:" + cacheNumber);
				if (cacheNumber == 4) {
					StartCoroutine (Activation ());
					Debug.Log ("You Won");
					thatsItAnim.SetTrigger ("Drop");
					StartCoroutine (Waiting ());
				} else if (cacheNumber != 4) {
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
			DeleteQuestion.SetActive (false);
			yield return new WaitForSeconds(2);
			SpawnNewMinon.transform.GetChild (0).gameObject.SetActive (true);
			SpawnNewMinon.transform.GetChild (1).gameObject.SetActive (false);
			yield return new WaitForSeconds(1f);

		}


		private Animator thatsItAnim;
		public GameObject thatsIt;
		// Use this for initialization
		void Awake () {
			thatsItAnim = thatsIt.GetComponent<Animator>();
		}

		IEnumerator Waiting()
		{
			yield return new WaitForSeconds (7f);
			Time.timeScale = 0;
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