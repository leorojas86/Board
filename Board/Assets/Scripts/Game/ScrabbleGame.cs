using UnityEngine;
using System.Collections;

public class ScrabbleGame : MonoBehaviour
{
	#region Variables

	public BoardController board = null;
	public TrayController tray   = null;

	public ChipController chipPrefab = null;

	private static ScrabbleGame _instance = null;

	private ChipController _draggingChip = null;

	#endregion

	#region Properties

	public static ScrabbleGame Instance
	{
		get { return _instance; }
	}

	public ChipController DraggingChip
	{
		get { return _draggingChip; }
		set { _draggingChip = value; }
	}

	#endregion

    #region Methods

    void Awake()
    {
		_instance = this;

        ScrabbleLogicManager.Instance.Initialize();

		board.Initialize();
		tray.Initialize();

		board.transform.localScale = new Vector3 (1.7f, 1.7f, 1.7f);
    }

    #endregion
}
