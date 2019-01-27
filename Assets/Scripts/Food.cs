using UnityEngine;

public class Food : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player.main.PlayerSize += 1;
            Player.main.transform.localScale += new Vector3(.1F, .1F, .1F);
            Debug.Log("widened scale");

            if (Player.main.shell == null) // if no shell, heal player
            {
                Player.main.CurrentHealth += 10;
                Player.main.GetComponent<Rigidbody>().mass += 1;

                if (Player.main.CurrentHealth >= Player.main.MaxHealth - 10)
                    Player.main.CurrentHealth = Player.main.MaxHealth;
            }
            else // if has shell on, heal shell
            {
                Player.main.shell.currentHealth += 10;

                if (Player.main.shell.currentHealth >= Player.main.shell.MAX_HEALTH - 10)
                    Player.main.shell.currentHealth = Player.main.shell.MAX_HEALTH;
            }
                
            Destroy(gameObject);
        }
    }
}

