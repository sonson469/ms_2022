using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSelectPoint : MonoBehaviour
{

    private Camera m_MainCamera;
    private GameObject m_SelectPointPlane;//選択マス上のPlane

    public bool m_DragFlag = false;

    RaycastHit m_RaycastHit;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_RaycastHit = new RaycastHit();

        m_SelectPointPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        m_SelectPointPlane.transform.localScale = new Vector3(0.1f, 1.0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition); //カメラからレイを飛ばす

        if (Physics.Raycast(ray, out m_RaycastHit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (Mathf.Abs(m_SelectPointPlane.transform.position.x - m_RaycastHit.point.x) < 0.5f && Mathf.Abs(m_SelectPointPlane.transform.position.z - m_RaycastHit.point.z) < 0.5f)
                {
                    m_DragFlag = true;
                }
            }

            /*if (!m_SelectPointPlane)
            {
                m_SelectPointPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                m_SelectPointPlane.transform.localScale = new Vector3(0.1f, 1.0f, 0.1f);
            }*/

            if(m_DragFlag)
            {
                //1マス超えなかったらreturn
                if (Mathf.Abs(m_SelectPointPlane.transform.position.x - m_RaycastHit.point.x) < 0.5f && Mathf.Abs(m_SelectPointPlane.transform.position.z - m_RaycastHit.point.z) < 0.5f)
                {
                    return;
                }

                //planeの座標をレイがあってるとこにする(微妙な少数になったりしたから整数にする)
                m_SelectPointPlane.transform.position = new Vector3(Mathf.RoundToInt(m_RaycastHit.point.x), m_RaycastHit.point.y, Mathf.RoundToInt(m_RaycastHit.point.z));
                m_SelectPointPlane.transform.position += new Vector3(0, 0.01f, 0);
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_DragFlag = false;
        }

    }
}
