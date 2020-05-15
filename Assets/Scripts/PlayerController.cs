using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRB;
    private CapsuleCollider _playerCollider;
    private bool _canJump = false;
    private float _elapsedJumpTime = 0f;
    [SerializeField]
    private float _coyoteTime = 0.2f;
    [SerializeField]
    private float _jumpSpeed = 5f;

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
        GetInput();

        //  Rotate
        //  Move

        CheckAbleToJump();
        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            _playerRB.velocity = new Vector3(_playerRB.velocity.x, _jumpSpeed, _playerRB.velocity.z);
        }
    }

    private void GetInput ()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _rotationHorizontalInput = Input.GetAxis("Mouse X");
        _rotationVerticalInput = Input.GetAxis("Mouse Y");
    }

    private void CheckAbleToJump ()
    {
        Vector3 bottom = new Vector3(_playerCollider.bounds.center.x, _playerCollider.bounds.min.y - 0.1f, _playerCollider.bounds.center.z);

        //  Check if the bottom of the collider is touching something
        if (Physics.CheckCapsule(_playerCollider.bounds.center, bottom, _playerCollider.radius) == true)
        {
            _canJump = true;
            _elapsedJumpTime = 0f;
            return;
        }

        //  If we are not touching something, but we were before, activate coyote time
        if (_canJump == true)
        {
            if (_elapsedJumpTime > _coyoteTime)
            {
                _canJump = false;
                return;
            }

            _elapsedJumpTime += Time.deltaTime;
        }
    }
}
