using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
	private static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				var objs = FindObjectsOfType(typeof(T),true) as T[];
				if (objs.Length > 0)
					_instance = objs[0];
				if (objs.Length > 1)
				{
					Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
					 #if UNITY_EDITOR
					// Application.Quit() does not work in the editor so
					// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
					UnityEditor.EditorApplication.isPlaying = false;
					 #else
						 Application.Quit();
					 #endif
				}
			}
			return _instance;
		}
	}
}
