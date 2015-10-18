using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour 
{
	#region Variables

	private int _frames       = 0;
	private float _lastSecond = 0; 

	private Text _text = null;

	#endregion

	#region Methods

	void Start() 
	{
		_text = GetComponent<Text>();

		if(!Debug.isDebugBuild)
			gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Time.time > _lastSecond + 1)
		{
			_text.text  = "FPS: " + _frames;
			_frames 	= 0;
			_lastSecond = Time.time;
		}
		else
			_frames++;
	}

	#endregion
}
