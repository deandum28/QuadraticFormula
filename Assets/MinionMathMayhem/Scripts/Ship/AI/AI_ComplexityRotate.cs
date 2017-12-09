using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_ComplexityRotate : MonoBehaviour {


	public Text value;
	public GameObject ship;

	private Animator ani;

	private string holder;


	void Awake(){
		ani = GetComponent<Animator> ();
	}

	void Start(){
		holder = value.text;
	}

	void Update() {
		if (holder != value.text) {
			if (value.text.EndsWith ("0")) { return;
			} else {
				StartCoroutine (Rotation ());
				holder = value.text;
			}
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine (Rotation ());
		}
		
	}

	IEnumerator Rotation(){
		yield return new WaitForSeconds (4f);
		ani.enabled = false;
	
		iTween.RotateBy (ship, iTween.Hash ("z", 0.05, "easeType", "easeInOutExpo", "delay", .1));
		iTween.RotateBy (ship, iTween.Hash ("z", -0.05, "easeType", "easeInOutExpo", "delay", 1.5));

		yield return new WaitForSeconds (2.5f);

		ani.enabled = true;
	}
		
}
