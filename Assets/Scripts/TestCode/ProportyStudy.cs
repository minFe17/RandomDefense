using UnityEngine;

public class ProportyStudy : MonoBehaviour
{
    private void Start()
    {
        PropData pd = new PropData();
        pd.PValue = 50;
        Debug.Log($"pValue : {pd.PValue}");
        pd.PStr = "데이터 체크합니다";
        pd.dataCheck();
    }
}

public class PropData
{
    float _maxHp;
    private float _hp;

    public float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            if (_hp - value < 0)
                _hp = 0;
            if (_hp + value > _maxHp)
                _hp = _maxHp;
        }
    }

    private float _def = 3.5f;
    public float DEF { get { return _def; } }   //readOnly

    private int _pValue;

    public int PValue { get { return _pValue; } set { _pValue = value; } }

    private string _pStr = "";
    public string PStr { get; set; }

    public void dataCheck()
    {
        Debug.Log($"_pValue : {_pValue}, value : {PValue}, str is : {PStr}, _pStr is : {_pStr}");
    }
}