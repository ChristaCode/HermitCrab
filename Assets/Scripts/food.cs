using UnityEngine;

public class food : MonoBehaviour
{
    Animator anim;                              // Reference to the animator component.
    //GameObject player;                          // Reference to the player GameObject.

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.Instance.PlayerSize += 1;
            anim.SetTrigger("PlayerGrowth");

            Destroy(gameObject);

        }
    }
}

