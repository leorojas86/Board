using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardLine
{
    #region Variables

    private List<SlotData> _slots = null;

    #endregion

    #region Properties

    public List<SlotData> Slots
    {
        get { return _slots; }
    }

    public int NewLettersCount
    {
        get
        {
            int newLettersCount = 0;

            for(int x = 0; x < _slots.Count; x++)
            {
                if(_slots[x].HasTemporalChip)
                    newLettersCount++;
            }

            return newLettersCount;
        }
    }

    public bool HasInvalidWord
    {
        get
        {
            string stringVar = GetString();

            if(stringVar != string.Empty)
                return ScrabbleLogicManager.Instance.WordsDatabase.HasWord(stringVar);

            return false;
        }
    }

    #endregion

    #region Constructors

    public BoardLine()
    {
        _slots = new List<SlotData>();
    }

    public BoardLine(List<SlotData> slots)
    {
        _slots = slots;
    }

    #endregion

    #region Methods

    public string GetString()
    {
        string stringVar = string.Empty;

        for(int x = 0; x < _slots.Count; x++)
        {
            SlotData currentSlot = _slots[x];

            if (currentSlot.Chip != null)
                stringVar += currentSlot.Chip.letter;
        }

        return stringVar;
    }

    public void Commit()
    {
        for(int x = 0; x < _slots.Count; x++)
            _slots[x].Commit();
    }

    #endregion
}
