using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInformation : MonoBehaviour
{
    private Camera m_MainCamera;

    RaycastHit m_RaycastHit;

    [SerializeField] private GameObject m_TargetObject;

    private CGameObject m_ObjectScript;

    [SerializeField] private GameObject m_Cube;
    [SerializeField] private CTree treescript;

    private enum Obj
    {
        TREE,
        NEST,
        NONE
    }

    private Obj m_Objnum = Obj.NONE;

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
        if (m_ObjectScript.GetMode() == CGameObject.ModeState.INFOR)
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition); //カメラからレイを飛ばす

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out m_RaycastHit))
                {

                    if (m_RaycastHit.collider.tag == "Tree")
                    {
                        if(m_Objnum == Obj.TREE && m_TargetObject != null)
                        {
                            treescript.SetInformation(false);
                        }
                        m_TargetObject = m_RaycastHit.collider.gameObject;
                        m_Objnum = Obj.TREE;

                        treescript = m_TargetObject.transform.parent.gameObject.GetComponent<CTree>();
                        treescript.SetInformation(true);
                       
                    }

                    if (m_RaycastHit.collider.tag == "AnimalNest")
                    {
                        /*if (m_TargetObject == null)
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                        else if (m_RaycastHit.collider.gameObject == m_TargetObject)    //選択中のオブジェを押したら消す
                        {
                            CNestCount countscript = m_TargetObject.transform.parent.gameObject.GetComponent<CNestCount>();
                            GameObject nest = countscript.GetNest();
                            CNest m_NestScript = nest.GetComponent<CNest>();
                            if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
                            {
                                COntai ontaiscript = m_TargetObject.transform.parent.gameObject.GetComponent<COntai>();
                                ontaiscript.DesAnimal();
                            }
                            else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
                            {
                                CNettai nettaiscript = m_TargetObject.transform.parent.gameObject.GetComponent<CNettai>();
                                nettaiscript.DesAnimal();
                            }
                            else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
                            {
                                CKansoutai kansoutaiscript = m_TargetObject.transform.parent.gameObject.GetComponent<CKansoutai>();
                                kansoutaiscript.DesAnimal();
                            }
                            else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
                            {
                                CKantai kantaiscript = m_TargetObject.transform.parent.gameObject.GetComponent<CKantai>();
                                kantaiscript.DesAnimal();
                            }

                            countscript.ResetList();

                            m_ObjectScript.NestNameCountMinus(m_NestScript.GetNestNumAll());
                            m_ObjectScript.AnimalNestList.Remove(m_TargetObject.transform.parent.gameObject);


                            Destroy(m_TargetObject.transform.parent.gameObject);
                            m_TargetObject = null;
                        }
                        else
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }*/
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
            if(m_TargetObject != null)
            {
                if (m_Objnum == Obj.TREE)
                {
                    treescript.SetInformation(false);
                }
            }
            
        }
    }
}
