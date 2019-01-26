using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchAssigner : Singleton<PatchAssigner>
{

	public float unitsPerPatch = 10f;
	public Vector2 jitterMax;
	public Sprite[] patchGraphics;
	public GameObject patchPrefab;
	public float patchSize = 0.02f;

    void Start()
    {
        BuildPatches();
    }

    private void BuildPatches() {
    	Vector2 halfScale = new Vector2(transform.localScale.x, transform.localScale.z) / 2f;
    	for (float x = -halfScale.x; x < halfScale.x; x += unitsPerPatch) {
    		for (float z = -halfScale.y; z < halfScale.y; z += unitsPerPatch) {
    			Vector3 position = new Vector3(x + Random.Range(-jitterMax.x, jitterMax.x), transform.position.y, z + Random.Range(-jitterMax.y, jitterMax.y));
    			BuildPatch(position);
    		}
    	}
    }

    private void BuildPatch(Vector3 position) {
    	GameObject patch = Instantiate(patchPrefab, transform);
    	patch.transform.position = position;
    	patch.transform.localScale = new Vector3(patchSize / patch.transform.lossyScale.x, patchSize / patch.transform.lossyScale.z, patchSize / patch.transform.lossyScale.y); //Sorry voodoo
    	patch.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
    	int imageIndex = Random.Range(0, patchGraphics.Length);
    	patch.GetComponent<SpriteRenderer>().sprite = patchGraphics[imageIndex];
    }
}
