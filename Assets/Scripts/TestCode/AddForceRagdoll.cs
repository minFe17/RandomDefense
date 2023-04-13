using UnityEngine;

public class AddForceRagdoll : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 0.1f;
            _rigidbody.AddForce(Vector3.back * 300 + Vector3.up * 300, ForceMode.Impulse);
        }
    }
}
