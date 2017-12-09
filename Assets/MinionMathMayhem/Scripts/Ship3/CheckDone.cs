using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDone : MonoBehaviour {


	private Animator thatsItAnim;

	public GameObject thatsIt;

	private Text value, valueMtop, valueMbottom, valueMleft;
	public Text oopsie;
	public Text score;
	public Text quadHolder;

	public bool BoolAnswer = false;

	public Splash MoveSplash;

	private int countOopsie = 0;
	private int countScore = 0;
	private string answer = "4";



	public GameObject Mtop, Mleft, Mbottom; 

	public ParticleSystem newQuad;

	void Awake () {
		thatsItAnim = thatsIt.GetComponent<Animator>();

		value = GetComponentInChildren<Text> ();
		valueMbottom = Mbottom.GetComponentInChildren<Text> ();
		valueMleft = Mleft.GetComponentInChildren<Text> ();
		valueMtop = Mtop.GetComponentInChildren<Text> ();

		oopsie.text = countOopsie.ToString ();
	}


	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Space pressed");
			string UserScore = value.text.ToString ();
			if (UserScore == answer) {
				BoolAnswer = true;
				thatsItAnim.SetTrigger ("Drop");
				StartCoroutine (Next ());
				countScore += 10;
				score.text = countScore.ToString ();

			} else {
				Debug.Log ("Wrong Answer!");
				BoolAnswer = false;
				MoveSplash.MoveSplash ();
				countOopsie++;
				oopsie.text = countOopsie.ToString();

			}

		}
	}
		
	IEnumerator Next()
	{
		newQuad.Play ();
		yield return new WaitForSeconds (1f);
	//	Time.timeScale = 0;
		randomQuadGeneration();
	}
		

	public void NextQuad(){
		if (value.text.ToString () == "X^2+5X+4=0") {
			answer = "4";
		}
	}

	public void randomQuadGeneration(){
		int i = Random.Range (0, 8);


		if (i == 0) {
			quadHolder.text = "X^2+3X+2=0";

			value.text = "0";
			valueMbottom.text = "2";
			valueMleft.text = "1";
			valueMtop.text = "3";

			answer = "2";
		} else if (i == 1) {
			quadHolder.text = "X^2+5X+6=0";

			value.text = "0";
			valueMbottom.text = "6";
			valueMleft.text = "2";
			valueMtop.text = "5";

			answer = "3";
		}else if (i == 2) {
			quadHolder.text = "X^2+2X+1=0";

			value.text = "0";
			valueMbottom.text = "1";
			valueMleft.text = "1";
			valueMtop.text = "2";

			answer = "1";
		}
		else if (i == 3) {
			quadHolder.text = "X^2-1=0";

			value.text = "0";
			valueMbottom.text = "-1";
			valueMleft.text = "1";
			valueMtop.text = "0";

			answer = "-1";
		}
		else if (i == 4) {
			quadHolder.text = "X^2+7X+10=0";

			value.text = "0";
			valueMbottom.text = "10";
			valueMleft.text = "5";
			valueMtop.text = "7";

			answer = "2";
		}
		else if (i == 5) {
			quadHolder.text = "X^2-4X+4=0";

			value.text = "0";
			valueMbottom.text = "4";
			valueMleft.text = "-2";
			valueMtop.text = "-4";

			answer = "-2";
		}
		else if (i == 6) {
			quadHolder.text = "X^2-2X-3=0";

			value.text = "0";
			valueMbottom.text = "-3";
			valueMleft.text = "-3";
			valueMtop.text = "-2";

			answer = "1";
		}
		else if (i == 7) {
			quadHolder.text = "X^2+7X+12=0";

			value.text = "0";
			valueMbottom.text = "12";
			valueMleft.text = "4";
			valueMtop.text = "7";

			answer = "3";
		}
	}
}
