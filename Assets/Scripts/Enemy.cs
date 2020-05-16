using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            //  Not the player, just turn around
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
