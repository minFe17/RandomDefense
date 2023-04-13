using UnityEngine;
using UnityEngine.AI;
using Utils;

public class MonsterAgent : MonoBehaviour
{
    Monster _monsterData;
    PathMarkers _paths;
    NavMeshAgent _agent;

    int _pathIndex = 1;
    int _curHp;
    float _speed;

    public void Init(Monster monsterData)
    {
        _monsterData = monsterData;
        _paths = GenericSingleton<MonsterManager>.Instance.Marker;
        _agent = GetComponent<NavMeshAgent>();
        _curHp = _monsterData.HP;
        _speed = _monsterData.SPEED;
    }

    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, _paths.Paths[_pathIndex].position)) < 0.45f)
        {
            _pathIndex++;
            if (_pathIndex >= _paths.Paths.Length)
                _pathIndex = 0;
        }
        else
        {
            _agent.SetDestination(_paths.Paths[_pathIndex].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
