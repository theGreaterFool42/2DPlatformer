using UnityEngine;

public class CircleBullets : BulletInterface {
	
	// Update is called once per frame
	void Update () {
        this.transform.position += this.transform.rotation * new Vector3(0, velocity, 0);
	}
}
