using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    [SerializeField] GameObject _normalObject;
    [SerializeField] GameObject _ragdollObject;
    [SerializeField] Rigidbody _rigidbody;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeObj();
        }
    }

    void ChangeObj()
    {
        CopyToRagdoll(_normalObject.transform, _ragdollObject.transform);
        Time.timeScale = 0.1f;
        _normalObject.SetActive(false);
        _ragdollObject.SetActive(true);
        _rigidbody.AddForce(Vector3.back * 200 + Vector3.up * 300, ForceMode.Impulse);
    }

    void CopyToRagdoll(Transform origin, Transform ragdoll)
    {
        for (int i = 0; i < origin.childCount; i++)
        {
            if (origin.childCount != 0)
            {
                CopyToRagdoll(origin.GetChild(i), ragdoll.GetChild(i));
            }
            ragdoll.GetChild(i).localPosition = origin.GetChild(i).localPosition;
            ragdoll.GetChild(i).localRotation = origin.GetChild(i).localRotation;
        }
    }
}
