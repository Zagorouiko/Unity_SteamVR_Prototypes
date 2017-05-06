using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {

    public enum State
    {
        Idle,
        Initialize,
        Setup,
        SpawnMob
    }

    public GameObject[] mobPrefab;  //array that holds mob prefabs that will be spawned
    public GameObject[] spawnPoints;

    // Use this for initialization

        void Awake()
    {
        state = MobGenerator.State.Initialize;
    }

    public State state;             //local variable holds current state
	IEnumerator Start () {
	    while(true)
        {
            switch(state)
            {
                case State.Initialize:
                    Initialize();
                    break;
                case State.Setup:
                    Setup();
                    break;
                case State.SpawnMob:
                    SpawnMob();
                    break;
            }

            yield return 0;
        }
	}

    private void Initialize()
    {
        Debug.Log("we are in the initialize function");

        if(!CheckForMobPrefabs())
        {
            return;
        }

        if(!CheckForSpawnPoints())
        {
            return;
        }

        state = MobGenerator.State.Setup;
    }

    private void Setup()
    {
        Debug.Log("we are in the setup function");

        state = MobGenerator.State.SpawnMob;
    }

    private void SpawnMob()
    {
        Debug.Log("we are in the spawnmob function");

        GameObject[] gos = AvailableSpawnPoints();

        for(int cnt = 0; cnt < gos.Length; cnt++)
        {
            GameObject go = Instantiate(mobPrefab[Random.Range(0, mobPrefab.Length)],
            gos[cnt].transform.position,
            Quaternion.identity
            ) as GameObject;
            go.transform.parent = gos[cnt].transform;
        }

        state = MobGenerator.State.Idle;
    }

    //check to see that we have at least one mob prefab to spawn
    private bool CheckForMobPrefabs()
    {
        if (mobPrefab.Length > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    //check to see we have at least one spawn point
    private bool CheckForSpawnPoints()
    {
        if (spawnPoints.Length > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    //generate a list of available spawnpoints that do not have any mobs childed to it
    private GameObject[] AvailableSpawnPoints()
    {
        List<GameObject> gos = new List<GameObject>();

        for(int cnt = 0; cnt < spawnPoints.Length; cnt++)
        {
            if(spawnPoints[cnt].transform.childCount == 0)
            {
                Debug.Log("spawn point available");
                gos.Add(spawnPoints[cnt]);
            }
        }

        return gos.ToArray();
    }

}
