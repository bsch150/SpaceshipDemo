using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public GameObject shipToControl;
    ShipController toControl;
	// Use this for initialization
	void Start () {
        toControl = shipToControl.GetComponent<ShipController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float one = Input.GetAxis("Forward") * toControl.mainBoosterStrength;
        float two = Input.GetAxis("Right");
        float three = Input.GetAxis("Up");
        toControl.applyControls(one, two, three);
	}
}
