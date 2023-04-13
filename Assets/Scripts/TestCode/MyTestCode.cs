using UnityEngine;

public class MyTestCode : MonoBehaviour
{
    [SerializeField] RectTransform _rect;
    Vector2 _start = Vector2.zero;
    Vector2 _end = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _start = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            _end = Input.mousePosition;
            DrawDragRect();
        }
    }

    void DrawDragRect()
    {
        _rect.position = (_start + _end) * 0.5f;
        _rect.sizeDelta = new Vector2(Mathf.Abs(_start.x - _end.x), Mathf.Abs(_start.y - _end.y));
    }
}

public class GetValue
{
    public UnitCon GetInstance()
    {
        return new UnitCon();
    }
}

public class GetTypeInstance<T> where T : new()
{
    public T GetInstance()
    {
        return new T();
    }
}