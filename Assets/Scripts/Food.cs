using UnityEngine;

public class Food : MonoBehaviour
{
    Animator anim;                              // Reference to the animator component.

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

            if (Player.Instance.shell == null) // if no shell, heal player
            {
                Player.Instance.CurrentHealth += 10;

                if (Player.Instance.CurrentHealth >= Player.Instance.MaxHealth - 10)
                    Player.Instance.CurrentHealth = Player.Instance.MaxHealth;
            }
            else // if has shell on, heal shell
            {
                Player.Instance.shell.currentHealth += 10;

                if (Player.Instance.shell.currentHealth >= Player.Instance.shell.MAX_HEALTH - 10)
                    Player.Instance.shell.currentHealth = Player.Instance.shell.MAX_HEALTH;
            }
                
            Destroy(gameObject);
        }
    }
}

