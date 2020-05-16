using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _flag;
    [SerializeField]
    private Material _startMaterial, _finishMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _flag.material = _startMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _flag.material = _finishMaterial;
        }
    }
}
