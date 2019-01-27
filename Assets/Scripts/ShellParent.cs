using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellParent : MonoBehaviour
{
	[HideInInspector] public Transform attachParent;
	public Vector3 shellOffset;
	public SpriteRenderer spriteRenderer;

    public enum Type
    {
        Default,
        Crisps,
        Tin,
        Round,
    };

    public Type type = Type.Default;
    [HideInInspector] public float MAX_HEALTH;
    [HideInInspector] public float SPD_MULT;
    [HideInInspector] public float DMG_MULT;

    public float currentHealth;
    Image shellHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
        shellHealthBar = GameObject.Find("ShellHealthBar").GetComponent<Image>();

        switch (type)
        {
            case Type.Default:
                MAX_HEALTH = 100;
                SPD_MULT = 1f;
                DMG_MULT = 1f;
                break;
            case Type.Crisps:
                MAX_HEALTH = 50;
                SPD_MULT = 1f;
                DMG_MULT = 2.0f;
                break;
            case Type.Tin:
                MAX_HEALTH = 200;
                SPD_MULT = 0.5f;
                DMG_MULT = 0.5f;
                break;
            case Type.Round:
                MAX_HEALTH = 100;
                SPD_MULT = 1.5f;
                DMG_MULT = 1f;
                break;
        }
        currentHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.main.shell == null)
        {
            shellHealthBar.fillAmount = 0;
        } else {
            shellHealthBar.fillAmount = (float)(currentHealth * .01);
        }
    }

    public void Attach(Transform newParent) {
		if (attachParent != null) {
			//There already is a parent
			return;
		}

		attachParent = newParent;
		transform.parent = newParent;
		if (newParent != null) transform.localPosition = shellOffset;
		spriteRenderer.enabled = newParent == null;
        UpdateSprite();

    }

	public void Drop() {
		attachParent = null;
		transform.parent = null;
        spriteRenderer.enabled = true;
    }

    private void UpdateSprite()
    {

        spriteRenderer.sprite = Player.main.GetShellSprite(this);
    }

}
