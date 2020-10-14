using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    public float time;
    private float maxTime;
    public delegate void PlayerDiedDel();
    public event PlayerDiedDel PlayerDied;
    public bool counting = false;

    private void Start()
    {
        maxTime = time;
    }

    public void RefillOxygen(float amount)
    {
        time = Mathf.Min(time+amount,maxTime);
    }

    public void RefillOxygen()
    {
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!counting) return;
        Debug.Log(time);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Debug.Log("GAME OVER");
            PlayerDied?.Invoke();
        }
    }
}
