using UnityEngine;
using System.Collections;

public class SlotData
{
    #region Variables

    private ChipData _chip       = null;
    private bool _isTemporalChip = false;

    #endregion

    #region Properties

    public ChipData Chip
    {
        get { return _chip; }
        set
        {
            _chip           = value;
            _isTemporalChip = true;
        }
    }

    #endregion

    #region Methods

    public void Commit()
    {
        _isTemporalChip = false;
    }

    public void Revert()
    {
        _chip           = null;
        _isTemporalChip = false;
    }

    #endregion
}
