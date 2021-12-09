using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWithdrawal : MonoBehaviour
{
    private Camera m_MainCamera;

    RaycastHit m_RaycastHit;

    [SerializeField] private GameObject m_TargetObject;

    private CGameObject m_ObjectScript;

    [SerializeField] private GameObject m_Cube;
    [SerializeField] private CTree treescript;

    // Start is called before the first frame update
    void Start()
    {
        m_ObjectScript = this.gameObject.GetComponent<CGameObject>();

        m_MainCamera = Camera.main;
        m_RaycastHit = new RaycastHit();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition); //ÉJÉÅÉâÇ©ÇÁÉåÉCÇîÚÇŒÇ∑

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out m_RaycastHit))
                {
                    /*if (m_RaycastHit.collider.tag == "Machine")
                    {
                        Destroy(m_RaycastHit.collider.gameObject);
                    }*/

                    if (m_RaycastHit.collider.tag == "Tree")
                    {
                        if (m_TargetObject == null)
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                        else if (m_RaycastHit.collider.gameObject == m_TargetObject)
                        {
                            treescript = m_TargetObject.transform.parent.gameObject.GetComponent<CTree>();
                            treescript.TreeReset();
                            m_ObjectScript.TreeList.Remove(m_TargetObject);
                            Destroy(m_TargetObject.transform.parent.gameObject);
                            m_TargetObject = null;
                        }
                        else
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                    }

                }
            }

            if (m_TargetObject != null)
            {
                m_Cube.SetActive(true);
                m_Cube.transform.position = m_TargetObject.transform.position;
            }
            else
            {
                m_Cube.SetActive(false);
            }
        }
        else
        {
            m_Cube.SetActive(false);
        }
    }
}
