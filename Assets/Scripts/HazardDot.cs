using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDot : MonoBehaviour
{
    public float damagePerSecond = 1;
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
                damagePerSecond = 100;
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
        if (other.gameObject.tag == "Player")
        {
            if (Player.Instance.shell != null && Player.Instance.shell.currentHealth > 0)
            {
                Player.Instance.shell.currentHealth -= damagePerSecond * Time.deltaTime * Player.Instance.shell.DMG_MULT;
            }
            else
            {
                if (Player.Instance.CurrentHealth > 0)
                {
                    Player.Instance.CurrentHealth -= (damagePerSecond * Time.deltaTime);
                    Debug.Log("time = " + Time.deltaTime);
                    Debug.Log("health = " + Player.Instance.CurrentHealth);
                }
                else
                {
                    Player.Instance.CurrentHealth = 0;
                    //Destroy(Player.Instance);
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
