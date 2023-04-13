using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BulletFactory : MonoBehaviour
{
    List<BulletFactoryBase> _bulletFactries = new List<BulletFactoryBase>();

    void Init()
    {
        if (_bulletFactries.Count > 0)
            return;
        _bulletFactries.Add(new FastBulletFactory());
        _bulletFactries.Add(new SlowBulletFactory());
    }

    public Bullet MakeBullet(EBulletType eType, int dmg, MonsterAgent target, Vector3 from)
    {
        Init();
        return _bulletFactries[(int)eType].MakeBullet(dmg, target, from);
    }
}

public enum EBulletType
{
    FastBullet,
    SlowBullet,
    Max,
}


public abstract class Bullet
{
    protected GameObject _obj;
    protected MonsterAgent _target;
    protected int _dmg;

    public abstract void Init(int dmg, MonsterAgent target, Vector3 from);
}

public class FastBullet : Bullet
{
    public override void Init(int dmg, MonsterAgent target, Vector3 from)
    {
        _dmg = dmg;
        _target = target;
        _obj = GenericSingleton<BulletPool>.Instance.GetPoolObject(EBulletType.FastBullet);
        _obj.transform.position = from;
        if (_obj.GetComponent<BulletCon>() != null)
            _obj.GetComponent<BulletCon>().Target = target;
    }
}

public class SlowBullet : Bullet
{
    public override void Init(int dmg, MonsterAgent target, Vector3 from)
    {
        _dmg = dmg;
        _target = target;
        _obj = GenericSingleton<BulletPool>.Instance.GetPoolObject(EBulletType.SlowBullet);
        _obj.transform.position = from;
        if (_obj.GetComponent<BulletCon>() != null)
            _obj.GetComponent<BulletCon>().Target = target;
    }
}

public abstract class BulletFactoryBase
{
    public abstract Bullet MakeBullet(int dmg, MonsterAgent target, Vector3 from);
}

public class FastBulletFactory : BulletFactoryBase
{
    public override Bullet MakeBullet(int dmg, MonsterAgent target, Vector3 from)
    {
        Bullet bullet = new FastBullet();
        bullet.Init(dmg, target, from);
        return bullet;
    }
}

public class SlowBulletFactory : BulletFactoryBase
{
    public override Bullet MakeBullet(int dmg, MonsterAgent target, Vector3 from)
    {
        Bullet bullet = new SlowBullet();
        bullet.Init(dmg, target, from);
        return bullet;
    }
}
