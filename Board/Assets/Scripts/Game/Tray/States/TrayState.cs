using UnityEngine;
using System.Collections;

public class TrayState : FSMState 
{
	#region Variables

	protected TrayController _trayController = null;

	#endregion

	#region Methods

	public TrayState(TrayController trayController)
	{
		_trayController = trayController;
	}

	#endregion
}
