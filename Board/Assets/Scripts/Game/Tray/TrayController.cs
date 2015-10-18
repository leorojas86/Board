using UnityEngine;
using System.Collections;

public class TrayController : MonoBehaviour 
{
	#region Variables

	public TraySlotController slotPrefab = null;

	private FSM _fsm = new FSM();

	#endregion

	#region Methods

	public void Initialize()
	{
		InitializeFSM();
	}

	private void InitializeFSM()
	{
		TrayLoadTrayState loadState = new TrayLoadTrayState(this);

		_fsm.CurrentState = loadState;//Setting initial state
	}

	void Update() 
	{
	
	}

	#endregion
}
