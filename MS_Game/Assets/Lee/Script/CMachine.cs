using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMachine : MonoBehaviour
{

    [SerializeField] private GameObject m_MyGround;

    private CGameTimeManager m_TimeManager;
    private GameObject m_Manager;

    private int m_Day;  //íuÇ¢ÇƒÇ©ÇÁÇÃåoâﬂì˙êî

    private bool m_CanPut = false;

    private bool m_Put = false;

    private bool m_Trigger = false;

    private Vector3[] m_Position = new Vector3[9];
    private bool[] m_CanPutPosition = new bool[9];

    void Start()
    {

        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();

        m_MyGround.SetActive(false);

        m_Position[0] = new Vector3(-30.0f, 0.0f, 30.0f);
        m_Position[1] = new Vector3(-30.0f, 0.0f, 0.0f);
        m_Position[2] = new Vector3(-30.0f, 0.0f, -30.0f);
        m_Position[3] = new Vector3(0.0f, 0.0f, -30.0f);
        m_Position[4] = new Vector3(0.0f, 0.0f, 0.0f);
        m_Position[5] = new Vector3(0.0f, 0.0f, 30.0f);
        m_Position[6] = new Vector3(30.0f, 0.0f, 30.0f);
        m_Position[7] = new Vector3(30.0f, 0.0f, 0.0f);
        m_Position[8] = new Vector3(30.0f, 0.0f, -30.0f);

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

        /*if(m_Trigger)
        {
            m_CanPut = false;
        }
        else if(!m_Trigger)
        {
            m_CanPut = true;
        }*/

        if (transform.position == m_Position[0] || transform.position == m_Position[1] || transform.position == m_Position[2] || transform.position == m_Position[3] || transform.position == m_Position[4] || transform.position == m_Position[5] || transform.position == m_Position[6] || transform.position == m_Position[7] || transform.position == m_Position[8])
        {
            m_CanPut = true;
        }
        else
        {
            m_CanPut = false;
        }

    }

    private void FixedUpdate()
    {
        //m_Trigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.tag == "Machine")
        {
            m_Trigger = true;
        }*/
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
