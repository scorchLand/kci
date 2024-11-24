using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiResult : UiComponent
{
    public UiMainCanvas Parant { get; private set; }
    public TextMeshProUGUI textMeshPro;
    //public static void ShowPopup(float resultScore)
    //{
    //    var popup = Instantiate()
    //    popup.textMeshPro.text = (int)resultScore.ToString();
    //}
    public void SetUi(UiMainCanvas parant, float resultScore)
    {
        Parant = parant;
        textMeshPro.text = ((int)resultScore).ToString();
    }
    public void OnClickRestart()
    {
        SceneController.SceneChange(EScene.Main);
    }
}
