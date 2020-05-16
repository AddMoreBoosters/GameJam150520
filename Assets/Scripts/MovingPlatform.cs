using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _transform1, _transform2;
    private Vector3 _position1, _position2;
    [SerializeField]
    private float _speed = 1f;
    private bool _reverse = false;
    [SerializeField]
    private float _position = 0f;

    private void Start()
    {
        _position1 = _transform1.position;
        _position2 = _transform2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_reverse == true)
        {
            _position -= Time.deltaTime * _speed;
        }
        else
        {
            _position += Time.deltaTime * _speed;
        }

        if (_position <= 0f)
        {
            _reverse = false;
        }
        else if (_position >= 1f)
        {
            _reverse = true;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(_position1, _position2, _position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
