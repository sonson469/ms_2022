using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectMove : MonoBehaviour
{
    private bool m_ObjectMove = false;

    [SerializeField] private GameObject m_Plane;

    private Vector3 m_TargetPosition;

    public GameObject m_TargetObject;

    private CButtonClick m_ButtonScript;

    // Start is called before the first frame update
    void Start()
    {
        m_ButtonScript = this.gameObject.GetComponent<CButtonClick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ObjectMove)
        {
            m_TargetObject.transform.position = new Vector3(m_Plane.transform.position.x, m_TargetObject.transform.position.y, m_Plane.transform.position.z);
        }
    }

    public void SetObjectMove(bool flag)
    {
        m_ObjectMove = flag;
    }

    public void SetPlane()
    {
        m_TargetPosition = m_ButtonScript.GetObjectPosition();
        m_Plane.SetActive(true);
        m_Plane.transform.position = new Vector3(m_TargetPosition.x, 0.52f, m_TargetPosition.z);
    }

    public void SetTargetObject(GameObject obj)
    {
        m_TargetObject = obj;
    }
}
