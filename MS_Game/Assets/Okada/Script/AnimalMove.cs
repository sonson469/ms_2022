using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMove : MonoBehaviour
{
    private Vector3 m_TargetPos;
    private float m_Range;
    private NavMeshAgent m_NavMeshAgent;
    private NavMeshSurface m_NavMeshSurface;
    private GameObject m_TargetNest;
    private bool m_Once;

    private GameObject m_GameManager;
    private CGameTimeManager m_TimeScript;


    void Start()
    { 
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent.autoBraking = false;
        m_NavMeshAgent.speed = 0;
        m_NavMeshSurface = GetComponent<NavMeshSurface>();

        m_GameManager = GameObject.FindWithTag("Manager");
        m_TimeScript = m_GameManager.GetComponent<CGameTimeManager>();
    }

    void Update()
    {
        if (!m_Once)
        {
            m_Once = true;
            GotoNextPoint();
        }
        if (m_NavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            if (!m_NavMeshAgent.pathPending && m_NavMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

        m_NavMeshAgent.speed = (float)m_TimeScript.GetTimeSpeed() * 0.5f;
    }

    void GotoNextPoint()
    {
        //m_NavMeshSurface.BuildNavMesh();

        int xnum = 0;
        int znum = 0;

        while(xnum == 0)
        {
            m_TargetPos.x = Random.Range(-m_Range, m_Range);

            if(m_TargetNest.transform.position.x + m_TargetPos.x < 45.0f && m_TargetNest.transform.position.x + m_TargetPos.x > -45.0f)
            {
                xnum = 1;
            }
        }

        while (znum == 0)
        {
            m_TargetPos.z = Random.Range(-m_Range, m_Range);

            if (m_TargetNest.transform.position.z + m_TargetPos.z < 45.0f && m_TargetNest.transform.position.z + m_TargetPos.z > -45.0f)
            {
                znum = 1;
            }
        }

        m_TargetPos.y = m_TargetNest.transform.position.y;

        //m_TargetPos = new Vector3(Random.Range(-m_Range, m_Range), m_TargetNest.transform.position.y, Random.Range(-m_Range, m_Range));
        Vector3 pos = m_TargetNest.transform.position + m_TargetPos;
        m_NavMeshAgent.SetDestination(pos);
    }


    public void SetTagetNest(GameObject targetNest)
    {
        m_TargetNest = targetNest;
    }


    public void SetRange(float range)
    {
        m_Range = range;
    }
}

 