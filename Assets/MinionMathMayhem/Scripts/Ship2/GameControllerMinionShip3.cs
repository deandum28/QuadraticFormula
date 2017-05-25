using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinionMathMayhem_Ship
{
	public class GameControllerMinionShip3 : MonoBehaviour {

		private int number;
		public Text numText;

		public Material redMinion;
		public Material greenMinion;
		private Renderer rendMinion;
		private GameObject respawns;
		private float MinionValue;

		private void Awake()
		{
		//	
			rendMinion = transform.GetChild(4).GetComponent<Renderer>();
		
//rendMinion.material = redMinion;
		}

		private void Start()
		{
			numText = GameObject.FindGameObjectWithTag ("MinionAnswer").GetComponentInChildren<Text> ();

			//numText.text = "0";
			//number = Minion_RandomSetNumbers.Access_GetNumber();
			number = Random.Range(0,2);
			MinionValue = 0;


		//	numText.text = number.ToString();

			Debug.Log (number);
			if (number == 0) {
				rendMinion.material = greenMinion;
				MinionValue = 1;
				Debug.Log ("0");
			} else if (number == 1) {
				rendMinion.material = redMinion;
				MinionValue = -1;
				Debug.Log (number);
			}
			//numText.text = number.ToString();
		}


		public int MinionNumber
		{
			get {
				return number;
			} // get
		}
		bool ColorMin = true;
		void Update()
		{
			if (Input.GetMouseButtonDown (1)) {
				if (ColorMin == true) {
					rendMinion.material = redMinion;
					MinionValue = -1;
					ColorMin = false;
				} else if (ColorMin == false) {
					rendMinion.material = greenMinion;
					MinionValue = 1;
					ColorMin = true;
				}
			}


		}


		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Exit") 
			{
				if (MinionValue == 1) {
				//	-

					string UserScore = numText.text.ToString ();
					int newS = int.Parse (UserScore);
					newS += 1;
					numText.text = newS.ToString ();
				} else if (MinionValue == -1) {
				// +
					string UserScore = numText.text.ToString ();
					int newS = int.Parse (UserScore);
					newS -= 1;
					numText.text = newS.ToString ();
				}
			}
		}
	}
}
