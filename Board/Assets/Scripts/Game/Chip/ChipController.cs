using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChipController : MonoBehaviour 
{
	#region Variables

	public Text text 		   = null;

	private ChipData _chipData = null;

	private FSM _fsm = new FSM();

	private TraySlotController _sourceTraySlot   = null;
	private BoardSlotController _parentBoardSlot = null;

	#endregion

	#region Properties

	public ChipData ChipData
	{
		get { return _chipData; }
		set 
		{
			if(_chipData != value)
			{
				_chipData = value;
				text.text = _chipData != null ? _chipData.Letter.ToString().ToUpper() : string.Empty;
			}
		}
	}

	public TraySlotController SourceTraySlot
	{
		get { return _sourceTraySlot; }
		set { _sourceTraySlot = value; }
	}

	public BoardSlotController ParentBoardSlot
	{
		get { return _parentBoardSlot; }
		set { _parentBoardSlot = value; }
	}

	#endregion

	#region Methods

	void Awake()
	{
		InitializeFSM();
	}

	private void InitializeFSM()
	{
		ChipIdleState idleState 		= new ChipIdleState(this);
		ChipDraggingState draggingState = new ChipDraggingState(this);

		idleState.AddTransition(draggingState, idleState.GotoDraggingState);

		draggingState.AddTransition(idleState, draggingState.IsCompleted);

		_fsm.CurrentState = idleState;//Initial state
	}

	void Update()
	{
		_fsm.Update();
	}

	#endregion
}
