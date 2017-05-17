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
		} // MinionNumber
	}
}
