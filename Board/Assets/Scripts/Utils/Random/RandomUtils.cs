using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class RandomUtils 
{
	#region Methods
	
	public static List<T> ShuffleList<T>(List<T> list)
	{
		List<T> listClone    = new List<T>(list);
		List<T> shuffledList = new List<T>();
		
		while(listClone.Count > 0)
		{
			int randomListIndex   = Random.Range(0, listClone.Count);
			T currentRandomObject = listClone[randomListIndex];
			shuffledList.Add(currentRandomObject);
			listClone.RemoveAt(randomListIndex);
		}
		
		return shuffledList;
	}
	
	#endregion
}
