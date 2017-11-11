using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {


	public GameObject Help1;
	public GameObject Help2;
	// Use this for initialization


	private bool BoolH1 = false;
	private bool BoolH2 = false;



	public void ActivateHelp1()
	{
		if (BoolH1 == true) {
			Help1.SetActive (false);
			BoolH1 = false;
		} else if (BoolH1 == false) {
			Help1.SetActive (true);
			BoolH1 = true;
		}
	}

	public void ActivateHelp2()
	{
		if (BoolH2 == true) {
			Help2.SetActive (false);
			BoolH2 = false;
		} else if (BoolH2 == false) {
			Help2.SetActive (true);
			BoolH2 = true;
		}
	}

}


