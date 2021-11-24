using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTree : MonoBehaviour
{

    public enum State
    {
        PUT,    //置こうとしてるとき
        SAPLING, //苗木
        COMPLETE,  //成木(完成されてる状態)
        WITHER   //枯れ
    }

    public enum Zone
    {
        NONE,
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI
    }

    private int m_Day;   //苗木からの経過日数

    private State m_State = State.PUT;

    private CGameTimeManager m_TimeManager;
    private GameObject m_Manager;

    [Header("適応地域")]
    [SerializeField] private Zone m_MyZone;   //適応地域
    private Zone m_NowZone = Zone.NONE;   //今いる地域

    [Header("苗木")]
    [SerializeField] private GameObject SaplingObject;
    [Header("成木")]
    [SerializeField] private GameObject CompleteObject;
    [Header("老木")]
    [SerializeField] private GameObject WitherObject;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();

        CompleteObject.SetActive(true);
        SaplingObject.SetActive(false);
        WitherObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_State == State.PUT)
        {

        }
        else if (m_State == State.SAPLING)
        {
            if (CompleteObject.activeSelf)
                CompleteObject.SetActive(false);

            if (!SaplingObject.activeSelf)
                SaplingObject.SetActive(true);

            if (m_TimeManager.GetDayEnd())
            {
                m_Day++;
                m_TimeManager.AddTreeCount();
            }

            if(m_Day >= 2)
            {
                if(m_MyZone == m_NowZone)
                {
                    m_State = State.COMPLETE;
                }
                else
                {
                    m_State = State.WITHER;
                }
            }


        }
        else if (m_State == State.COMPLETE)
        {
            if (!CompleteObject.activeSelf)
                CompleteObject.SetActive(true);

            if (SaplingObject.activeSelf)
                SaplingObject.SetActive(false);
        }
        else if (m_State == State.WITHER)
        {
            if (!WitherObject.activeSelf)
                WitherObject.SetActive(true);

            if (SaplingObject.activeSelf)
                SaplingObject.SetActive(false);

        }
    }

    public void SetSapling()
    {
        m_State = State.SAPLING;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ONTAI")
        {
            m_NowZone = Zone.ONTAI;
        }
        else if (other.gameObject.tag == "NETTAI")
        {
            m_NowZone = Zone.NETTAI;
        }
        else if (other.gameObject.tag == "KANSOUTAI")
        {
            m_NowZone = Zone.KANSOUTAI;
        }
        else if (other.gameObject.tag == "KANTAI")
        {
            m_NowZone = Zone.KANTAI;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Machine")
        {
            m_NowZone = Zone.NONE;
        }
    }
}
