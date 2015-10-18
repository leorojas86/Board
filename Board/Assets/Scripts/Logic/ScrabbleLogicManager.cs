using UnityEngine;
using System.Collections;

public class ScrabbleLogicManager
{
    #region Constants

    private int DEFAULT_BOARD_SIZE = 15;
    private int DEFAULT_DECK_SIZE  = 7;

    #endregion

    #region Variables

    private WordsDatabase _wordsDatabase    = new WordsDatabase();
    private TrayData _tray                  = new TrayData();
    private BoardData _board                = new BoardData();

    private static ScrabbleLogicManager _instance = null;

    #endregion
    
    #region Properties

    public static ScrabbleLogicManager Instance
    {
        get 
        {
            if(_instance != null)
                return _instance;

            _instance = new ScrabbleLogicManager();
            return _instance;
        }
    }

    public WordsDatabase WordsDatabase
    {
        get { return _wordsDatabase; }
    }

    public TrayData Tray
    {
        get { return _tray; }
    } 

    public BoardData Board
    {
        get { return _board; }
    }

    #endregion

    #region Constructors

    private ScrabbleLogicManager()
    {
    }

    public void Initialize()
    {
        _board.Size = DEFAULT_BOARD_SIZE;
        _tray.Size       = DEFAULT_DECK_SIZE;
    }

    #endregion

}
