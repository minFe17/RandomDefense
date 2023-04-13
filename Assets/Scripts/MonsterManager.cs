using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    PathMarkers _marker;
    public PathMarkers Marker
    {
        get
        {
            if (_marker == null)
            {
                GameObject temp = Resources.Load("Prefabs/PathMarkerBase") as GameObject;
                _marker = Instantiate(temp).GetComponent<PathMarkers>();
                DontDestroyOnLoad(temp);
            }
            return _marker;
        }
    }
    List<MonsterAgent> _monsters = new List<MonsterAgent>();

    GameObject _cubeMonster;

    public void AddMonster()
    {
        if (_cubeMonster == null)
        {
            _cubeMonster = Resources.Load("Prefabs/CubeMonster") as GameObject;
        }
        var marker = Marker;
        MonsterAgent mon = Instantiate(_cubeMonster).GetComponent<MonsterAgent>();
        mon.transform.position = _marker.Paths[0].position;
        Monster tempMon = new Monster();
        tempMon.HP = 10;
        tempMon.SPEED = 5.0f;
        tempMon.NAME = "큐브 몬스터";
        tempMon.EDefTYPE = EDefenseType.None;
        mon.Init(tempMon);
        _monsters.Add(mon);
    }

    public MonsterAgent GetTarget(Vector3 position, float dist)
    {
        MonsterAgent ret = (from monsterAgent in _monsters
                            where Vector3.Distance(position, monsterAgent.transform.position) < dist
                            orderby Vector3.Distance(position, monsterAgent.transform.position) ascending
                            select monsterAgent).FirstOrDefault();
        //_monsters.Take(5);    위에서부터 다섯개

        return ret;

    }
}

public class Monster
{
    public int HP;
    public float SPEED;
    public string NAME;
    public EDefenseType EDefTYPE;
}

public enum EDefenseType
{
    None,
    Magic,
    Physics,
}