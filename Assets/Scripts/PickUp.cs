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
            PickedUp(other);
        }
    }
    void PickedUp(Collider2D player)
    {
        //Checks with what player collided
        if (this.CompareTag("Key"))
        {
            PickedUpKey(player);
        }
        if (this.CompareTag("Coin"))
        {
            PickedUpCoin(player);
        }
        if (this.CompareTag("GoldStack"))
        {
            PickedUpGoldStack(player);
        }
    }
    void PickedUpKey(Collider2D player)
    {
        //Sound plays
        FindObjectOfType<AudioManager>().Play("pickUpSound");

        //Adding to inventory
        PlayersInventory keys = player.GetComponent<PlayersInventory>();
        keys.bronzeKeys++;

        //Deleting object
        Destroy(gameObject);
    }
    void PickedUpCoin(Collider2D player)
    {
        //Sound plays
        FindObjectOfType<AudioManager>().Play("pickUpSound");

        //Adding to inventory
        PlayersInventory gold = player.GetComponent<PlayersInventory>();
        gold.money++;

        //Deleting object
        Destroy(gameObject);
    }
    void PickedUpGoldStack(Collider2D player)
    {
        //Sound plays
        FindObjectOfType<AudioManager>().Play("pickUpSound");

        //Adding to inventory
        PlayersInventory gold = player.GetComponent<PlayersInventory>();
        gold.money+=10;

        //Deleting object
        Destroy(gameObject);
    }
}
