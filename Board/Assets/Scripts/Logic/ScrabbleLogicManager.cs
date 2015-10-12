using UnityEngine;
using System.Collections;

public class ScrabbleLogicManager
{
    #region Constants

    private int DEFAULT_BOARD_SIZE = 15;
    private int DEFAULT_DECK_SIZE  = 7;

    #endregion

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
        board.BoardSize = DEFAULT_BOARD_SIZE;
        deck.DeckSize   = DEFAULT_DECK_SIZE;
    }

    #endregion


}
