using UnityEngine;
using System.Collections;

public class TrayLoadTrayState : TrayState
{
	#region Constructors

	public TrayLoadTrayState(TrayController trayController):base(trayController)
	{
	}

	#endregion

	#region Methods

	public override void OnEnter()
	{
		base.OnEnter();


	}

	private void LoadTraySlots()
	{
		TrayData trayData 	  			= ScrabbleLogicManager.Instance.Tray;
		TraySlotController slotPrefab 	= _trayController.slotPrefab;
		float traySize		    		= ScrabbleConstants.TRAY_SLOT_DISTANCE * trayData.Size;
		float slotSize 					= ScrabbleConstants.TRAY_SLOT_DISTANCE;
		float initialPosition   		= -(traySize / 2) + (slotSize / 2);
		float currentPosition   		= initialPosition;
		
		for(int x = 0; x < trayData.Size; x++)
		{
			for(int y = 0; y < trayData.Size; y++)
			{
				TraySlotController newInstance = GameObject.Instantiate(slotPrefab);
				newInstance.transform.SetParent(_trayController.transform, true);
				//newInstance.transform.localPosition = Vector3.zero;
				newInstance.transform.localPosition = new Vector3(currentPosition, 0, 0);
				
				currentPosition += ScrabbleConstants.TRAY_SLOT_DISTANCE;
			}

			currentPosition += ScrabbleConstants.TRAY_SLOT_DISTANCE;
		}
	}

	#endregion
}
