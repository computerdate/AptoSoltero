using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerSpiders : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 4.2881f;
    private float spawnRangeY = 0.8430097f;
    //private float spawnPosZ = -0.2243f;
    private float spawnNewPosZR = -0.179f;
    private float spawnNewPosZL = -0.379f;
    private float startDelay = 1;
    private float spawnInterval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal() {

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3((spawnRangeX), spawnRangeY, Random.Range(spawnNewPosZR, spawnNewPosZL));
        
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
