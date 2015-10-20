using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour 
{
	#region Variables

	public BoardSlotController slotPrefab = null;

	private FSM _fsm 							= new FSM();
	private List<BoardSlotController> _slots 	= new List<BoardSlotController>();

	#endregion

	#region Properties

	public List<BoardSlotController> Slots
	{
		get { return _slots; }
	}

	#endregion

	#region Methods

	public void Initialize()
	{
		InitializeFSM();
	}

	private void InitializeFSM()
	{
		BoardLoadBoardState loadBoardState = new BoardLoadBoardState(this);

		_fsm.CurrentState = loadBoardState;//Setting initial state
	}

	void Update()
	{
		_fsm.Update();
	}

	#endregion
}
