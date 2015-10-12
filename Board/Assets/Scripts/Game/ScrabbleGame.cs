using UnityEngine;
using System.Collections;

public class ScrabbleGame : MonoBehaviour
{
    #region Methods

    void Awake()
    {
        ScrabbleLogicManager.Instance.Initialize();
    }

    #endregion
}
