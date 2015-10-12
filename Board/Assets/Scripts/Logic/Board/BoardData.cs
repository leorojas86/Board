using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardData 
{
    #region Enums

    public enum BoardResult
    {
        OK,
        FirstWorkMustUseCenterSlot,
        AllLettersMustBeOnSameLine,
        InvalidWord
    }

    #endregion

    #region Variables

    private List<List<SlotData>> _slotsMatrix = new List<List<SlotData>>();

    private List<BoardLine> _verticalLines   = new List<BoardLine>();
    private List<BoardLine> _horizontalLines = new List<BoardLine>();

    private int _boardSize = 0;

    #endregion

    #region Properties

    public int BoardSize
    {
        get { return _boardSize; }
        set
        {
            if(_boardSize != value)
            {
                _boardSize = value;

                CreateSlotsMatrix();
            }
        }
    }

    #endregion

    #region Constructors

    public BoardData()
    {

    }

    #endregion

    #region Methods

    public BoardResult ValidateWord()
    {
        if (GetNumerOfLinesUsed() > 1)
            return BoardResult.AllLettersMustBeOnSameLine;

        return BoardResult.OK;
    }

    private int GetNumerOfLinesUsed()
    {
        int numberOfLinesUsed = 0;

        for(int x = 0; x < _verticalLines.Count; x++)
        {
            if (_verticalLines[x].HasNewLetters)
                numberOfLinesUsed++;
        }


        for (int x = 0; x < _horizontalLines.Count; x++)
        {
            if (_horizontalLines[x].HasNewLetters)
                numberOfLinesUsed++;
        }

        return numberOfLinesUsed;
    }

    private void CreateSlotsMatrix()
    {
        _slotsMatrix.Clear();
        _verticalLines.Clear();
        _horizontalLines.Clear();

        for (int x = 0; x < _boardSize; x++)
            _horizontalLines.Add(new BoardLine());

        for (int x = 0; x < _boardSize; x++)
        {
            List<SlotData> collum = CreateSlotsCollum();
            _slotsMatrix.Add(collum);
            _verticalLines.Add(new BoardLine(collum));
        }
    }

    private List<SlotData> CreateSlotsCollum()
    {
        List<SlotData> slotsCollum = new List<SlotData>();

        for (int x = 0; x < _boardSize; x++)
        {
            SlotData slot = new SlotData();
            slotsCollum.Add(slot);
            _horizontalLines[x].Slots.Add(slot);
        }

        return slotsCollum;
    }

    #endregion
}
