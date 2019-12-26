using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public static class EditorCoroutine
{
	private static List<IEnumerator> coroutines;
	static EditorCoroutine()
	{
		coroutines = new List<IEnumerator>();
		EditorApplication.update += Update;
	}

	public static void StartCoroutine(IEnumerator coroutine)
	{
		coroutines.Add(coroutine);
	}

	public static void StopAllCoroutines()
	{
		coroutines.Clear();
	}

	private static void Update()
	{
		for (int i = coroutines.Count - 1; i >= 0; --i)
		{
			IEnumerator e = coroutines[i];
			if (e.MoveNext())
			{
				// TODO: process return value here
			}
			else
			{
				coroutines.RemoveAt(i);
			}
		}
	}
}
