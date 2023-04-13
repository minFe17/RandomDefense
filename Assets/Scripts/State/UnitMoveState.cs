using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class UnitMoveState : UnitState
{
    public override void OnEnter(UnitCon unitCon)
    {
        base.OnEnter(unitCon);
    }

    public override void MainLoop()
    {
        CheckMoveEnd();
    }

    void CheckMoveEnd()
    {
        if (_unitCon.isMoveEnd() == true)
        {
            _unitCon.ChangeUnitState(new UnitSearchState());
        }
    }
}

public class UnitSearchState : UnitState
{
    float _coolTime = 0;
    MonsterAgent _target = null;

    public override void OnEnter(UnitCon unitCon)
    {
        base.OnEnter(unitCon);
    }

    public override void MainLoop()
    {
        _coolTime += Time.deltaTime;
        if (_coolTime >= 1f)
        {
            _coolTime = 0f;
            _target = GenericSingleton<MonsterManager>.Instance.GetTarget(_unitCon.transform.position, 3f);
            if (_target != null)
            {
                _unitCon.ChangeUnitState(new UnitAttackState());
            }
        }
    }
}

public class UnitAttackState : UnitState
{
    float _coolTime = 0;

    public override void OnEnter(UnitCon unitCon)
    {
        base.OnEnter(unitCon);
    }

    public override void MainLoop()
    {
        MonsterAgent target = GenericSingleton<MonsterManager>.Instance.GetTarget(_unitCon.gameObject.transform.position, 5);
        if (target != null)
        {
            GenericSingleton<BulletFactory>.Instance.MakeBullet(EBulletType.FastBullet, 10, target, _unitCon.transform.position);
            _unitCon.ChangeUnitState(new UnitSearchState());
        }
    }
}