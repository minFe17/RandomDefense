using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    public List<GameObject> lstObj { get { return _lstObj; } }
    
    GameObject[] _unitObjs = null;

    void Init()
    {
        if (_unitObjs != null)
            return;
        _unitObjs = new GameObject[(int)EUnitType.Max];
        for (int i = 0; i < (int)EUnitType.Max; i++)
        {
            _unitObjs[i] = Resources.Load("Prefabs/" + (EUnitType)i) as GameObject;
        }
    }

    public GameObject GetPoolObject(EUnitType eType)
    {
        foreach (GameObject data in _lstObj)
        {
            if (data.activeSelf == false && data.GetComponent<UnitCon>().GetUnitType() == eType)
            {
                data.SetActive(true);
                return data;
            }
        }
        Init();
        GameObject temp = Instantiate(_unitObjs[(int)eType]);
        _lstObj.Add(temp);
        return temp;
    }

    public void ClearPoolObject()
    {
        foreach (GameObject obj in _lstObj)
        {
            Destroy(obj);
        }
        _lstObj.Clear();
    }
}

public enum EUnitType
{
    None,
    CapsuleUnit,
    CubeUnit,
    SphereUnit,
    CylinderUnit,
    Max,
}

public enum EUnitSize
{
    Small,
    Big,
}