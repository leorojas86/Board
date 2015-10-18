using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrayData
{
    #region Variables

	private List<TraySlotData> _slotsList = new List<TraySlotData>();

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
					_slotsList.Add(new TraySlotData());
            }
        }
    }

    #endregion

    #region Constructors

    public TrayData()
    {
    }

    #endregion

    #region Methods

    public void Shuffle()
    {

    }

    #endregion
}
