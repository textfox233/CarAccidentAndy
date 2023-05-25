using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneRider : MonoBehaviour
{
    [SerializeField] private int _laneIndex;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private float _velocity;

    private void Update()
    {
        Debug.Log(gameObject.name + " is Updating");
        if (!_isPlayer)
        // enemies move here
        {
            //Debug.Log(gameObject.name + " is not a Player");
            transform.Translate(Vector3.forward * _velocity * Time.deltaTime);

            //gameObject.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * -_velocity);
            Debug.Log(gameObject.name + " Velocity is " + gameObject.GetComponent<Rigidbody>().velocity);

            // if passing the camera's Z, deactivate
            if (transform.position.z < -10)
            {
                //Debug.Log(gameObject.name + ".transform.position.z = " + transform.position.z + ", DEACTIVATING");
                Debug.Log("DEACTIVATING");
                gameObject.SetActive(false);
            }
        }
    }

    public void setIndex(int position) { _laneIndex = position; }
    public int getIndex() { return _laneIndex; }
}
