using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Animator anim;   // Reference to the animator component.

    // Start is called before the first frame update
    void Start()
    {
        //anim = Player.main.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("SharkTrigger");
        }
    }
}
