﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Opened(other);
        }
    }
    void Opened(Collider2D player)
    {
        if (player.GetComponent<PlayersInventory>().bronzeKeys > 0)
        {
            FindObjectOfType<AudioManager>().Play("OpenDoor");
            GameObject.Find("Player").GetComponent<PlayersInventory>().bronzeKeys--;
            Destroy(gameObject);
        }

    }
}
