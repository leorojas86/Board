using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordsDatabase
{
    #region Constants

    private static string[] STRINGS_SEPARATOR = new string[] { "\n" };

    private const string WORDS_FILE   = "English/Words";
    private const string LETTERS_FILE = "English/Letters"; 

    #endregion

    #region Variables

    public List<string> words   = new List<string>();
    public List<string> letters = new List<string>();

    #endregion

    #region Constructors

    public WordsDatabase()
    {
        words.AddRange(GetStringsFromFile(WORDS_FILE));
        letters.AddRange(GetStringsFromFile(LETTERS_FILE));

        //Debug.Log(words.Count);
        //Debug.Log(letters.Count);
    }

    private string[] GetStringsFromFile(string file)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(file);

        return textAsset.text.Split(STRINGS_SEPARATOR, System.StringSplitOptions.RemoveEmptyEntries);
    }

    #endregion


}
