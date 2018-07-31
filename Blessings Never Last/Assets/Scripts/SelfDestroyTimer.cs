using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyTimer : MonoBehaviour {

    /*  Simple script to determine how long to live in the scene
     *  then perform self cleanup once time is up
     */

    public GameObject instanceOfSpawner;
    public float lifeSpan;

	// Use this for initialization
	void Start () {
        // Find the spawn plane game object from the scene
        instanceOfSpawner = GameObject.FindGameObjectWithTag("SpawnPlane");
	}
	
	// Update is called once per frame
	void Update () {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan < 0)
        {
            // If this object has lived longer than it should have
            // Time to delete it from memory then
            selfCleanUp();
        }
	}

    void selfCleanUp()
    {
        // Self cleanup
        // Grab instance of script on the Plane Spawner gameObject
        Spawner instance = instanceOfSpawner.GetComponent<Spawner>();
        // Call the cleanup function from that script
        instance.CleanUp(gameObject);
    }

}
