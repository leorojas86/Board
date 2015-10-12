using UnityEngine;
using System.Collections;

public class ScrabbleGame
{
    #region Methods

    void Awake()
    {
        ScrabbleLogicManager.Instance.Initialize();
    }

    #endregion
}
