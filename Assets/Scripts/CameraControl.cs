using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    private Vector3 velocity;
    private Vector3 velocityRef;
    public float ACC_TIME = .4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetPosition = target.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityRef, ACC_TIME);
    }
}
