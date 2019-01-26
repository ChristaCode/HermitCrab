using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellParent : MonoBehaviour
{
	[HideInInspector] public Transform attachParent;
	public Vector3 shellOffset;

	public void Attach(Transform newParent) {
		if (attachParent != null) {
			//There already is a parent
			return;
		}

		attachParent = newParent;
		transform.parent = newParent;
		transform.localPosition = shellOffset;
		//Maybe some animation schenanigans
	}

	public void Drop() {
		attachParent = null;
		transform.parent = null;
	}


}
