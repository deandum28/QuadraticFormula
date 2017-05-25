using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	private Renderer rendMinion;
	public Material OrangeMinion;

	void Start () {
		rendMinion = transform.GetChild(4).GetComponent<Renderer>();
		rendMinion.material = OrangeMinion;
	}
	

}
