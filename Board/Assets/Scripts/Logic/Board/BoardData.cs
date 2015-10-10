using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardData 
{
    #region Variables

    private List<List<SlotData>> slotsMatrix = new List<List<SlotData>>();

    private List<BoardLine> verticalLines   = new List<BoardLine>();
    private List<BoardLine> horizontalLines = new List<BoardLine>();

    private int boardSize = 15;

    #endregion
}
