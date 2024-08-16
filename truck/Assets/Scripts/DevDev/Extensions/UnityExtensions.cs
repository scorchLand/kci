using System.Collections.Generic;
using UnityEngine;
public static class UnityExtensions
{
	public static T GetOrAddComponent<T>(this Component component) where T: Component
	{
		return component.gameObject.GetOrAddComponent<T>();
	}

	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		var component = gameObject.GetComponent<T>();
		if (component == false)
		{
			component = gameObject.AddComponent<T>();
		}
		return component;
	}

	private static Queue<Transform> _queueTr = new Queue<Transform>();
	public static void ChangeLayerHierarchy(this GameObject gameObject, int layer)
	{
		_queueTr.Clear();
		
		_queueTr.Enqueue(gameObject.transform);
		while (_queueTr.Count > 0)
		{
			var target = _queueTr.Dequeue();
			target.gameObject.layer = layer;
			foreach (Transform child in target.transform)
			{
				_queueTr.Enqueue(child);	
			}
		}
	}

	public static CustomYieldInstruction WaitWhileActive(this GameObject gameObject)
	{
		return new WaitWhile(() => gameObject.activeSelf);
	}

	public static CustomYieldInstruction WaitForGameObjectDisable(this Component component)
	{
		return new WaitWhile(() => component.gameObject.activeSelf);
	}
}
