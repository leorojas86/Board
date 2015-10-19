using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrayLoadChipsState : TrayState 
{
	#region Constructors

	public TrayLoadChipsState(TrayController trayController):base(trayController)
	{
	}

	#endregion

	#region Methods

	public override void OnEnter()
	{
		base.OnEnter();

		LoadChips();
	}

	private void LoadChips()
	{
		WordsDatabase wordsDatabase = ScrabbleLogicManager.Instance.WordsDatabase;
		TrayData trayData 			= ScrabbleLogicManager.Instance.Tray;
		List<ChipData> chipsData 	= wordsDatabase.GetRandomChips(trayData.Size);

		//Debug.Log(chipsData.Count);
		//Debug.Log(_trayController.Slots.Count);

		for(int x = 0; x < chipsData.Count; x++)
		{
			ChipData currentChipData   		= chipsData[x];

			//Debug.Log(currentChipData.Letter);

			ChipController newInstance 		= GameObject.Instantiate(ScrabbleGame.Instance.chipPrefab); 
			newInstance.ChipData  	   		= currentChipData;
			_trayController.Slots[x].Chip 	= newInstance;

			newInstance.gameObject.SetActive(true);
		}
	}

	#endregion
}
