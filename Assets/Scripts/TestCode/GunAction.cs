using UnityEngine;

public class GunAction : MonoBehaviour
{
    [SerializeField] Transform _playerBase;

    Camera _cam;
    LineRenderer _lineRenderer;
    SpringJoint _springJoint;
    RaycastHit hit;

    bool _isDraw;

    void Start()
    {
        _cam = Camera.main;
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunFire();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndFire();
        }
        DrawLine();
    }

    void DrawLine()
    {
        if (_isDraw == false)
            return;
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, hit.point);
    }

    void GunFire()
    {
        Debug.DrawRay(_cam.transform.position, _cam.transform.forward * 50, Color.red, 5f);
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 50, 1 << LayerMask.NameToLayer("TargetBlock")))
        {
            _isDraw = true;
            _springJoint = _playerBase.gameObject.AddComponent<SpringJoint>();
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = hit.point;
            _springJoint.maxDistance = hit.distance;
            _springJoint.minDistance = hit.distance * 0.5f;
            _springJoint.spring = 300;
        }
    }

    void EndFire()
    {
        _isDraw = false;
        _lineRenderer.positionCount = 0;
        Destroy(_springJoint);
    }
}
