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
				{
					_chip.transform.SetParent(transform, true);
					_chip.transform.localPosition = Vector3.zero;
				}
			}
		}
	}

	#endregion

	#region Methods

	#endregion
}
