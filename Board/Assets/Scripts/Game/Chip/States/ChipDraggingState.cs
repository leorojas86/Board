using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

		ScrabbleGame.Instance.DraggingChip = _chipController;

		_chipController.transform.SetParent(ScrabbleGame.Instance.canvas.transform, true);
	}

	public override void OnExecute()
	{
		base.OnExecute();

		_chipController.transform.position = Input.mousePosition;
		_isCompleted 					   = Input.GetMouseButtonUp(0);
	}

	public override void OnExit()
	{
		ScrabbleGame.Instance.DraggingChip = null;
		SnapToBoard();
		//if(_chipController.OnDragFinished != null)
		  // _chipController.OnDragFinished(_chipController);

		base.OnExit();
	}

	private void SnapToBoard()
	{
		List<BoardSlotController> slots = ScrabbleGame.Instance.board.Slots;
		BoardSlotController closestSlot = null;
		float closestDistance 			= float.MaxValue;

		for(int x = 1; x < slots.Count; x++)
		{
			BoardSlotController currentSlot = slots[x];
			float currentSlotDistance       = Vector2.Distance(currentSlot.transform.position, _chipController.transform.position);

			if(currentSlot.Chip == null && currentSlotDistance < closestDistance)
			{
				closestSlot     = currentSlot;
				closestDistance = currentSlotDistance;
			}
		}

		if(closestSlot != null)
			closestSlot.Chip = _chipController;
	}

	#endregion
}
