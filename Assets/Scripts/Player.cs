using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startingLane;

    //[SerializeField] private int startingLane = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Starting Lane = " + _startingLane);

        // align with starting lane
        LanePositioning.sharedInstance.LaneAlign(transform, _startingLane);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        // Quit Game
        {
            Debug.Log("Quit Game (Ignored in Editor)");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.A))
        // Switch Lane : Left
        {
            Debug.Log("Switch Lane : Left");
            LanePositioning.sharedInstance.MoveRider(gameObject, true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        // Switch Lane : Right
        {
            Debug.Log("Switch Lane : Right");
            LanePositioning.sharedInstance.MoveRider(gameObject, false);
        }
    }
}
