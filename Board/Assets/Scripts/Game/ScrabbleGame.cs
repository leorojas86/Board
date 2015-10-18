using UnityEngine;
using System.Collections;

public class ScrabbleGame : MonoBehaviour
{
	#region Variables

	public BoardController board = null;

	private static ScrabbleGame _instance = null;

	#endregion

	#region Properties

	public static ScrabbleGame Instance
	{
		get { return _instance; }
	}

	#endregion

    #region Methods

    void Awake()
    {
		_instance = this;

        ScrabbleLogicManager.Instance.Initialize();

		board.Initialize();
    }

    #endregion
}
