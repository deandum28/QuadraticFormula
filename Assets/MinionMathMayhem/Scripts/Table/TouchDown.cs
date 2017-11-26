using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDown : MonoBehaviour {

    public bool isTargeted;
    public bool wasHit;

	// Use this for initialization
	void Start () {
        isTargeted = false;
        wasHit = false;
	}
	

    void OnCollisionEnter (Collision projectile) {
        if (projectile.gameObject.tag == "projectile") {
            Debug.Log ("Collision detectd");
            if (isTargeted == true){
                Debug.Log("Collision is correct");
                wasHit = true;
            }
            else Debug.Log("Collision is not correct");
        }
    }

    public bool getTarget()
    {
        return isTargeted;
    }

    public void setTarget(bool t)
    {
        isTargeted = t;
    }

    public bool getHit()
    {
        return wasHit;
    }

    public void setHit(bool t)
    {
        wasHit = t;
    }
}
