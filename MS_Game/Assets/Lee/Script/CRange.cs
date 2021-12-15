using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRange : MonoBehaviour
{
    private GameObject m_RangeObject;

    private GameObject m_Manager;
    private CGameObject m_ObjectScript;
    private bool m_MyRangeFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_ObjectScript = m_Manager.GetComponent<CGameObject>();

        m_RangeObject = transform.Find("Range").gameObject;
        m_RangeObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
     
        if(m_MyRangeFlag || m_ObjectScript.GetRangeFlag())
        {
            m_RangeObject.SetActive(true);
        }
        else
        {
            m_RangeObject.SetActive(false);
        }

    }

    public void SetMyRange(bool flag)
    {
        m_MyRangeFlag = flag;
    }
}
