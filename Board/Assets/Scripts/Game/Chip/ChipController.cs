using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChipController : MonoBehaviour 
{
	#region Variables

	private Text _text 		   = null;
	private ChipData _chipData = null;

	#endregion

	#region Properties

	public ChipData ChipData
	{
		get { return _chipData; }
		set 
		{
			if(_chipData != value)
			{
				_chipData  = value;
				_text.text = _chipData != null ? _chipData.Letter.ToString().ToUpper() : string.Empty;
			}
		}
	}

	#endregion

	#region Methods

	void Awake()
	{
		_text = GetComponent<Text>();
	}

	#endregion
}
