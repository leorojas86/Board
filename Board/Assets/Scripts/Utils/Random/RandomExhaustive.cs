using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// Project: Flash to Unity.
/// File: FPLRandomExhaustive
/// Copyright 2014 Fair Play Labs. All rights reserved.
/// Created by Leonardo Rojas
/// <summary>
/// This class contains the logic to manage exhaustive randoms.
/// </summary>
public sealed class RandomExhaustive<T>
{
	#region Variables
	
	private List<T> _list;
	private List<T> _shuffledList;
	public object tag;
	
	#endregion
	
	#region Properties
	
	public List<T> List
	{
		get { return _list; }
		set
		{
			_list = value;
			
			//Removing unexistent items
			List<T> shuffledClone = new List<T>(_shuffledList);
			
			for(int x = 0; x < shuffledClone.Count; x++)
			{
				T item = shuffledClone[x];

				if(!_list.Contains(item))
					_shuffledList.Remove(item);
			}
			
			//Adding new items
			List<T> newItems = new List<T>();
			
			for(int x = 0; x < _list.Count; x++)
			{
				T item = _list[x];

				if(!_shuffledList.Contains(item))
					newItems.Add(item);
			}
			
			List<T> shuffleNewItems = RandomUtils.ShuffleList<T>(newItems);
			_shuffledList.AddRange(shuffleNewItems);
		}
	}
		
	#endregion
	
	#region Constructor
	
	public RandomExhaustive(List<T> list)
	{
		Fill(list);
	}
	
	#endregion
	
	#region Methods
	
	public T GetRandomItem()
	{
		T randomValue = _shuffledList[0];
		
		_shuffledList.Remove(randomValue);
		
		if(_shuffledList.Count == 0)
		{
			Shuffle();
			
			//Moving the last item to the end of the list
			_shuffledList.Remove(randomValue);
			_shuffledList.Add(randomValue);
		}
		
		return randomValue;
	}
	
	private void Shuffle()
	{
		_shuffledList = RandomUtils.ShuffleList<T>(_list);
	}
	
	public void Fill(List<T> list)
	{
		_list = list;
		Shuffle();
	}
	
	#endregion
}
