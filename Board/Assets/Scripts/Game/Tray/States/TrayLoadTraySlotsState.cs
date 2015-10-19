using UnityEngine;
using System.Collections;

public class TrayLoadTraySlotsState : TrayState
{
	#region Constructors

	public TrayLoadTraySlotsState(TrayController trayController):base(trayController)
	{
	}

	#endregion

	#region Methods

	public override void OnEnter()
	{
		base.OnEnter();

		LoadTraySlots();

		_isCompleted = true;
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
			TraySlotController newInstance = GameObject.Instantiate(slotPrefab);
			newInstance.transform.SetParent(_trayController.transform, true);
			//newInstance.transform.localPosition = Vector3.zero;
			newInstance.transform.localPosition = new Vector3(currentPosition, 0, 0);
			newInstance.gameObject.SetActive(true);
				
			currentPosition += ScrabbleConstants.TRAY_SLOT_DISTANCE;

			_trayController.Slots.Add(newInstance);
		}
	}

	#endregion
}
