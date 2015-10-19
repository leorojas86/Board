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

    private List<string> _words   = new List<string>();
    private List<string> _letters = new List<string>();

    #endregion

    #region Constructors

    public WordsDatabase()
    {
        _words.AddRange(GetStringsFromFile(WORDS_FILE));
        _letters.AddRange(GetStringsFromFile(LETTERS_FILE));

        //Debug.Log(words.Count);
        //Debug.Log(letters.Count);
    }

    private string[] GetStringsFromFile(string file)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(file);

        return textAsset.text.Split(STRINGS_SEPARATOR, System.StringSplitOptions.RemoveEmptyEntries);
    }

    #endregion

    #region Methods

    public bool HasWord(string word)
    {
        return _words.Contains(word);
    }

	public List<ChipData> GetRandomChips(int count)
	{
		int randomWordIndex = Random.Range(0, _words.Count);
		string randomWord   = _words[randomWordIndex];

		while(randomWord.Length > count)
			randomWord.Remove(randomWord.Length - 1);

		int firstChar = 'a';
		int lastChar  = 'z';

		while(randomWord.Length < count)
			randomWord += Random.Range(firstChar, lastChar);

		List<ChipData> chips = new List<ChipData>();

		for(int x = 0; x < randomWord.Length; x++)
			chips.Add(new ChipData(randomWord[x]));

		return RandomUtils.ShuffleList<ChipData>(chips);
	}

    #endregion

}
