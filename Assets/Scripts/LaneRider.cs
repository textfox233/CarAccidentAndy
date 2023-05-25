using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneRider : MonoBehaviour
{
    [SerializeField] private int _laneIndex;
    [SerializeField] private bool _isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (!_isPlayer)
        // enemies spawn further away, facing player
        {

            transform.rotation = Quaternion.AngleAxis(180.0f, Vector3.up);
        }
    }

    public void setPosition(int position) { _laneIndex = position; }
    public int getPosition() { return _laneIndex; }
}
