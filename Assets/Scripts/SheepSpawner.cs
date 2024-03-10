using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{

    public bool canSpawn = false; //if true sheep will spawn
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions =  new List<Transform>();
    public float timeBetweenSpawns;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0,sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
    }

    private IEnumerator SpawnRoutine()
    {
        while(canSpawn)
        {
          SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
