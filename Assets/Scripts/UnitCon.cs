using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class UnitCon : MonoBehaviour
{
    [SerializeField] GameObject _marker;

    NavMeshAgent _agent;
    EUnitType _eType;
    UnitState _state;

    void Awake()
    {
        ChangeUnitState(new UnitSearchState());
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_state != null)
            _state.MainLoop();
    }

    public void Init(EUnitType eType)
    {
        _eType = eType;
    }

    public EUnitType GetUnitType()
    {
        return _eType;
    }

    public void SelectUnit()
    {
        _marker.SetActive(true);
    }

    public void DeSelectUnit()
    {
        _marker.SetActive(false);
    }

    public void MoveTo(Vector3 dest)
    {
        _agent.SetDestination(dest);
        ChangeUnitState(new UnitMoveState());
    }

    public void ChangeUnitState(UnitState state)
    {
        _state = state;
        if (_state != null)
            _state.OnEnter(this);
    }

    public bool isMoveEnd()
    {
        if (_agent.remainingDistance <= 0)
            return true;
        return false;
    }
}

public class UnitState
{
    protected UnitCon _unitCon;

    public virtual void OnEnter(UnitCon unitCon)
    {
        _unitCon = unitCon;
    }
    
    public virtual void MainLoop()
    {

    }
}