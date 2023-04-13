using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    public List<GameObject> lstObj { get { return _lstObj; } }
    
    GameObject[] _bulletObjs = null;

    void Init()
    {
        if (_bulletObjs != null)
            return;
        _bulletObjs = new GameObject[(int)EBulletType.Max];
        for(int i=0; i<(int)EBulletType.Max; i++)
        {
            _bulletObjs[i] = Resources.Load("Prefabs/" + (EBulletType)i) as GameObject;
        }
    }

    public GameObject GetPoolObject(EBulletType eType)
    {
        foreach (GameObject data in _lstObj)
        {
            if (data.activeSelf == false)
            {
                data.SetActive(true);
                return data;
            }
        }
        Init();
        GameObject temp = Instantiate(_bulletObjs[(int)eType]);
        _lstObj.Add(temp);
        return temp;
    }

    public void clearPoolObject()
    {
        foreach(GameObject obj in _lstObj)
        {
            Destroy(obj);
        }
        _lstObj.Clear();
    }
}
