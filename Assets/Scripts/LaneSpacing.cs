using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpacing : MonoBehaviour
{
    [SerializeField] private float spacingDistance;

    public static LaneSpacing sharedInstance;

    private void Awake() { sharedInstance = this; }


    //public int numberOfLanes;

    // Start is called before the first frame update
    void Start()
    {
        // get number of lanes
        int max = LanePool.sharedInstance.GetNumOfLanes();

        for (int i = 0; i < max; i++)
        {
            // Get Each Lane
            GameObject tmpLane = LanePool.sharedInstance.GetLane(i);

            // Position Each Lane
            tmpLane.transform.position += Vector3.right * (spacingDistance * i);
        }
    }

    // Moves an object from one lane to the next (bool true/false = left/right)
    public void MoveObject(bool direction)
    {
        if (direction)
            { Debug.Log("Moving left"); }
        else
            { Debug.Log("Moving right"); }

    }

    // Aligns a gameObject with a specific lane
    public void LaneAlign(Transform targetTR, int targetLane)
    {
        // get the lane pool
        LanePool lanes = LanePool.sharedInstance;
        Transform tmpTR;

        // is the lane number invalid?
        if (targetLane < 0 || targetLane > lanes.GetNumOfLanes())
        {
            // return early with debug
            Debug.Log("Lane number invalid");
            return;
        }
        
        // get the lane's transform
        tmpTR = lanes.GetLane(targetLane).transform;

        // change the object's position to match the lane
        targetTR.position = tmpTR.position;
    }
}
