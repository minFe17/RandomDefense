using UnityEngine;

public class CharacterDirver : MonoBehaviour
{
    [SerializeField] float _force;

    Rigidbody _rigidbody;
    Collider _collider;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _rigidbody.AddForce(Vector3.forward * _force);
        }
        if (Input.GetMouseButton(1))
        {
            _rigidbody.AddForce(Vector3.back * _force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ColliderWall")
            _collider.material.dynamicFriction = 150;
    }
}
