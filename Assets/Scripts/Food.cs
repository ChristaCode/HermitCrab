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
            }
            else // if has shell on, heal shell
            {
                // if current health is less than max health - 10, add ten to health
                if (Player.Instance.shell.currentHealth < Player.Instance.shell.MAX_HEALTH - 10)
                {
                    Player.Instance.shell.currentHealth += 10;
                }

                // if current health is less than ten points to max health, set to max health
                else if (Player.Instance.shell.currentHealth >= Player.Instance.shell.MAX_HEALTH - 10)
                {
                    Player.Instance.shell.currentHealth = Player.Instance.shell.MAX_HEALTH;
                }
            }


                
            Destroy(gameObject);
        }
    }
}

