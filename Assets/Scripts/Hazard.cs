using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private float damage;
    public Type type = Type.Rock;

    public enum Type
    {
        Rock,
        Pebble,
        Fish,
    };

    void Start()
    {
        switch (type)
        {
<<<<<<< HEAD
            //Debug.Log("Hazard/onTriggerEnter");
=======
            case Type.Rock:
                damage = 20;
                break;
            case Type.Pebble:
                damage = 0;
                break;
            case Type.Fish:
                damage = 100;
                break;
>>>>>>> d090faa29ebbfd82ec0e5257a69afc0ec84ab0df
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hazard/onTriggerEnter");

            if (Player.Instance.shell == null)
            {
<<<<<<< HEAD
                Player.Instance.CurrentHealth -= (damagePerSecond * Time.deltaTime) * 100;
                //Debug.Log("time = " + Time.deltaTime);
                //Debug.Log("health = " + Player.Instance.CurrentHealth);
            }
            else
            {
                Player.Instance.CurrentHealth = 0;
=======
                //death out of shell
                Player.Instance.CurrentHealth = 0;
            }
            else
            {
                if (Player.Instance.shell.currentHealth > 0)
                {
                    Player.Instance.shell.currentHealth -= damage * Player.Instance.shell.DMG_MULT;
                }
>>>>>>> d090faa29ebbfd82ec0e5257a69afc0ec84ab0df
            }

<<<<<<< HEAD
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hazard/onTriggerExit");
=======
            Destroy(gameObject);
>>>>>>> d090faa29ebbfd82ec0e5257a69afc0ec84ab0df
        }
    }
}
