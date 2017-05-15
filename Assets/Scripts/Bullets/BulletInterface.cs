using UnityEngine;

public class BulletInterface : MonoBehaviour {

    protected float velocity;
    public void setInitalVelocity(float vel)
    {
        velocity = vel;
    }

    void OnEnable()
    {
        Invoke("Destroy", 7f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
