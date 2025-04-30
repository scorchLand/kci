using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiHeroInfoCell : UiComponent, IPointerDownHandler
{
    public UiHeroInfo Parant { get; private set; }
    public bool IsPressed { get; private set; }
    public GameObject goObject;

    private GameObject _goObject;

    public void Initialize(UiHeroInfo parant)
    {
        Parant = parant;
    }
    private void Update()
    {
        if (!IsPressed)
            return;
        if(_goObject != null)
        {
            _goObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButtonUp(0))
        {
            IsPressed = false;
            InputController.SetUiMode(false);
            InGameController.Instance.stageController.ScoreList[0].TryCreateTower(out Unit obj);
            obj.transform.position = _goObject.transform.position;
            if (_goObject != null)
            {
                Destroy(_goObject);
                _goObject = null;
            }
            Parant.RemoveList(this);
        }
    }
    public void OnClick()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (InGameController.Instance.stageController.StageNumber % 2 == 0)
        {
            Debug.LogError($"적 웨이브 시에만 타워 출력 가능");
            //return;
        }
        if (InGameController.Instance.stageController.ScoreList[0].Count >= 1)
        {
            IsPressed = true;
            InputController.SetUiMode(true);
            _goObject = Instantiate(goObject);
        }
    }
}
