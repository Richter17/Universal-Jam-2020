using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipAnimation : MonoBehaviour
{
    private Transform m_groundCheck;
    private bool m_isLanded = false;
    private bool m_isLanding = false;
    private bool m_isTakingOff = false;

    private bool m_takeOff;
    private float landSmooth = 1;
    private Animator m_anim;
    private Vector3 m_startPos;

    private readonly int TAKE_OFF = Animator.StringToHash("TakingOff");

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeOff();
        }
    }

    public void TakeOff()
    {
        m_anim.SetTrigger(TAKE_OFF);
    }
}
