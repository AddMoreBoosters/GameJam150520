using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1f;
    private float _direction = 1f;

    private void FixedUpdate()
    {
        transform.Translate(transform.right * Time.fixedDeltaTime * _moveSpeed * _direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            //  Not the player, just turn around
            _direction *= -1f;
        }

        //  Hit the player, it's game over
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Player"))
        {
            //  Not the player, don't care
            return;
        }

        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("Something with Player tag hit an Enemy trigger collider, but no PlayerController component was found");
            return;
        }

        playerController.Jump();

        //  Enemy was jumped on, player bounces, now enemy needs to despawn and score needs to be increased
    }
}
