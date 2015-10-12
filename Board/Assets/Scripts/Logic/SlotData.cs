using UnityEngine;
using System.Collections;

public class SlotData
{
    #region Variables

    private ChipData _chip        = null;
    private bool _hasTemporalChip = false;

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
