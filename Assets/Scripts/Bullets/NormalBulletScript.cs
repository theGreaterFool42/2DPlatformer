using UnityEngine;

public class NormalBulletScript : BulletInterface {

    private GameManager manager;
    private Vector3 shotDirection;
    public float speed = 10;
    
	// Use this for initialization
	void Start ()
    {

        manager = FindObjectOfType<GameManager>();
        shotDirection = manager.getPlayerPos() - transform.position;
        Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += shotDirection.normalized * Time.deltaTime * speed;
	}
}
