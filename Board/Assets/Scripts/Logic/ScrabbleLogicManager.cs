using UnityEngine;
using System.Collections;

public class ScrabbleLogicManager
{
    #region Variables

    public WordsDatabase wordsDatabase  = new WordsDatabase();
    public DeckData deck                = new DeckData();
    public BoardData board              = new BoardData();

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

    #endregion

    #region Constructors

    private ScrabbleLogicManager()
    {
    }

    public void Initialize()
    {

    }

    #endregion


}
