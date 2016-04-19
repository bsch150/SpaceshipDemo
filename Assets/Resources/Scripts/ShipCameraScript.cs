using UnityEngine;
using System.Collections;

public class ShipCameraScript : MonoBehaviour {
    GameObject myShip;
    Vector3 goalLoc;
    float maxSpeed = 1;
	// Use this for initialization
	void Start () {
        initialize();
	}
    void initialize()
    {
        //myShip = GetComponentInParent<Rigidbody>().gameObject;
    }

    // Update is called once per frame
    void Update () {
        updateGoalLoc();

	
	}
    void updateGoalLoc()
    {
        //goalLoc
    }
}
