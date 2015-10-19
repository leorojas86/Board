using UnityEngine;
using System.Collections;

public class ChipIdleState : ChipState 
{
	#region Constructor

	public ChipIdleState(ChipController chipController):base(chipController)
	{
	}

	#endregion

	#region Methods



	#endregion

	#region Transitions

	public bool GotoDraggingState()
	{
		return false;
	}

	#endregion
}
