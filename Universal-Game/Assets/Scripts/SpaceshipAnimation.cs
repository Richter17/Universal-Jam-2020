using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipAnimation : MonoBehaviour
{
    private Animator m_anim;

    private readonly int TAKE_OFF = Animator.StringToHash("TakingOff");
    private bool m_isDestroyed = false;
    private GameObject m_destroyedSS;
    private GameObject m_regularSS;
    // Start is called before the first frame update
    void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_regularSS = transform.GetChild(0).gameObject;
        m_destroyedSS = transform.GetChild(1).gameObject;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        TakeOff();
    //    }
    //}

    public void TakeOff()
    {
        m_anim.SetTrigger(TAKE_OFF);
    }

    public void Blow()
    {
        ToggleDestroyState(true);
    }

    public void ToggleDestroyState(bool val)
    {
        if (m_isDestroyed == val) return;
        m_isDestroyed = val;
        m_destroyedSS.SetActive(val);
        m_regularSS.SetActive(!val);

    }
}
