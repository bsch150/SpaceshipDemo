using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityScript : MonoBehaviour
{
    float G = 100000;
    float myMass = 1000000;
    List<GameObject> objs = new List<GameObject>();
    List<Rigidbody> rbs = new List<Rigidbody>();
    Vector3 location;
    public GravityScript(Vector3 _location)
    {
        location = _location;
    }
    public void checkPlayer(GameObject other)
    {
        if (!objs.Contains(other.gameObject))
        {
            objs.Add(other.gameObject);
            rbs.Add(other.gameObject.GetComponent<Rigidbody>());
            Debug.Log("Added player to set");
        }
    }
	// Update is called once per frame
	public void updateGrav () {
        for(int i = 0; i < rbs.Count; i++)
        {
            float r = (rbs[i].transform.position - location).sqrMagnitude;
            float F = getGravity(rbs[i].mass, myMass, r);
            Vector3 toAdd = ((location - rbs[i].transform.position).normalized * F);
            rbs[i].AddForce(toAdd);
            Debug.Log("Gravitational pull is " + toAdd + ", F = " + F);
        }
	
	}
    float getGravity(float m1, float m2, float r)
    {
        float top = G * m1 * m2;
        float bottom = r * r;
        return top / bottom;
    }
}
