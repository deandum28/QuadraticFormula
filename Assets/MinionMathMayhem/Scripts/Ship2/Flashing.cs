using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// this toggles a component (usually an Image or Renderer) on and off for an interval to simulate a blinking effect
public class Flashing : MonoBehaviour {

	// this is the UI.Text or other UI element you want to toggle
	public MaskableGraphic imageToToggle;
	public MaskableGraphic imageToToggle2;
	public MaskableGraphic imageToToggle3;
	public MaskableGraphic imageToToggle4;
	public MaskableGraphic imageToToggle5;
	public MaskableGraphic imageToToggle6;

	public MaskableGraphic imageToToggle7;
	public MaskableGraphic imageToToggle8;
	public MaskableGraphic imageToToggle9;
	public MaskableGraphic imageToToggle10;
	public MaskableGraphic imageToToggle11;
	public MaskableGraphic imageToToggle12;

	public float interval = 1f;
	public float startDelay = 0.5f;
	public bool currentState = true;
	public bool defaultState = true;
	bool isBlinking = false;

	public AudioClip clip;

	void Start()
	{
		imageToToggle.enabled = defaultState;
		imageToToggle2.enabled = defaultState;
		imageToToggle3.enabled = defaultState;
		imageToToggle4.enabled = defaultState;
		imageToToggle5.enabled = defaultState;
		imageToToggle6.enabled = defaultState;
		imageToToggle7.enabled = defaultState;
		imageToToggle8.enabled = defaultState;
		imageToToggle9.enabled = defaultState;
		imageToToggle10.enabled = defaultState;
		imageToToggle10.enabled = defaultState;
		imageToToggle11.enabled = defaultState;
		imageToToggle12.enabled = defaultState;

		StartBlink();
	}

	public void StartBlink()
	{
		if (isBlinking)
			return;

		if (imageToToggle !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle2 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle3 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle4 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle5 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle6 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle7 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle8 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle9 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle10 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle11 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
		else if (imageToToggle12 !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
	}

	public void ToggleState()
	{
		imageToToggle.enabled = !imageToToggle.enabled;
		imageToToggle2.enabled = !imageToToggle2.enabled;
		imageToToggle3.enabled = !imageToToggle3.enabled;
		imageToToggle4.enabled = !imageToToggle4.enabled;
		imageToToggle5.enabled = !imageToToggle5.enabled;
		imageToToggle6.enabled = !imageToToggle6.enabled;

		imageToToggle7.enabled = !imageToToggle.enabled;
		imageToToggle8.enabled = !imageToToggle2.enabled;
		imageToToggle9.enabled = !imageToToggle3.enabled;
		imageToToggle10.enabled = !imageToToggle4.enabled;
		imageToToggle11.enabled = !imageToToggle5.enabled;
		imageToToggle12.enabled = !imageToToggle6.enabled;

		// plays the clip at (0,0,0)
		if (clip)
			AudioSource.PlayClipAtPoint(clip,Vector3.zero);
	}

}