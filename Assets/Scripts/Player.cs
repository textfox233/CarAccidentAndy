using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int startingLane = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StartingLane = " + startingLane);

        // align with starting lane
        LaneSpacing.sharedInstance.LaneAlign(transform, startingLane);
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
            LaneSpacing.sharedInstance.MoveObject(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        // Switch Lane : Right
        {
            Debug.Log("Switch Lane : Right");
            LaneSpacing.sharedInstance.MoveObject(false);
        }
    }
}
