using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        Debug.Log("health = " + Player.Instance.CurrentHealth);

        if (other.gameObject.tag == "Player")
        {
            if (Player.Instance.CurrentHealth >= 0)
            {
                // casting to int here not a good idea? Player health should be
                // defined as a float or we need to depleat it slower than 1 hp every
                // update loop
                Player.Instance.CurrentHealth -= (int)(damage * Time.deltaTime);
            }
            else
            {
                //kill player
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
