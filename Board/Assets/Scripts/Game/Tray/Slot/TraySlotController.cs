using UnityEngine;
using System.Collections;

public class TraySlotController : MonoBehaviour 
{
	#region Variables

	private ChipController _chip = null;

	#endregion

	#region Variables

	public ChipController Chip
	{
		get { return _chip; }
		set 
		{ 
			if(_chip != value)
			{
				_chip = value; 

				if(_chip != null)
					_chip.transform.parent = transform;
			}
		}
	}

	#endregion

	#region Methods

	#endregion
}
