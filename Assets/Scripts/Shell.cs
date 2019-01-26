using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shell : MonoBehaviour
{
    public enum Type
    {
        Default,
        Crisps,
        Tin,
        Round,
    };

    public Type type = Type.Default;
    private int MAX_HEALTH;
    private float SPD_MULT;

    private int currentHealth;

    Image shellHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        shellHealthBar = GameObject.Find("ShellHealthBar").GetComponent<Image>();

        switch (type)
        {
            case Type.Default:
                MAX_HEALTH = 100;
                SPD_MULT = 1f;
                break;
            case Type.Crisps:
                MAX_HEALTH = 50;
                SPD_MULT = 1f;
                break;
            case Type.Tin:
                MAX_HEALTH = 200;
                SPD_MULT = 0.5f;
                break;
            case Type.Round:
                MAX_HEALTH = 100;
                SPD_MULT = 1.5f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        shellHealthBar.fillAmount = (float)(currentHealth * .01);
    }
}
