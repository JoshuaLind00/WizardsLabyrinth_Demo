using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject KeyObj;
    private int spawnRandom;
    private Vector3 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        //spawnRandom = Random.Range(1, 4);
        spawnRandom = 5;

        if (spawnRandom == 1){
            spawnPosition = new Vector3(54f, 1.6f, 60f);
            //Upper Right
        }
        else if (spawnRandom == 2){
            spawnPosition = new Vector3(-54f, 1.6f, 60f);
            //Upper Left
        }
        else if (spawnRandom == 3){
            spawnPosition = new Vector3(-64f, 1.6f, -65f);

            //Lower Left
        }
        else if (spawnRandom == 4){
            spawnPosition = new Vector3(35f, 1.6f, -65f);
            //Lower Right
        }
        else {
            spawnPosition = new Vector3(-15f, 1.6f, -70f);
            //Testing Position
        }

        Instantiate(KeyObj, spawnPosition, Quaternion.identity);
        transform.position = spawnPosition;
    }


}
