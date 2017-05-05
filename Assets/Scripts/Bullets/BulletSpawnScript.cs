using UnityEngine;

public class BulletSpawnScript : MonoBehaviour {

    public GameObject NormalBullet, SprayBullet, CircleBullet;

    private GameManager manager;
    public float normalFrequence = 0.5f;
    private float normalShooTime = 0f;

    public float sprayFrequence = 5f;
    private float sprayShooTime = 0f;
    public float spraycounter = 50;
    private bool playerInRange = false;

    // Use this for initialization
    void Start ()
    {
        manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerInRange)
        {
            normalPattern();
            sprayPattern(); 
        }
	}

    private void normalPattern()
    {
        if ((normalShooTime += Time.deltaTime) >= normalFrequence)
        {
            Instantiate(NormalBullet, transform.position, Quaternion.identity);
            normalShooTime = 0f;
        }
    }

    private void sprayPattern()
    {
		if((sprayShooTime += Time.deltaTime) >= Random.Range(2f,sprayFrequence))
        {
            for(int i = 0; i < spraycounter; i++)
            {
                Instantiate(SprayBullet, new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1.25f, -0.25f), transform.position.z), Quaternion.identity);
                //Destroy(SprayBullet, 10f);
            }
            sprayShooTime = 0;
        }
    }

    private void circlePattern()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
}
