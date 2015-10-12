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
}
