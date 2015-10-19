using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour 
{
	#region Variables

	public Button playButton = null;

	#endregion

	#region Methods

	void Awake()
	{
		playButton.onClick.AddListener(OnPlayButtonClick);
	}

	private void OnPlayButtonClick()
	{
		Debug.Log("OnPlayButtonClick");
	}

	#endregion
}
