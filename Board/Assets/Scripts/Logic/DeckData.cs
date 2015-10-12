using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckData
{
    #region Variables

    private List<SlotData> _slotsList = new List<SlotData>();

    private int _deckSize = 0;

    #endregion

    #region Properties

    public int DeckSize
    {
        get { return _deckSize; }
        set 
        {
            if(_deckSize != value)
            {
                _deckSize = value;

                _slotsList.Clear();

                for (int x = 0; x < _deckSize; x++)
                    _slotsList.Add(new SlotData());
            }
        }
    }

    #endregion

    #region Constructors

    public DeckData()
    {

    }

    #endregion
}
