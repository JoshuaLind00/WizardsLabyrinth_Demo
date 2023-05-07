using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private int spawnRandom;
    Vector3 spawnPosition;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public float rotationDegrees;
    public float amplitude;
    public float frequency;
    public bool testing;


    // Start is called before the first frame update
    void Start()
    {
        if (!testing)
        {
            spawnRandom = Random.Range(1, 4);
        }
        else
        {
            spawnRandom = 5;
        }
      
        if (spawnRandom == 1)
        {
            spawnPosition = new Vector3(54f, 1.6f, 60f);
            //Upper Right
        }
        else if (spawnRandom == 2)
        {
            spawnPosition = new Vector3(-54f, 1.6f, 60f);
            //Upper Left
        }
        else if (spawnRandom == 3)
        {
            spawnPosition = new Vector3(-64f, 1.6f, -65f);

            //Lower Left
        }
        else if (spawnRandom == 4)
        {
            spawnPosition = new Vector3(35f, 1.6f, -65f);
            //Lower Right
        }
        else
        {
            spawnPosition = new Vector3(-20f, 1.6f, -70f);
            //Testing Position
        }
        posOffset = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * rotationDegrees, 0f), Space.World);
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

    }
}
