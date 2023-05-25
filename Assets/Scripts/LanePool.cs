using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LanePool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lanePool;
    [SerializeField] private GameObject _lanePrefab;
    [SerializeField] private int _numLanes;

    public static LanePool sharedInstance;

    private void Awake() { sharedInstance = this; }

    private void Start()
    {
        Debug.Log("LanePool.Start()");

        // --- Lanes --- //
        _lanePool = new List<GameObject>();
        GameObject tmpGO;

        // make lanes using prefabs
        for (int i = 0; i < _numLanes; i++)
        {
            tmpGO = Instantiate(_lanePrefab);   // make a lane
            tmpGO.name = "Lane (" + i + ")";    // give it a name
            _lanePool.Add(tmpGO);               // add it to the list
        }
    }

    public GameObject GetLane(bool active = false)
    // return an object from the pool (boolean specifies active or inactive objects)
    {
        // first inactive object in the pool
        if (!active)
        {
            for (int i = 0; i < _numLanes; i++)
            {
                if (!_lanePool[i].activeInHierarchy)
                {
                    return _lanePool[i];
                }
            }

            // null if there's no inactive objects in the pool
            Debug.Log("LanePool ERROR: no inactive objects in the pool");
            return null;
        }
        // last active object in the pool
        else
        {
            for (int i = _numLanes - 1; i >= 0; i--)
            {
                if (_lanePool[i].activeInHierarchy)
                {
                    return _lanePool[i];
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
        if (index >= _numLanes || index < 0)
        {
            Debug.Log("LanePool.GetCar() ERROR: " + index + " is out of bounds");
            return null;
        }

        return _lanePool[index];
    }

    public int GetNumOfLanes() { return _numLanes; }
}