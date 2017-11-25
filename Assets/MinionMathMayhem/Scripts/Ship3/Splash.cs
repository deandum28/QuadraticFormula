using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {


	public GameObject[] Minions;

	public ParticleSystem[] splashing;

	public AudioSource gameControllerAudio;
	public AudioClip splash;



	IEnumerator Waiting(){
		
		yield return new WaitForSeconds (1.3f);

		for(int i=0; i<=3; i++)
		{
			splashing [i].Play ();
		}
		GetComponent<AudioSource>().clip = splash;
		GetComponent<AudioSource>().Play ();

		yield return new WaitForSeconds (1f);

		MoveSplashBack ();

	}

	public void MoveSplash(){

		if (Input.GetKeyDown (KeyCode.Space)) {

			iTween.MoveBy (Minions[0], iTween.Hash ("x", 15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[0], iTween.Hash ("x",10,"y", -20, "easeType", "easeInOutExpo", "delay", .8));


			iTween.MoveBy (Minions[1], iTween.Hash ("z", 15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[1], iTween.Hash ("z",10,"y", -20, "easeType", "easeInOutExpo", "delay", .8));


			iTween.MoveBy (Minions[2], iTween.Hash ("x", -15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[2], iTween.Hash ("x",-10,"y", -20, "easeType", "easeInOutExpo", "delay", .8));

			iTween.MoveBy (Minions[3], iTween.Hash ("z", -15, "y", 5, "easeType", "easeInOutExpo", "delay", .1));
			iTween.MoveBy (Minions[3], iTween.Hash ("z",-6,"y", -27, "easeType", "easeInOutExpo", "delay", .8));


			StartCoroutine (Waiting());

		}


	}


	public void MoveSplashBack(){
		iTween.MoveBy (Minions[0], iTween.Hash ("x", -15, "y", -5, "easeType", "easeInOutExpo", "delay", .1));
		iTween.MoveBy (Minions[0], iTween.Hash ("x",-10,"y", 20, "easeType", "easeInOutExpo", "delay", .8));


		iTween.MoveBy (Minions[1], iTween.Hash ("z", -15, "y", -5, "easeType", "easeInOutExpo", "delay", .1));
		iTween.MoveBy (Minions[1], iTween.Hash ("z",-10,"y", 20, "easeType", "easeInOutExpo", "delay", .8));


		iTween.MoveBy (Minions[2], iTween.Hash ("x", 15, "y", -5, "easeType", "easeInOutExpo", "delay", .1));
		iTween.MoveBy (Minions[2], iTween.Hash ("x",10,"y", 20, "easeType", "easeInOutExpo", "delay", .8));

		iTween.MoveBy (Minions[3], iTween.Hash ("z", 15, "y", -5, "easeType", "easeInOutExpo", "delay", .1));
		iTween.MoveBy (Minions[3], iTween.Hash ("z",6,"y", 27, "easeType", "easeInOutExpo", "delay", .8));
	}
}
