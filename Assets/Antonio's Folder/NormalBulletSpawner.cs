using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletSpawner : MonoBehaviour {

    public GameObject normalBullet;
    public float normalInterval = 0.2f;
    public int pooledAmount = 50;

    List<GameObject> normalBullets;
    // Use this for initialization
    void Start () {
        normalBullet = Resources.Load("Sprites/Bullets/NormalBullet") as GameObject;
        normalBullets = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(normalBullet);
            obj.SetActive(false);
            normalBullets.Add(obj);
        }
        InvokeRepeating("NormalFire", normalInterval, normalInterval);
    }

    void NormalFire()
    {
        for(int i = 0; i < normalBullets.Count; i++)
        {
            if (!normalBullets[i].activeInHierarchy)
            {
                normalBullets[i].transform.position = transform.position;
                normalBullets[i].transform.rotation = transform.rotation;
                normalBullets[i].SetActive(true);
                break;
            }
        }
    }

}
