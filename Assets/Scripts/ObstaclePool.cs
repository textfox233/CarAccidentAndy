using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _carPool;
    [SerializeField] private GameObject _carPrefab;
    [SerializeField] private int _numCars;

    public static ObstaclePool sharedInstance;

    private void Awake() { sharedInstance = this; }

    private void Start()
    {
        Debug.Log("ObstaclePool.Start()");

        // --- Cars --- //
        _carPool = new List<GameObject>();
        GameObject tmpGO;

        // make cars using prefabs
        for (int i = 0; i < _numCars; i++)
        {
            tmpGO = Instantiate(_carPrefab);    // make a car
            tmpGO.name = "Car (" + i + ")";     // give it a name
            _carPool.Add(tmpGO);                // add it to the list
            tmpGO.SetActive(false);             // set to inactive
        }
    }

    public GameObject GetCar(bool active = false)
    // return an object from the pool (boolean specifies active or inactive objects)
    {
        // first inactive object in the pool
        if (!active)
        {
            for (int i = 0; i < _numCars; i++)
            {
                if (!_carPool[i].activeInHierarchy)
                {
                    return _carPool[i];
                }
            }

            // null if there's no inactive objects in the pool
            Debug.Log("CarPool ERROR: no inactive objects in the pool");
            return null;
        }
        // last active object in the pool
        else
        {
            for (int i = _numCars - 1; i >= 0; i--)
            {
                if (_carPool[i].activeInHierarchy)
                {
                    return _carPool[i];
                }
            }

            // null if there's no active objects in the pool
            Debug.Log("CarPool ERROR: no active objects in the pool");
            return null;
        }
    }

    public GameObject GetCar(int index)
    // return an object from the pool by index
    {
        if (index >= _numCars || index < 0)
        {
            Debug.Log("CarPool.GetCar() ERROR: " + index + " is out of bounds");
            return null;
        }

        return _carPool[index];
    }

    public int GetNumOfCars() { return _numCars; }
}
