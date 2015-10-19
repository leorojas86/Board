using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrayController : MonoBehaviour 
{
	#region Variables

	public TraySlotController slotPrefab = null;

	private FSM _fsm = new FSM();

	private List<TraySlotController> _slots = new List<TraySlotController>();

	#endregion

	#region Properties

	public List<TraySlotController> Slots
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
		TrayLoadTraySlotsState loadSlotsState = new TrayLoadTraySlotsState(this);
		TrayLoadChipsState loadChipsState	  = new TrayLoadChipsState(this);

		loadSlotsState.AddTransition(loadChipsState, loadSlotsState.IsCompleted);

		_fsm.CurrentState = loadSlotsState;//Setting initial state
	}

	void Update() 
	{
		_fsm.Update();
	}

	#endregion
}
