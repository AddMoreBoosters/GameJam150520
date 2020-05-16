using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    private Vector3 _offset;

    public bool followPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _playerTransform.position;
    }

    private void LateUpdate()
    {
        if (followPlayer == true)
        {
            transform.position = _playerTransform.position + _offset;
        }
    }
}
