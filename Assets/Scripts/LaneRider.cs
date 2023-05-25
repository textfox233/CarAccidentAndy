using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneRider : MonoBehaviour
{
    [SerializeField] private int _laneIndex;
    [SerializeField] private bool _isPlayer;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //// spawning in
    //    //if (!_isPlayer)
    //    //// enemies
    //    //{
    //    //    // place further away
    //    //    transform.position += Vector3.forward * LanePositioning.sharedInstance.getLength();
    //    //    // rotate to face player
    //    //    transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
    //    //    // randomise starting lane
    //    //    _startingLane = Random.Range(0, LanePool.sharedInstance.GetNumOfLanes() - 1);
    //    //}
    //    //else
    //    //// players
    //    //{
    //    //    Debug.Log("Player Starting Lane = " + _startingLane);

    //    //    //// align with starting lane
    //    //    //LanePositioning.sharedInstance.LaneAlign(transform, _startingLane);
    //    //}
    //    //Debug.Log(gameObject.name + " _startingLane = " + _startingLane);
    //    //// align with starting lane
    //    //LanePositioning.sharedInstance.LaneAlign(transform, _startingLane);

    //    // spawning in
    //    if (_isPlayer)
    //    // enemies
    //    {
    //        Debug.Log("Player Starting Lane = " + _startingLane);

    //        // align with starting lane
    //        LanePositioning.sharedInstance.LaneAlign(transform, _startingLane);
    //    }
    //}

    private void Update()
    {
        if (!_isPlayer)
        // enemies move here
        {

        }
    }

    public void setIndex(int position) { _laneIndex = position; }
    public int getIndex() { return _laneIndex; }
}
