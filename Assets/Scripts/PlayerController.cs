using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRB;
    private CapsuleCollider _playerCollider;

    public bool _canJump = false;
    [SerializeField]
    private float _moveSpeed = 3.0f;
    //[SerializeField]
    //private float _rotationSpeed = 2.0f;
    private float _elapsedJumpTime = 0f;
    [SerializeField]
    private float _coyoteTime = 0.2f;
    [SerializeField]
    private float _jumpSpeed = 5f;

    private float _horizontalInput;
    //private float _verticalInput;
    //private float _rotationHorizontalInput;

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

        CheckAbleToJumpAndMove();
        
        //transform.Translate(new Vector3(_horizontalInput, 0f, 0f) * Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
        {
            _playerRB.velocity = new Vector3(_playerRB.velocity.x, _jumpSpeed, _playerRB.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(_horizontalInput, 0f, 0f) * Time.fixedDeltaTime * _moveSpeed);
    }

    private void GetInput ()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void CheckAbleToJumpAndMove ()
    {
        Vector3 bottom = new Vector3(_playerCollider.bounds.center.x, _playerCollider.bounds.min.y + _playerCollider.radius - 0.1f, _playerCollider.bounds.center.z);
        LayerMask mask = LayerMask.GetMask("Default");

        //  Check if the bottom of the collider is touching something in the default layer
        if (Physics.CheckCapsule(_playerCollider.bounds.center, bottom, _playerCollider.radius * 0.9f, mask) == true)
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
