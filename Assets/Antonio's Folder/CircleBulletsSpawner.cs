using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleBulletsSpawner : MonoBehaviour {

    public GameObject circleBullet;
    public float spiralInterval = 0.1f;
    public int pooledAmount = 1000;
    public bool rightleft = false;

    List<GameObject> circleBullets;

    private float nextSpiralInc = 1;
    private float spiralAngle = 0;
	// Use this for initialization
	void Start ()
    {
        circleBullets = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(circleBullet);
            obj.SetActive(false);
            circleBullets.Add(obj);
        }
        InvokeRepeating("CircleFire", spiralInterval, spiralInterval);
	}
    
    void CircleFire ()
    {
        for(int i = 0; i < circleBullets.Count;i++)
        {
            nextSpiralInc -= Time.deltaTime;
            if (nextSpiralInc <=0)
            {
                if (!circleBullets[i].activeInHierarchy)
                {

                    for (int j = 0; j < 12; j++)
                    {
                        Quaternion spiralBase = Quaternion.AngleAxis(spiralAngle, Vector3.forward);
                        Quaternion bulletOff = Quaternion.AngleAxis(j * 30f, Vector3.forward);
                        circleBullets[i + j].transform.position = transform.position;
                        circleBullets[i + j].transform.rotation = bulletOff * spiralBase;
                        circleBullets[i + j].GetComponent<BulletInterface>().setInitalVelocity(0.1f);
                        circleBullets[i + j].SetActive(true);
                        break;
                    }
                    nextSpiralInc = 1;
                    spiralAngle += 9;
                }
            }
        }
    }
}
