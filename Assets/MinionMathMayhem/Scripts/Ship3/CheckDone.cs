using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDone : MonoBehaviour {


	private Animator thatsItAnim;

	public GameObject thatsIt;

	private Text value;
	public Text oopsie;

	public bool BoolAnswer = false;


	public Splash MoveSplash;
	private int countOopsie = 0;




	void Awake () {
		thatsItAnim = thatsIt.GetComponent<Animator>();
		value = GetComponentInChildren<Text> ();
		oopsie.text = countOopsie.ToString ();
	}


	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Space pressed");
			string UserScore = value.text.ToString ();
			if (UserScore == "4") {
				BoolAnswer = true;
				thatsItAnim.SetTrigger ("Drop");
				StartCoroutine (Waiting ());

			} else {
				Debug.Log ("Wrong Answer!");
				BoolAnswer = false;
				MoveSplash.MoveSplash ();
				countOopsie++;
				oopsie.text = countOopsie.ToString();

			}

		}
	}
		
	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (1f);
		Time.timeScale = 0;
	}


}
