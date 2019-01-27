using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFixer : MonoBehaviour
{
	public SpriteRenderer[] spriteRenderers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float relativeZ = Player.main.transform.position.z - transform.position.z;
        int layer = 10 * (int)Mathf.Sign(relativeZ) + Mathf.RoundToInt(relativeZ * 10);
        foreach(SpriteRenderer spr in spriteRenderers) {
        	if (spr != null) spr.sortingOrder = layer;
        }
    }
}
