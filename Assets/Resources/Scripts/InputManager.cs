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
        float one = Input.GetAxis("Acc") * toControl.mainBoosterStrength;
        float two = Input.GetAxis("Yaw");
        float three = Input.GetAxis("Pitch");
        float four = Input.GetAxis("Roll");
        float changeAngDampBy = Input.GetAxis("AngleDampenerSetting");
        float changeVelDampBy = Input.GetAxis("VelocityDampenerSetting");
        float rise = Input.GetAxis("Rise") * toControl.auxBoosterStrength;
        toControl.applyControls(one, two, three, four,(int)changeAngDampBy,(int)changeVelDampBy,rise);
	}
}
