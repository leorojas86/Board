using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RackData
{
    #region Variables

    private List<SlotData> _slotsList = new List<SlotData>();

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

                _slotsList.Clear();

                for (int x = 0; x < _size; x++)
                    _slotsList.Add(new SlotData());
            }
        }
    }

    #endregion

    #region Constructors

    public RackData()
    {
    }

    #endregion
}
