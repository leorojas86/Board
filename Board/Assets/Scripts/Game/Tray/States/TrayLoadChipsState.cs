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
		//List<ChipData> chipsData 	= wordsDatabase.GetRandomChips(trayData.Size);


	}

	#endregion
}
