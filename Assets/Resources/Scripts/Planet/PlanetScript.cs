using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {
    float rotateSpeed;
    Vector3 rotateAxis;
    GravityScript grav;
	// Use this for initialization
	void Start () {
        rotateSpeed = Mathf.PI / 132.0f;
        rotateAxis = new Vector3(1, 0, 0);
        grav = new GravityScript(transform.position);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log("Here");
        grav.updateGrav();

        transform.Rotate(rotateAxis,rotateSpeed);
	}
    public void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.gameObject.GetComponentInParent<Rigidbody>();
        if (otherRB != null)
        {
            if (otherRB.gameObject.tag == "Player")
            {
                grav.checkPlayer(otherRB.gameObject);
            }
        }
    }
}
