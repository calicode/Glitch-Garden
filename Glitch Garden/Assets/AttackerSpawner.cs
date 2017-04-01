using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    private GameObject spawnerParent;
    public GameObject[] spawnArray;
    static int numSpawners;

    // Use this for initialization
    int numAttackers;
    void Start()
    {

        spawnerParent = GameObject.Find("Spawners");
        if (!spawnerParent)

        {
            spawnerParent = new GameObject("Spawners");

        }
        transform.parent = spawnerParent.transform;


    }
    bool canSpawnCheck(GameObject objectToCheck)
    {
        Attackers attacker = objectToCheck.GetComponent<Attackers>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        int numSpawners = ResourceManager.GetNumSpawners() - 1;
        // threshold should be divided by num of attacker spawners or lanes

        float threshold = (spawnsPerSecond * Time.deltaTime) / numSpawners;
        //print("Spawn threshold is " + threshold + " With num spawners " + numSpawners);
        if (Random.value < threshold) { return true; } else { return false; }

    }







    void Spawn(GameObject objectToSpawn)
    {
        GameObject tmpobj = Instantiate(objectToSpawn) as GameObject;
        tmpobj.transform.parent = transform;
        tmpobj.transform.position = transform.position;
        // Debug.Log("Spawner " + gameObject.name + " Spawning a " + tmpobj.gameObject.name);
        numAttackers++;



    }
    // Update is called once per frame
    void Update()
    {

        foreach (GameObject myGameObject in spawnArray)
        {
            if (canSpawnCheck(myGameObject)) { Spawn(myGameObject); }
        }



    }
}
