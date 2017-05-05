using UnityEngine;

public class SprayBulletScript : BulletInterface {
    private GameManager manager;
    private Vector3 shotDirection;
    public float speed = 3f;
	public float sprayer = 3f;
    public float starttimer;
    private float endtimer = 0;
    private bool move;
    void Start()
    {
        if ((endtimer += Time.deltaTime) >= starttimer)
        {
            
            endtimer = 0;
        }
        manager = FindObjectOfType<GameManager>();
		shotDirection = manager.getPlayerPos()- new Vector3(transform.position.x + Random.Range(-sprayer, sprayer), transform.position.y, transform.position.z);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((endtimer += Time.deltaTime)>= starttimer)
        {
            transform.position += shotDirection.normalized * Time.deltaTime * speed;
        }
        
    }
}
