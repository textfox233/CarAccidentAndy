//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        // Debugging : Manually Spawn an Obstacle
        {
            Debug.Log("Debugging : Manually Spawn an Obstacle");
            SpawnSingle();
        }
    }

    public void SpawnSingle()
    // Spawn a single Obstacle
    {
        // get an inactive car
        GameObject carGO = ObstaclePool.sharedInstance.GetCar();

        // if null there are no more inactive cars
        if (carGO == null ) { return; }

        // place at the end of the lane
        carGO.transform.position = Vector3.forward * LanePositioning.sharedInstance.getLength();
        // set rotatation to face player
        carGO.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        
        // randomise lane
        int startingLane = Random.Range(0, LanePool.sharedInstance.GetNumOfLanes() - 1);
        // align with above determined lane
        LanePositioning.sharedInstance.LaneAlign(carGO.transform, startingLane);

        // activate object
        carGO.SetActive(true);
    }
}
