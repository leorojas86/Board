using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour 
{
	#region Variables

	public SlotController slotPrefab = null;

	private FSM _fsm = new FSM();

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
