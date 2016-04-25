using UnityEngine;
using System.Collections;

public class ParticleSystemController : MonoBehaviour {
    ShipController ship;
    public ParticleSystem MainThrust;
    public ParticleSystem[] posPitchGroup;
    public ParticleSystem[] negPitchGroup;
    public ParticleSystem[] posYawGroup;
    public ParticleSystem[] negYawGroup;
    public ParticleSystem[] posRollGroup;
    public ParticleSystem[] negRollGroup;
    // Use this for initialization
    void Start () {
        ship = GetComponentInParent<ShipController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MainThrust.gameObject.SetActive(ship.acc.x > 0);

        setGroup(posPitchGroup, ship.spin.y > 0);
        setGroup(negPitchGroup, ship.spin.y < 0);

        setGroup(posYawGroup, ship.spin.z > 0);
        setGroup(negYawGroup, ship.spin.z < 0);

        setGroup(posRollGroup, ship.spin.x > 0);
        setGroup(negRollGroup, ship.spin.x < 0);
    }
    void setGroup(ParticleSystem[] ps, bool whatTo)
    {
        foreach(ParticleSystem p in ps)
        {
            p.gameObject.SetActive(whatTo);
        }
    }
}
