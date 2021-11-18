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

    void Start()
    { 
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent.autoBraking = false;
        m_NavMeshSurface = GetComponent<NavMeshSurface>();
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
    }

    void GotoNextPoint()
    {
        //m_NavMeshSurface.BuildNavMesh();
        m_TargetPos = new Vector3(Random.Range(-m_Range, m_Range), m_TargetNest.transform.position.y, Random.Range(-m_Range, m_Range));
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

 