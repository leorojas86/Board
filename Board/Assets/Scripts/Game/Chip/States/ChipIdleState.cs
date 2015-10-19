using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ChipIdleState : ChipState 
{
	#region Variables

	//private bool _goToDraggingState = false;

	#endregion

	#region Constructor

	public ChipIdleState(ChipController chipController):base(chipController)
	{
		//chipController.EventTrigger.
	}

	#endregion

	#region Methods

	/*private void OnBeginDrag(PointerEventData data)
	{
		Debug.Log("OnBeginDrag");
		_goToDraggingState = true;
	}*/

	#endregion

	#region Transitions

	public bool GotoDraggingState()
	{
		float distance2D = Vector2.Distance(Input.mousePosition, _chipController.transform.position);

		return ScrabbleGame.Instance.DraggingChip == null && Input.GetMouseButtonDown(0) && distance2D < ScrabbleConstants.CHIP_DRAG_DISTANCE;
	}

	#endregion
}
