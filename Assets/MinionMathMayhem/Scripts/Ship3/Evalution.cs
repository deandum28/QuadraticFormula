using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evalution : MonoBehaviour {

	public Transform[] targetTop;
	public Transform[] targetBottom;
	public Transform[] targetRight;
	public Transform[] targetLeft;


	public float speed;

	private int current;

	public GameObject[] Minions;

	private bool answer = false;



	void Update() {


		
		if(Input.GetKeyDown(KeyCode.Space))
			{

				Debug.Log ("Space was pressed again");
					MoveGameObject ();
				
			}
	}


	public void MoveGameObject()
	{
		if (Minions[1].transform.position != targetTop [current].position) {
			
			Vector3 pos = Vector3.MoveTowards (Minions[1].transform.position, targetTop [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody> ().MovePosition (pos);
		} else {
			current = (current + 1) % targetTop.Length;
		}

		if (Minions[3].transform.position != targetBottom [current].position) {

			Vector3 pos = Vector3.MoveTowards (Minions[3].transform.position, targetBottom [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody> ().MovePosition (pos);
		} else {
			current = (current + 1) % targetBottom.Length;
		}

		if (Minions[0].transform.position != targetRight [current].position) {

			Vector3 pos = Vector3.MoveTowards (Minions[0].transform.position, targetRight [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody> ().MovePosition (pos);
		} else {
			current = (current + 1) % targetRight.Length;
		}

		if (Minions[2].transform.position != targetLeft [current].position) {

			Vector3 pos = Vector3.MoveTowards (Minions[2].transform.position, targetLeft[current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody> ().MovePosition (pos);
		} else {
			current = (current + 1) % targetLeft.Length;
		}
	}

}
