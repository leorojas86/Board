using UnityEngine;
using System.Collections;

public class ChipController : MonoBehaviour 
{
	#region Variables

	private ChipData _chipData = null;

	#endregion

	#region Properties

	public ChipData ChipData
	{
		get { return _chipData; }
		set { _chipData = value; }
	}

	#endregion
}
