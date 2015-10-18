using UnityEngine;
using System.Collections;

public class BoardState : FSMState 
{
	#region Variables

	protected BoardController _boardController = null;

	#endregion

	#region Constructors

	public BoardState(BoardController boardController)
	{
		_boardController = boardController;
	}

	#endregion
}
