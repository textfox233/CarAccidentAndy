using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LanePool : MonoBehaviour
{
    [SerializeField] private List<GameObject> lanePool;
    [SerializeField] private GameObject lanePrefab;
    [SerializeField] private int numLanes;

    public static LanePool sharedInstance;

    private void Awake() { sharedInstance = this; }

    private void Start()
    {
        Debug.Log("ObjectPool.Start()");

        // --- Lanes --- //
        lanePool = new List<GameObject>();
        GameObject tmpGO;

        //GameObject carsGO = gameObject.GetComponent<GameController>().getCars();
        //numLanes = gameObject.transform.childCount;

        // get the lane prefabs via parent
        for (int i = 0; i < numLanes; i++)
        {
            tmpGO = Instantiate(lanePrefab);                    // make a lane
            tmpGO.name = "Lane (" + i + ")";                    // give it a name
            lanePool.Add(tmpGO);                                // add it to the list
        }
    }

    public GameObject GetLane(bool active = false)
    // return an object from the pool (boolean specifies active or inactive objects)
    {
        // first inactive object in the pool
        if (!active)
        {
            for (int i = 0; i < numLanes; i++)
            {
                if (!lanePool[i].activeInHierarchy)
                {
                    return lanePool[i];
                }
            }

            // null if there's no inactive objects in the pool
            Debug.Log("LanePool ERROR: no inactive objects in the pool");
            return null;
        }
        // last active object in the pool
        else
        {
            for (int i = numLanes - 1; i >= 0; i--)
            {
                if (lanePool[i].activeInHierarchy)
                {
                    return lanePool[i];
                }
            }

            // null if there's no active objects in the pool
            Debug.Log("LanePool ERROR: no active objects in the pool");
            return null;
        }
    }

    public GameObject GetLane(int index)
    // return an object from the pool by index
    {
        if (index >= numLanes || index < 0)
        {
            Debug.Log("LanePool.GetCar() ERROR: " + index + " is out of bounds");
            return null;
        }

        return lanePool[index];
    }

    public int GetNumOfLanes() { return numLanes; }
}