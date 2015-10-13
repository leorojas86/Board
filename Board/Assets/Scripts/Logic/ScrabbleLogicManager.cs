using UnityEngine;
using System.Collections;

public class ScrabbleLogicManager
{
    #region Constants

    private int DEFAULT_BOARD_SIZE = 15;
    private int DEFAULT_DECK_SIZE  = 7;

    #endregion

    #region Variables

    private WordsDatabase _wordsDatabase  = new WordsDatabase();
    private DeckData _deck = new DeckData();
    private BoardData _board = new BoardData();

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

    #endregion

    #region Constructors

    private ScrabbleLogicManager()
    {
    }

    public void Initialize()
    {
        _board.BoardSize = DEFAULT_BOARD_SIZE;
        _deck.DeckSize   = DEFAULT_DECK_SIZE;
    }

    #endregion


}
