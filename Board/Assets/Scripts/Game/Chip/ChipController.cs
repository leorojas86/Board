using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChipController : MonoBehaviour 
{
	#region Variables

	private Text _text 		   = null;
	private ChipData _chipData = null;

	private FSM _fsm = new FSM();

	//private EventTrigger _eventTrigger = null;

	#endregion

	#region Properties

	public ChipData ChipData
	{
		get { return _chipData; }
		set 
		{
			if(_chipData != value)
			{
				_chipData  = value;
				_text.text = _chipData != null ? _chipData.Letter.ToString().ToUpper() : string.Empty;
			}
		}
	}

	public Text Text
	{
		get { return _text; }
	}

	/*public EventTrigger EventTrigger
	{
		get { return _eventTrigger; }
	}*/

	#endregion

	#region Methods

	void Awake()
	{
		_text = GetComponent<Text>();

		//_eventTrigger = gameObject.AddComponent<EventTrigger>();

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
		//transform.position = Input.mousePosition;
	}

	#endregion
}
