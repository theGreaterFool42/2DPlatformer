using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    GameObject bullet;
    GameObject bullet_1;
    GameObject bullet_2;
    public float bulletSpeed = 3.0f;
    public float fireRate = 0f;
    private string bulletType;
    private float timeToFire = 0f;

    // Use this for initialization
    void Start()
    {
        bullet_1 = Resources.Load("Sprites/Bullets/Bullet_1") as GameObject;
        bullet_2 = Resources.Load("Sprites/Bullets/Bullet_2") as GameObject;
        bullet = bullet_1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            bulletType = Input.inputString;
            switch (bulletType)
            {
                case "1":
                    bullet = bullet_1;
                    Debug.Log("1");
                    break;
                case "2":
                    bullet = bullet_2;
                    Debug.Log("2");
                    break;
                case "3":
                    bullet = bullet_1;
                    Debug.Log("3");
                    break;
                default:
                    break;
            }
        }


        if ((Input.GetButton("Fire1"))/* && Time.time > timeToFire*/)
        {
            timeToFire = Time.time + 1 / fireRate;
            //Debug.Log("Bullet: " + bullet);
            Shoot();
        Debug.Log("Hey");
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y);
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody2D rb2d = bulletClone.GetComponent<Rigidbody2D>();
        //bulletClone.transform.position = bulletClone.transform.position + new Vector3(mousePosition.x, mousePosition.y, 0) * Time.deltaTime;
        //rb2d.transform.position += new Vector3(mousePosition.x, mousePosition.y, 0) * Time.deltaTime;
        rb2d.velocity = mousePosition * bulletSpeed;
        Destroy(bulletClone, 10.0f);
    }
}
