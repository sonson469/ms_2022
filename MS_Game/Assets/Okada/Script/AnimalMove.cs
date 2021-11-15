using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMove : MonoBehaviour
{
    private Vector3 m_TargetPos;
    [SerializeField] private float m_Min, m_Max;
    private NavMeshAgent m_NavMeshAgent;
    private NavMeshSurface m_NavMeshSurface;
    private GameObject m_TargetNest;
    void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent.autoBraking = false;
        m_NavMeshSurface = GetComponent<NavMeshSurface>();
        GotoNextPoint();
    }

    void Update()
    {
        if (!m_NavMeshAgent.pathPending && m_NavMeshAgent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        m_TargetPos.x = Random.Range(-m_Max, m_Max);
        m_TargetPos.z = Random.Range(-m_Max, m_Max);
        //m_NavMeshSurface.BuildNavMesh();
        m_TargetPos.y = m_TargetNest.transform.position.y;
        m_NavMeshAgent.SetDestination(m_TargetNest.transform.position + m_TargetPos);
    }


    public void SetTagetNest(GameObject targetNest)
    {
        m_TargetNest = targetNest;
    }


    public void SetRange(float range)
    {
        m_Max = range;
    }
}

 