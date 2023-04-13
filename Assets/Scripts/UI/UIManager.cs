using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _invenUI;
    [SerializeField] GameObject _sealUI;
    [SerializeField] RectTransform _drawRect;
    [SerializeField] GameObject _unitInfoPanel;

    public RectTransform GetRectUI()
    {
        return _drawRect;
    }

    public void InvenOnOffButton()
    {
        _invenUI.SetActive(_invenUI.activeSelf == false);
    }

    public void SealOnOffButton()
    {
        _sealUI.SetActive(_sealUI.activeSelf == false);
    }

    public void UnitInfoOnOff(bool isOpen)
    {
        _unitInfoPanel.SetActive(isOpen);
    }
}
