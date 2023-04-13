using UnityEngine;

public class UIData : MonoBehaviour
{
    GameObject _uiMain;
    UIManager _manager;

    public void Init()
    {
        if (_uiMain != null)
            return;
        _uiMain = Resources.Load("Prefabs/UIMain") as GameObject;
        _manager = Instantiate(_uiMain).GetComponent<UIManager>();
    }

    public RectTransform GetRect()
    {
        return _manager.GetRectUI();
    }

    public void SetUnitInfo(bool isOpen)
    {
        _manager.UnitInfoOnOff(isOpen);
    }
}
