using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private bool _isThisAFall = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Player"))
        {
            //  Not the player, don't care
            return;
        }

        //  Player entered a killzone, game over
        GameController.Instance.GameOver(_isThisAFall);
    }
}
