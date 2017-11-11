using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDone : MonoBehaviour {


	private Animator thatsItAnim;
	public GameObject thatsIt;
	private Text value;
	public bool BoolAnswer = false;
	// Use this for initialization
	void Awake () {
		thatsItAnim = thatsIt.GetComponent<Animator>();
		value = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
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
			//	MoveSample.MoveMinion ();
			}

		}
	}
		
	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (1f);
		Time.timeScale = 0;
	}


}
