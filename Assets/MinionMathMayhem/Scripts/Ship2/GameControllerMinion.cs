using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinionMathMayhem_Ship
{
	public class GameControllerMinion : MonoBehaviour {

		private int number;
		public Text numText;

		private void Awake()
		{
			numText = GetComponentInChildren<Text>();
		}
			
		private void Start()
		{
			//number = Minion_RandomSetNumbers.Access_GetNumber();
			number = Random.Range(0,13);
			numText.text = number.ToString();
		}
		public int MinionNumber
		{
			get {
				return number;
			} // get
		}
			
		/*
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Exit") 
			{
				Debug.Log (number);
				Destroy (this.gameObject);
				if (number == 12) {
					Minion2.SetActive (true); 
					Exit2.SetActive (true);
				}
			}
			else if (other.gameObject.tag == "Exit2") 
			{
				Debug.Log (number);
				Destroy (this.gameObject);
				if (number == 6) {
					Minion3.SetActive (true); 
					Exit3.SetActive (true);
				}
			}
			if (other.gameObject.tag == "Exit3") 
			{
				Debug.Log (number);
				Destroy (this.gameObject);
				if (number == 4) {
					Debug.Log ("You won");
				}
			}
		}*/
	}
}
