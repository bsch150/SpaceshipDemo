using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
    Vector3 acc;
    Vector3 spin;
    Rigidbody rb;
    public float mainBoosterStrength;
    public float auxBoosterStrength;

    // Use this for initialization
    void Start () {
        initialize();
	}
    void initialize()
    {
        acc = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
        Debug.Assert(rb != null);
    }
	public void applyControls(float forwardAcc, float rightAcc, float pitch)
    {
        acc = new Vector3(-forwardAcc,0, 0);
        spin = new Vector3(0, rightAcc, pitch);
    }
	// Update is called once per frame
	void Update () {
        rb.AddRelativeForce(acc);
        rb.AddRelativeTorque(spin);
	}
}
