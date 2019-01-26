using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damagePerSecond = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hazard/onTriggerEnter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player.Instance.CurrentHealth > 0)
            {
                Player.Instance.CurrentHealth -= (damagePerSecond * Time.deltaTime) * 100;
                //Debug.Log("time = " + Time.deltaTime);
                //Debug.Log("health = " + Player.Instance.CurrentHealth);
            }
            else
            {
                Player.Instance.CurrentHealth = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hazard/onTriggerExit");
        }
    }
}
