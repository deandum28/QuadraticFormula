using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectTarget : MonoBehaviour {

    public TouchDown[] targets;
    private TouchDown correctTarget;
    private int randomTarget;
    private Text target;

	void Start () {
        target = GetComponent<Text>();
        randomTarget = Random.Range(1, 4);
        target.text = randomTarget.ToString();
        correctTarget = targets[randomTarget - 1];
        correctTarget.setTarget(true);
    }
	
	
	void Update () {
        if (correctTarget.getHit() == true){
            correctTarget.setTarget(false);
            randomTarget = Random.Range(1, 4);
            target.text = randomTarget.ToString();
            correctTarget = targets[randomTarget - 1];
            correctTarget.setTarget(true);
        }

    }
}
