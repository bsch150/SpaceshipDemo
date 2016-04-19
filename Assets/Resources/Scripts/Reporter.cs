using UnityEngine;
using System.Collections;

public class Reporter : MonoBehaviour {
    bool debugMode = true;
	// Use this for initialization
	void Start () {
	
	}
	
    void print(string str)
    {
        if (debugMode)
        {
            Debug.Log(str);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
