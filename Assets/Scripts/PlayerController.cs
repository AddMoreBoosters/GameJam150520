using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRB;
    private CapsuleCollider _playerCollider;
    private bool _canJump = false;
    [SerializeField]
    private float _coyoteTime = 0.2f;

    private float _horizontalInput;
    private float _verticalInput;
    private float _rotationHorizontalInput;
    private float _rotationVerticalInput;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = gameObject.GetComponent<Rigidbody>();
        _playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Get input
        //  Rotate
        //  Move
        //  Jump if able
    }

    private void GetInput ()
    {

    }
}
