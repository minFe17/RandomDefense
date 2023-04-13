using UnityEngine;
using Utils;

public class BulletCon : MonoBehaviour
{
    EBulletType _bulletType;
    public EBulletType BulletType { get { return _bulletType; } }

    MonsterAgent _target;
    public MonsterAgent Target { set { _target = value; } }

    void Update()
    {
        MoveToTarget();
        CheckDist();
    }

    void MoveToTarget()
    {
        if (_target == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position,
                                                 Time.deltaTime * GenericSingleton<BulletDatas>.Instance[_bulletType].Speed);
    }

    void CheckDist()
    {
        if (_target == null)
            return;
        if (Vector3.Distance(_target.transform.position, transform.position) < 0.1f)
        {
            _target = null;
            gameObject.SetActive(false);
        }
    }
}
