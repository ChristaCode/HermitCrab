using UnityEngine;

public class Food : MonoBehaviour
{
    Animator anim;                              // Reference to the animator component.
    Animator herbAnimator;
                                                //adjust this to change speed
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        herbAnimator = GameObject.Find("Herbert").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player has entered");

            Player.Instance.PlayerSize += 1;

            // if current health is less than max health - 10, add ten to health
            if (Player.Instance.CurrentHealth < Player.Instance.MaxHealth - 10)
            {
                Player.Instance.CurrentHealth += 10;
            }

            // if current health is less than ten points to max health, set to max health
            else if (Player.Instance.CurrentHealth >= Player.Instance.MaxHealth - 10)
            {
                Player.Instance.CurrentHealth = Player.Instance.MaxHealth;
            }
                
            Destroy(gameObject);
        }
    }
}

