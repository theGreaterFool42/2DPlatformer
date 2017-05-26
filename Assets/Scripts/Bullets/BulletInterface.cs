using UnityEngine;

public class BulletInterface : MonoBehaviour {

    protected float velocity;
    public void setInitalVelocity(float vel)
    {
        velocity = vel;
    }

    void OnEnable()
    {
        Invoke("Destroy", 10f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerTriggerThing")
        {
            //Debug.Log("Hit: " + collision);
            FunnyScript.HowOftenDidsomethingHitMe = "AmIDed?";
            gameObject.SetActive(false);
            Debug.Log(FunnyScript.HowOftenDidsomethingHitMe);
        }
    }
}
