using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Visible in Unity UI
    public GameObject objectToSpawn;
    public float timeTillFirstWave = 1f;
    public float timeToNewWave = 2f;

    // Private
    List<GameObject> listOfRandomSpawnedObjects;

    // Use this for initialization
    void Start()
    {
        listOfRandomSpawnedObjects = new List<GameObject>();

        // Create a new wave of spawnables every timeToNewWave (second) starting in two seconds
        InvokeRepeating("CreateSpawnablesLoop", timeTillFirstWave, timeToNewWave);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CreateSpawnablesLoop()
    {

        int randomNum = Random.Range(1, 10);
        for (int count = 0; count < randomNum; count++)
        {
            GameObject newSpawn = Instantiate(objectToSpawn, new Vector3(0, 0, 0), Quaternion.identity);
            listOfRandomSpawnedObjects.Add(newSpawn);
        }
    }

    public void CleanUp(GameObject reference)
    {
        if (listOfRandomSpawnedObjects.Contains(reference))
        {
            // This gameobject is about to be destroyed, remove it from list
            listOfRandomSpawnedObjects.Remove(reference);
            // Now destroy it (cleans up memory too)
            Destroy(reference);
        }
    }
}
