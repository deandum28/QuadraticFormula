using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	

	public GameObject[] Minions;

	void Update(){

		if (Input.GetKeyDown (KeyCode.Space)) {
			
			iTween.MoveBy (Minions[0], iTween.Hash ("x", 15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[0], iTween.Hash ("x",10,"y", -20, "easeType", "easeInOutExpo", "delay", .8));

			iTween.MoveBy (Minions[1], iTween.Hash ("z", 15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[1], iTween.Hash ("z",10,"y", -20, "easeType", "easeInOutExpo", "delay", .8));

			iTween.MoveBy (Minions[2], iTween.Hash ("x", -15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[2], iTween.Hash ("x",-10,"y", -20, "easeType", "easeInOutExpo", "delay", .8));

			iTween.MoveBy (Minions[3], iTween.Hash ("z", -15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[3], iTween.Hash ("z",-10,"y", -30, "easeType", "easeInOutExpo", "delay", .8));

		}


	}

}

