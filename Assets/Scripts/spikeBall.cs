using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeBall : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Character"))
            other.gameObject.GetComponent<onDeath>().Dead();

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touch");

            // Attempt to get the PlayerController component
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            // Check if the component is null
            if (playerController != null)
            {
                playerController.DieSoon(0f);
            }
            else
            {
                Debug.LogError("PlayerController not found on the player object.");
            }
        }
    }
}
