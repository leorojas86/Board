using UnityEngine;
using System.Collections;

public class BoardSlotData
{
    #region Variables

    private ChipData _chip        = null;
    private bool _hasTemporalChip = false;
    /*private SlotData _leftSlot    = null;
    private SlotData _rightSlot   = null;
    private SlotData _topSlot     = null;
    private SlotData _bottomSlot  = null;*/

    #endregion

    #region Properties

    public ChipData Chip
    {
        get { return _chip; }
        set
        {
            _chip           = value;
            _hasTemporalChip = true;
        }
    }

    public bool HasTemporalChip
    {
        get { return _hasTemporalChip; }
    }

    /*public SlotData LeftSlot
    {
        get { return _leftSlot; }
        set { _leftSlot = value; }
    }

    public SlotData RightSlot
    {
        get { return _rightSlot; }
        set { _rightSlot = value; }
    }

    public SlotData TopSlot
    {
        get { return _topSlot; }
        set { _topSlot = value; }
    }

    public SlotData BottomSlot
    {
        get { return _bottomSlot; }
        set { _bottomSlot = value; }
    }*/

    #endregion

    #region Methods

    public void Commit()
    {
        _hasTemporalChip = false;
    }

    public void Revert()
    {
        _chip           = null;
        _hasTemporalChip = false;
    }

    #endregion
}
