﻿using UnityEngine;
using System.Collections;

public class BoardLoadBoardState : BoardState 
{
	#region Variables

	#endregion

	#region Constructors

	public BoardLoadBoardState(BoardController boardController):base(boardController)
	{
	}

	#endregion

	#region Methods

	public override void OnEnter()
	{
		base.OnEnter();

		LoadBoardSlots();
	}

	private void LoadBoardSlots()
	{
		BoardData boardData 	  = ScrabbleLogicManager.Instance.Board;
		SlotController slotPrefab = _boardController.slotPrefab;
		Vector3 initialPosition   = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Vector3 currentPosition   = initialPosition;

		for(int x = 0; x < boardData.Size; x++)
		{
			for(int y = 0; y < boardData.Size; y++)
			{
				SlotController newInstance   	= GameObject.Instantiate(slotPrefab);
				newInstance.transform.SetParent(_boardController.transform, true);
				newInstance.transform.position  = currentPosition;

				currentPosition.y += ScrabbleConstants.BOARD_SLOT_DISTANCE;
			}

			currentPosition.y = initialPosition.y;
			currentPosition.x += ScrabbleConstants.BOARD_SLOT_DISTANCE;
		}
	}

	#endregion
}