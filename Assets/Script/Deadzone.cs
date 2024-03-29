using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Die();
        }

        if (collision.CompareTag("Box"))
        {
            collision.GetComponent<Box>().Respawn();
        }
    }
}
