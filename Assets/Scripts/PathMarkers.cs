using UnityEngine;

public class PathMarkers : MonoBehaviour
{
    [SerializeField] Transform[] _paths;
    public Transform[] Paths { get { return _paths; } }
}
