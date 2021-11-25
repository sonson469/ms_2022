using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMachine : MonoBehaviour
{

    [SerializeField] private GameObject m_MyGround;

    private CGameTimeManager m_TimeManager;
    private GameObject m_Manager;

    private int m_Day;  //íuÇ¢ÇƒÇ©ÇÁÇÃåoâﬂì˙êî

    private bool m_CanPut = true;

    private bool m_Put = false;

    private bool m_Trigger = false;

    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();

        m_MyGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Put)
        {

            if (m_Day >= 1)
            {
                if (!m_MyGround.activeSelf)
                    m_MyGround.SetActive(true);
            }
            else
            {
                if (m_TimeManager.GetDayEnd())
                {
                    m_Day++;
                }
            }
        }

        if(m_Trigger)
        {
            m_CanPut = false;
        }
        else if(!m_Trigger)
        {
            m_CanPut = true;
        }
    }

    private void FixedUpdate()
    {
        m_Trigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            m_Trigger = true;
        }
    }

    public bool GetCanPut()
    {
        return m_CanPut;
    }

    public void SetPut()
    {
        m_Put = true;
    }
}
