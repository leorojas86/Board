using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardData 
{
    #region Enums

    public enum BoardResult
    {
        OK,
        FirstWordMustUseCenterSlot,
        AllLettersMustBeOnSameLine,
        InvalidWords
    }

    #endregion

    #region Variables

    private List<List<SlotData>> _slotsMatrix = new List<List<SlotData>>();

    private List<BoardLine> _verticalLines   = new List<BoardLine>();
    private List<BoardLine> _horizontalLines = new List<BoardLine>();

    private SlotData _centerSlot = null;

    private List<BoardLine> _modifiedLines      = null;
    private List<BoardLine> _usedLines          = null;
    private List<BoardLine> _invalidWordLines   = null;

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

    public BoardResult ValidateBoard()
    {
        if(_centerSlot.Chip == null)
            return BoardResult.FirstWordMustUseCenterSlot;

        _modifiedLines = GetModifiedLines();
        _usedLines     = GetUsedLines(_modifiedLines);

        if(_usedLines.Count > 1)
            return BoardResult.AllLettersMustBeOnSameLine;

        _invalidWordLines = GetInvalidWordLines();

        if(_invalidWordLines.Count > 0)
            return BoardResult.InvalidWords;

        Commit();

        return BoardResult.OK;
    }

    private void Commit()
    {
        for(int x = 0; x < _usedLines.Count; x++)
            _usedLines[x].Commit();
    }

    private List<BoardLine> GetInvalidWordLines()
    {
        List<BoardLine> invalidWordLines = new List<BoardLine>();

        for (int x = 0; x < _verticalLines.Count; x++)
        {
            BoardLine currentLine = _verticalLines[x];

            if (currentLine.HasInvalidWord)
                invalidWordLines.Add(currentLine);
        }

        for (int x = 0; x < _horizontalLines.Count; x++)
        {
            BoardLine currentLine = _horizontalLines[x];

            if (currentLine.HasInvalidWord)
                invalidWordLines.Add(currentLine);
        }

        return invalidWordLines;
    }

    private List<BoardLine> GetUsedLines(List<BoardLine> modifiedLines)
    {
        List<BoardLine> usedLines = new List<BoardLine>();

        for (int x = 0; x < modifiedLines.Count; x++)
        {
            BoardLine currentLine = modifiedLines[x];

            if(currentLine.NewLettersCount > 1)
                usedLines.Add(currentLine);
        }

        return usedLines;
    }

    private List<BoardLine> GetModifiedLines()
    {
        List<BoardLine> modifiedLines = new List<BoardLine>();

        for(int x = 0; x < _verticalLines.Count; x++)
        {
            BoardLine currentLine = _verticalLines[x];

            if (currentLine.NewLettersCount > 0)
                modifiedLines.Add(currentLine);
        }

        for (int x = 0; x < _horizontalLines.Count; x++)
        {
            BoardLine currentLine = _horizontalLines[x];

            if(currentLine.NewLettersCount > 0)
                modifiedLines.Add(currentLine);
        }

        return modifiedLines;
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

        int centerIndex = _boardSize / 2;
        _centerSlot     = _slotsMatrix[centerIndex][centerIndex];
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
