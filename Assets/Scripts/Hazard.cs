using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hazard/onTriggerEnter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player.Instance.CurrentHealth >= 0)
            {
                Player.Instance.CurrentHealth -= 1;
                Debug.Log("health = " + Player.Instance.CurrentHealth);
            }
            else
            {
                //kill player
                Player.Instance.CurrentHealth = 0;
                Destroy(Player.Instance);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hazard/onTriggerExit");
        }
    }
}
