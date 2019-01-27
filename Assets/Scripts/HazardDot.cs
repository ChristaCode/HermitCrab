using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDot : MonoBehaviour
{
    private float damagePerSecond;
    public Type type = Type.Heat;

    public enum Type
    {
        Heat
    };

    void Start()
    {
        switch (type)
        {
            case Type.Heat:
                damagePerSecond = 50;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hazard/onTriggerEnter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Hazard/onTriggerStay");

        if (other.gameObject.tag == "Player")
        {
            if (Player.main.shell != null && Player.main.shell.currentHealth > 0)
            {
                Player.main.shell.currentHealth -= damagePerSecond * Time.deltaTime * Player.main.shell.DMG_MULT;
            }
            else
            {
                if (Player.main.CurrentHealth > 0)
                {
                    Player.main.CurrentHealth -= (damagePerSecond * Time.deltaTime);
                    Debug.Log("time = " + Time.deltaTime);
                    Debug.Log("health = " + Player.main.CurrentHealth);
                }
                else
                {
                    // player death
                    Player.main.CurrentHealth = 0;
                }
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
