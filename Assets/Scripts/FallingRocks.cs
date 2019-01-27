using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    float rockTimer;

    Queue<GameObject> rocks = new Queue<GameObject>();

    void Start()
    {
        spawnRockBatch();
    }

    // Update is called once per frame
    void Update()
    {
        rockTimer += Time.deltaTime;

        if (rockTimer > 4)
        {
            spawnRockBatch();
            rockTimer = 0;
        }
    }

    public void spawnRockBatch()
    {
        Vector3 startingPos = gameObject.transform.position;
        for (int i = 0; i < 5; i++)
        {
            GameObject sphere;
            if (rocks.Count < 15)
            {
                sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.AddComponent<Hazard>();
            }
            else
            {
                sphere = rocks.Dequeue();
            }
            sphere.transform.position = new Vector3(
            startingPos.x + Random.Range(-5.0f, 5.0f),
            startingPos.y + Random.Range(-5.0f, 10.0f),
            startingPos.z + Random.Range(-5.0f, 5.0f));
            rocks.Enqueue(sphere);
        }
    }
}
