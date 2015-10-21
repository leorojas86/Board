using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoardData 
{
    #region Enums

    public enum BoardResult
    {
        OK,
        FirstWordMustUseCenterSlot,
        NewWordMustTouchTheAtLeastOneLetterOnBoard,
        NewWordLettersMustBeOnSameLine,
        ThereAreInvalidWords
    }

    #endregion

    #region Variables

    private List<List<BoardSlotData>> _slotsMatrix = new List<List<BoardSlotData>>();

    private List<BoardLine> _verticalLines   = new List<BoardLine>();
    private List<BoardLine> _horizontalLines = new List<BoardLine>();

    private BoardSlotData _centerSlot = null;

    private List<BoardLine> _modifiedLines      = null;
    private List<BoardLine> _usedLines          = null;
    private List<BoardLine> _invalidWordLines   = null;

    private int _size = 0;

    #endregion

    #region Properties

    public int Size
    {
        get { return _size; }
        set
        {
            if(_size != value)
            {
                _size = value;

                CreateSlotsMatrix();
                LoadSlotTypes();
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

        if(CheckForNotTouchingLetters())
            return BoardResult.NewWordMustTouchTheAtLeastOneLetterOnBoard;

        _modifiedLines = GetModifiedLines();
        _usedLines     = GetUsedLines(_modifiedLines);

        if(_usedLines.Count > 1)
            return BoardResult.NewWordLettersMustBeOnSameLine;

        _invalidWordLines = GetInvalidWordLines();

        if(_invalidWordLines.Count > 0)
            return BoardResult.ThereAreInvalidWords;

        Commit();

        return BoardResult.OK;
    }

    private bool CheckForNotTouchingLetters()
    {

        return false;
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

        for(int x = 0; x < _size; x++)
            _horizontalLines.Add(new BoardLine());

        for(int x = 0; x < _size; x++)
        {
            List<BoardSlotData> collum = CreateSlotsCollum();
            _slotsMatrix.Add(collum);
            _verticalLines.Add(new BoardLine(collum));
        }

        int centerIndex = _size / 2;
        _centerSlot     = _slotsMatrix[centerIndex][centerIndex];
    }

    private List<BoardSlotData> CreateSlotsCollum()
    {
        List<BoardSlotData> slotsCollum = new List<BoardSlotData>();

        for (int x = 0; x < _size; x++)
        {
            BoardSlotData slot = new BoardSlotData();
            slotsCollum.Add(slot);
            _horizontalLines[x].Slots.Add(slot);
        }

        return slotsCollum;
    }

    private void LoadSlotTypes()
    {
        TextAsset boardLayoutTextAsset = Resources.Load<TextAsset>("BoardLayout");

        string[] lines = boardLayoutTextAsset.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

        for(int y = 0; y < lines.Length; y++)
        {
            string currentLine = lines[y];
            string[] types     = currentLine.Split(new string[]{","}, System.StringSplitOptions.RemoveEmptyEntries);

            for(int x = 0; x < types.Length; x++)
            {
                string currentType          = types[x];
                BoardSlotData currentSlot   = _slotsMatrix[x][y];

                if(currentType == "  ")
                    currentSlot.Type = BoardSlotData.SlotType.Empty;
                else if(currentType == "**")
                    currentSlot.Type = BoardSlotData.SlotType.Center;
                else
                    currentSlot.Type = (BoardSlotData.SlotType)Enum.Parse(typeof(BoardSlotData.SlotType), currentType);
            }
        }
    }

    #endregion
}
