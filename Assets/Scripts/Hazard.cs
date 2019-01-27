using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private float damage;
    public Type type = Type.Rock;
    public float rockSpeed = 3f;

    public enum Type
    {
        Rock,
        Pebble,
        Fish,
    };

    void Start()
    { 
        Debug.Log("Hazard/onTriggerEnter");
        switch (type)
        {
            case Type.Rock:
                damage = 20;
                break;
            case Type.Pebble:
                damage = 0;
                break;
            case Type.Fish:
                damage = 100;
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hazard/onTriggerEnter");

            if (Player.main.shell == null)
            {
                //death out of shell
                Player.main.CurrentHealth = 0;
            }
            else
            {
                if (Player.main.shell.currentHealth > 0)
                {
                    Player.main.shell.currentHealth -= damage * Player.main.shell.DMG_MULT;
                }
            }
        }
    }

    void Update()
    {
        if (type == Type.Rock)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (rockSpeed * Time.deltaTime), transform.position.z);
        }
    }
}
