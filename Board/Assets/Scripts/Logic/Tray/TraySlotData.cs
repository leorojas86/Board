using UnityEngine;
using System.Collections;

public class TraySlotData
{
    #region Variables

    private ChipData _chip = null;

    #endregion

    #region Properties

    public ChipData Chip
    {
        get { return _chip; }
        set { _chip = value; }
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

    /*public void Commit()
    {
    }

    public void Revert()
    {
        _chip = null;
    }*/

    #endregion
}
