using UnityEngine;

public class Food : MonoBehaviour
{
    Animator anim;                              // Reference to the animator component.
                                                //adjust this to change speed
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

