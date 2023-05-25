using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class LanePositioning : MonoBehaviour
{
    [SerializeField] private float _spacingDistance = 6;
    [SerializeField] private float _laneLength = 20;

    public static LanePositioning sharedInstance;

    private void Awake() { sharedInstance = this; }

    // Start is called before the first frame update
    void Start()
    {
        // get number of lanes
        int maxLanes = LanePool.sharedInstance.GetNumOfLanes();

        for (int i = 0; i < maxLanes; i++)
        {
            // Get Each Lane
            GameObject tmpLane = LanePool.sharedInstance.GetLane(i);

            // Position Each Lane
            tmpLane.transform.position = Vector3.right * (_spacingDistance * i);
        }

        // grab camera
        Transform cameraTR = GameObject.Find("Main Camera").transform;

        //Debug.Log(cameraTR.name);

        // position camera in the middle
        cameraTR.position += Vector3.right * ((_spacingDistance * (maxLanes - 1)) / 2);
    }

    // Moves an object from one lane to the next (bool true/false = left/right)
    public void MoveRider(GameObject riderGO, bool direction)
    {
        // get riders's lane index
        int laneIndex = riderGO.GetComponent<LaneRider>().getIndex();

        if (direction)
        // moving left
        {
            Debug.Log("Moving left");
            laneIndex--;
        }
        else
        // moving right
        {
            Debug.Log("Moving right");
            laneIndex++;
        }

        // check index is within valid bounds
        if (laneIndex < 0 || laneIndex >= LanePool.sharedInstance.GetNumOfLanes())
        // invalid index - log and return
        {
            Debug.Log("Invalid index; move is impossible");
            return;
        }

        // index is valid, perform move
        LaneAlign(riderGO.transform, laneIndex);
    }

    // Aligns a gameObject with a specific lane
    public void LaneAlign(Transform riderTR, int targetLane)
    {
        // get the lane pool
        LanePool lanes = LanePool.sharedInstance;

        // is the lane number invalid?
        if (targetLane < 0 || targetLane > lanes.GetNumOfLanes())
        {
            // return early with debug
            Debug.Log("Lane number invalid");
            return;
        }

        // change x only
        riderTR.position = new Vector3(_spacingDistance * targetLane, 0.0f, riderTR.position.z);

        // set lane index to match
        riderTR.gameObject.GetComponent<LaneRider>().setIndex(targetLane);
    }

    public float getLength() { return _laneLength; }
}
