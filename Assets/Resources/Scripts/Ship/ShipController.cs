using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
    Vector3 acc;
    Vector3 spin;
    Rigidbody rb;
    public float mainBoosterStrength;
    public float auxBoosterStrength;
    public int angularDampenerSetting; //this should be between 0 and 2 always.
    public int velocityDampenerSetting; //this should be between 0 and 2 always.
    int mainBoosterFuelRate = 10;
    int auxBoosterFuelRate = 1;
    public int fuel = 10000;

    // Use this for initialization
    void Start () {
        initialize();
	}
    void initialize()
    {
        acc = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
        Debug.Assert(rb != null);
        angularDampenerSetting = 2; //this should be between 0 and 2 always.
    }

    //yaw pitch and roll range between -1 and 1 and are positive in the right, up, and clockwise directions respectively 
    public void applyControls(float forwardAcc, float yaw, float pitch, float roll, int _angDampenSetting, int _velDamp, float rise) 
    {
        acc = new Vector3(forwardAcc,0, rise);
        spin = new Vector3(roll*auxBoosterStrength, pitch * auxBoosterStrength, yaw * auxBoosterStrength);
        angularDampenerSetting += _angDampenSetting;
        velocityDampenerSetting += _velDamp;
    }
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddRelativeForce(acc);
        if (acc.magnitude > 0) fuel -= mainBoosterFuelRate;
        rb.AddRelativeTorque(spin);
        if (spin.magnitude > 0) fuel -= auxBoosterFuelRate;
        if (angularDampenerSetting > 0 && spin.x == 0 && spin.y == 0 && spin.z == 0)
        {
            angularDampen();
        }else if(angularDampenerSetting < 0)
        {
            angularDampenerSetting = 0;
        }
        if (velocityDampenerSetting > 0 && acc.x == 0 && acc.y == 0 && acc.z == 0)
        {
            velocityDampen();
        }
        else if (velocityDampenerSetting < 0)
        {
            velocityDampenerSetting = 0;
        }
        if(fuel < 0)
        {
            outOfFuel();
        }
    }
    void outOfFuel()
    {
        fuel = 10000;
    }
    void velocityDampen()
    {
        Vector3 vel = rb.velocity;
        float comparison;
        if (velocityDampenerSetting == 1)
        {
            comparison = auxBoosterStrength;
        }
        else // anything other than 0 or 1, set to hard dampening. It should only be 0, 1, or 2.
        {
            comparison = auxBoosterStrength * 2;
            if (velocityDampenerSetting > 2)
            {
                velocityDampenerSetting = 2;
            }
        }
        Vector3 toAdd = new Vector3(dampenHelper(vel.x, comparison), dampenHelper(vel.y, comparison), dampenHelper(vel.z, comparison));
        rb.AddForce(toAdd);
    }
    void angularDampen()
    {
        //dampen rotation
        Vector3 angVel = rb.angularVelocity;
        //Debug.Log(angVel);
        float xcomp = angVel.x;
        float ycomp = angVel.y;
        float zcomp = angVel.z;
        float comparison;
        if (angularDampenerSetting == 1)
        {
            comparison = auxBoosterStrength;
        }else // anything other than 0 or 1, set to hard dampening. It should only be 0, 1, or 2.
        {
            comparison = auxBoosterStrength * 2;
            if (angularDampenerSetting > 2)
            {
                angularDampenerSetting = 2;
            }
        }
        Vector3 toAdd = new Vector3(dampenHelper(xcomp,comparison), dampenHelper(ycomp, comparison), dampenHelper(zcomp, comparison));
        Debug.Log("ToAdd = " + toAdd);
        rb.AddTorque(toAdd);
    }
    float dampenHelper(float one, float two)
    {
        float ret;
        if (Mathf.Abs(one) > Mathf.Abs(two))
        {
            ret = (one < 0 ? two : -two);
            fuel -= auxBoosterFuelRate;
        }
        else
        {
            ret = -one;
        }
        return ret * auxBoosterStrength;
    }
}
