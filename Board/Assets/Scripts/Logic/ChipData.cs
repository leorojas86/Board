using UnityEngine;
using System.Collections;

public class ChipData
{
    #region Variables

	private char _letter = char.MinValue;

    #endregion

	#region Properties

	public char Letter
	{
		get { return _letter; }
		set { _letter = value; }
	}

	#endregion

	#region Constructors

	public ChipData(char letter)
	{
		_letter = letter;
	}

	#endregion
}
