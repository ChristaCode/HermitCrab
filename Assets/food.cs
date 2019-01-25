using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.playerSize.currentSize += 1;
            anim.SetTrigger("PlayerGrowth");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            Destroy(gameObject);
        }
    }
}

