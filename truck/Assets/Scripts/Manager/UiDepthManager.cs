using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDepthUi
{
    void Close();
}
public static class UiDepthManager
{
    public static Transform Root {get; private set;}
    public static IReadOnlyList<GameObject> PopupList => _popupList;
    private static List<GameObject> _popupList =new List<GameObject>();
    public static void SetRoot(Transform root)
    {
        Root = root;
    }

    public static GameObject ShowPopup(string path)
    {
        var popup = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/UI/{path}"));
        popup.transform.SetParent(Root, false);
        _popupList.Add(popup);
        return popup;
    }
    public static void OnClosePopup(GameObject popup)
    {
        _popupList.Remove(popup);
        GameObject.Destroy(popup);
    }
    public static void OnBack()
    {
        GameObject.Destroy(_popupList[0]);
        _popupList.RemoveAt(0);
    }
}
