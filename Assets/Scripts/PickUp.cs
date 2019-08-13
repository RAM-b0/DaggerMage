using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if PLAYER collided
        if (other.CompareTag("Player"))
        {
            PickedUpKey(other);
        }
    }

    void PickedUpKey(Collider2D player)
    {
        //Sound plays
        FindObjectOfType<AudioManager>().Play("KeyPickUp");

        //Adding to inventory
        PlayersInventory keys = player.GetComponent<PlayersInventory>();
        keys.bronzeKeys++;

        //Deleting object
        Destroy(gameObject);
    }

}
