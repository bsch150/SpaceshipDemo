using UnityEngine;
using System.Collections;

public class AtmosphereScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.gameObject.GetComponentInParent<Rigidbody>();
        if (otherRB != null)
        {
            if (otherRB.gameObject.tag == "Player")
            {
                otherRB.BroadcastMessage("enterAtmosphere", transform);
            }
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
