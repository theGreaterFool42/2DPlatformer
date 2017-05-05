using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Vector2 direction;
    Vector2 mousePosition;
    // Use this for initialization


    void Start()
    {
        direction.x = Random.Range(0, 100);
        direction.y = Random.Range(0, 100);
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(mousePosition.x, mousePosition.y, 0) * Time.deltaTime;
    }
}
