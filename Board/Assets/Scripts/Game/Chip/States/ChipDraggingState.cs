using UnityEngine;
using System.Collections;

public class ChipDraggingState : ChipState 
{
	#region Constructors

	public ChipDraggingState(ChipController chipController):base(chipController)
	{
	}

	#endregion

	#region Methods

	public override void OnEnter()
	{
		base.OnEnter();


	}

	public override void OnExecute()
	{
		base.OnExecute();

		_chipController.transform.position = Input.mousePosition;

		_isCompleted = Input.GetMouseButtonUp(0);
	}

	#endregion
}
