using UnityEngine;
using Utils;

public class DefenseRunning : GameState
{
    // �ӽõ�����
    float _monsterDelay = 1f;
    float _monsterCount = 50;

    // �ǻ�� ������
    float _monsterTime = 0f;
    float _nowMonsterCount = 0;

    public override void OnEnter()
    {
        GenericSingleton<UIData>.Instance.Init();
        var unitList = GenericSingleton<RTSController>.Instance.SelectedUnitList;
    }

    public override void MainLoop()
    {
        MakeMonsterLoop();
    }

    void MakeMonsterLoop()
    {
        _monsterTime += Time.deltaTime;
        if (_monsterTime >= _monsterDelay && _nowMonsterCount < _monsterCount)
        {
            GenericSingleton<MonsterManager>.Instance.AddMonster();
            _monsterTime = 0f;
            _nowMonsterCount++;
        }
    }
}