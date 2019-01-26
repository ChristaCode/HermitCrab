using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour {

    [SerializeField] float FollowSpeed = 5f;
    [SerializeField] float ZoomSpeed = 1f;
    [SerializeField] float OffsetX = 0f;
    [SerializeField] float OffsetY = 10f;
    [SerializeField] float OffsetZ = 10f;

    [SerializeField] float ZoomDelay = 2f;
    float zoomOutDelayCounter;
    float zoomInDelayCounter;
    float camMinDist = 40f;
    float camMaxDist = 60f;
    public float CamSpeed;
    bool isMovingUp;
    float lastPos;
  
    Transform _playerPos;
    
    void Start()
    {
        lastPos = transform.position.y;
        _playerPos = GameObject.Find("Cam Target").transform;
    }
    void Update ()
    {     
        CamSpeed = (transform.position.y - lastPos) / Time.deltaTime;

        if (transform.position.y >= lastPos)
            isMovingUp = true;
        else
            isMovingUp = false;
            
        lastPos = transform.position.y;

        var targetPos = new Vector3(_playerPos.position.x + OffsetX, _playerPos.position.y + OffsetY, _playerPos.position.z + OffsetZ);
        transform.position -= (transform.position - targetPos) * FollowSpeed * Time.deltaTime;

        var camSize = Camera.main.fieldOfView;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if(zoomInDelayCounter != 0)
                zoomInDelayCounter = 0f;

            zoomOutDelayCounter += Time.deltaTime;
            
            if (camSize < camMaxDist && zoomOutDelayCounter > ZoomDelay/3)
                Camera.main.fieldOfView = Mathf.Lerp(camSize, camMaxDist, ZoomSpeed * Time.deltaTime);
        }
        else
        {
            if (zoomOutDelayCounter != 0)
                zoomOutDelayCounter = 0f;

                zoomInDelayCounter += Time.deltaTime;

            if (camSize > camMinDist && zoomInDelayCounter > ZoomDelay)
                Camera.main.fieldOfView = Mathf.Lerp(camSize, camMinDist, ZoomSpeed * Time.deltaTime);
        }
    }
}
