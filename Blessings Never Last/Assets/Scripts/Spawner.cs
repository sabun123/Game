using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Visible in Unity UI
    public GameObject objectToSpawn;
    public float timeTillFirstWave = 1f;
    public float timeToNewWave = 2f;
    public GameObject angleOfSpawn;
    public GameObject point1;
    public GameObject point2;

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
        // Grab a random point anywhere on the plane
        int randomNum = Random.Range(1, 10);
        // Angle at which we want to point the spawned game objects at
        Quaternion angleToAimAt = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        for (int count = 0; count < randomNum; count++)
        {
            float xCoord = GetRandomXCoordinateFromObject();
            float zCoord = GetRandomZCoordinateFromObject();
            Debug.Log("X " + xCoord + " Z " + zCoord);
            GameObject newSpawn = Instantiate(objectToSpawn, new Vector3(xCoord, gameObject.transform.localPosition.y, zCoord), angleToAimAt);
            listOfRandomSpawnedObjects.Add(newSpawn);
        }
    }

    float GetRandomXCoordinateFromObject()
    {
        //float x1 = gameObject.transform.position.x - gameObject.transform.localScale.x / 2;
        //float x2 = gameObject.transform.position.x + gameObject.transform.localScale.x / 2;
        float x1 = point1.transform.position.x; 
        float x2 = point2.transform.position.x;
        return Random.Range(x1,x2);
    }

    float GetRandomZCoordinateFromObject()
    {
        //float z1 = gameObject.transform.position.z - gameObject.transform.localScale.z / 2;
        //float z2 = gameObject.transform.position.z + gameObject.transform.localScale.z / 2;
        float z1 = point1.transform.position.z;
        float z2 = point2.transform.position.z;
        return Random.Range(z1, z2);
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
