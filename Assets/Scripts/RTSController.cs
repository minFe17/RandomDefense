using System.Collections.Generic;
using UnityEngine;
using Utils;

public class RTSController : MonoBehaviour
{
    Rect _drawRect;
    Vector2 _start = Vector2.zero;
    Vector2 _end = Vector2.zero;

    List<UnitCon> _selectedUnitList = new List<UnitCon>();
    public List<UnitCon> SelectedUnitList { get { return _selectedUnitList; } }


    public void ClickSelectUnit(UnitCon unit)
    {
        DeSelectAll();
        SelectUnit(unit);
    }

    public void ShiftClickSelectUnit(UnitCon unit)
    {
        if (_selectedUnitList.Contains(unit) == true)
        {
            DeSelectUnit(unit);
        }
        else
        {
            SelectUnit(unit);
        }
    }

    public void DragSelectUnit(UnitCon unit)
    {
        if (_selectedUnitList.Contains(unit) == false)
        {
            SelectUnit(unit);
        }
    }

    public void DeSelectAll()
    {
        for (int i = 0; i < _selectedUnitList.Count; i++)
        {
            _selectedUnitList[i].DeSelectUnit();
        }
        _selectedUnitList.Clear();
        GenericSingleton<UIData>.Instance.SetUnitInfo(false);
    }

    void SelectUnit(UnitCon unit)
    {
        unit.SelectUnit();
        _selectedUnitList.Add(unit);
        GenericSingleton<UIData>.Instance.SetUnitInfo(true);
    }

    void DeSelectUnit(UnitCon unit)
    {
        unit.DeSelectUnit();
        _selectedUnitList.Remove(unit);
        if (_selectedUnitList.Count <= 0)
            GenericSingleton<UIData>.Instance.SetUnitInfo(false);
    }

    public void MoveSelectedUnits(Vector3 dest)
    {
        for (int i = 0; i < _selectedUnitList.Count; i++)
        {
            _selectedUnitList[i].MoveTo(dest);
        }
    }

    void Update()
    {
        MouseClick();
        MouseDrag();
    }

    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Unit")))
            {
                UnitCon unitCon = hit.transform.GetComponent<UnitCon>();
                if (unitCon == null)
                    return;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    ShiftClickSelectUnit(unitCon);
                }
                else
                {
                    ClickSelectUnit(unitCon);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift) == false)
                {
                    DeSelectAll();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("UnitBase")))
            {
                MoveSelectedUnits(hit.point);
            }
        }
    }

    void MouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _start = Input.mousePosition;
            _drawRect = new Rect();
        }
        if (Input.GetMouseButton(0))
        {
            _end = Input.mousePosition;

            DrawDragRect();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CalculateDragRect();
            SelectUnits();

            _start = _end = Vector2.zero;
            DrawDragRect();
        }
    }

    void DrawDragRect()
    {
        GenericSingleton<UIData>.Instance.GetRect().position = (_start + _end) * 0.5f;
        GenericSingleton<UIData>.Instance.GetRect().sizeDelta = new Vector2(Mathf.Abs(_start.x - _end.x) * 1280f / Screen.width,
                                                                                 Mathf.Abs(_start.y - _end.y) * 720f / Screen.height);
    }

    void CalculateDragRect()
    {
        if (Input.mousePosition.x < _start.x)
        {
            _drawRect.xMin = Input.mousePosition.x;
            _drawRect.xMax = _start.x;
        }
        else
        {
            _drawRect.xMin = _start.x;
            _drawRect.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < _start.y)
        {
            _drawRect.yMin = Input.mousePosition.y;
            _drawRect.yMax = _start.y;
        }
        else
        {
            _drawRect.yMin = _start.y;
            _drawRect.yMax = Input.mousePosition.y;
        }
    }

    void SelectUnits()
    {
        foreach (GameObject unit in GenericSingleton<UnitPool>.Instance.lstObj)
        {
            if (unit.activeSelf == true && unit.GetComponent<UnitCon>() != null)
            {
                if (_drawRect.Contains(Camera.main.WorldToScreenPoint(unit.transform.position)))
                {
                    DragSelectUnit(unit.GetComponent<UnitCon>());
                }
            }
        }
    }
}
