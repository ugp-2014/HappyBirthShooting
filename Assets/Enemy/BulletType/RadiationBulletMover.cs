using UnityEngine;
using System.Collections;

public class RadiationBulletMover : MonoBehaviour {

    Vector2 velocity = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity ;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(velocity * Time.deltaTime);
	}
}
