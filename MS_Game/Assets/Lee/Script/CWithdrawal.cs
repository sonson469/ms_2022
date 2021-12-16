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

    private EffectManager m_EffectManager;

    // Start is called before the first frame update
    void Start()
    {
        m_ObjectScript = this.gameObject.GetComponent<CGameObject>();

        m_MainCamera = Camera.main;
        m_RaycastHit = new RaycastHit();

        m_EffectManager = GameObject.FindWithTag("EffectManager").GetComponent<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition); //カメラからレイを飛ばす

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out m_RaycastHit))
                {

                    if (m_RaycastHit.collider.tag == "Tree")
                    {
                        if (m_TargetObject == null)
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                        else if (m_RaycastHit.collider.gameObject == m_TargetObject)     //選択中のオブジェを押したら消す
                        {
                            treescript = m_TargetObject.transform.parent.gameObject.GetComponent<CTree>();
                            treescript.TreeReset();
                            m_ObjectScript.TreeList.Remove(m_TargetObject.transform.parent.gameObject);

                            //--------------------------------------------------
                            //消すエフェクトはこのへん
                            //---------------------------------------------------
                            m_EffectManager.PlayEffect(0, m_TargetObject.transform.position);


                            Destroy(m_TargetObject.transform.parent.gameObject);
                            m_TargetObject = null;
                        }
                        else
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                    }

                    if (m_RaycastHit.collider.tag == "AnimalNest")
                    {
                        if (m_TargetObject == null)
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                        else if (m_RaycastHit.collider.gameObject == m_TargetObject)    //選択中のオブジェを押したら消す
                        {
                            CNestCount countscript = m_TargetObject.transform.parent.gameObject.GetComponent<CNestCount>();
                            GameObject nest = countscript.GetNest();
                            CNest m_NestScript = nest.GetComponent<CNest>();
                            if(m_NestScript.GetClimate() == CNest.Climate.ONTAI)
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

                            m_ObjectScript.AnimalNestList.Remove(m_TargetObject.transform.parent.gameObject);

                            //--------------------------------------------------
                            //消すエフェクトはこのへん
                            //---------------------------------------------------
                            m_EffectManager.PlayEffect(0, m_TargetObject.transform.position);


                            Destroy(m_TargetObject.transform.parent.gameObject);
                            m_TargetObject = null;
                        }
                        else
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                    }

                    if (m_RaycastHit.collider.tag == "Reaper")
                    {
                        if (m_TargetObject == null)
                        {
                            m_TargetObject = m_RaycastHit.collider.gameObject;
                        }
                        else if (m_RaycastHit.collider.gameObject == m_TargetObject)     //選択中のオブジェを押したら消す
                        {
                            Debug.Log("aaaaaaaaaaa");
                            CReaper reaperscript = m_TargetObject.transform.parent.gameObject.GetComponent<CReaper>();
                            reaperscript.ResetList();
                            m_ObjectScript.ReaperList.Remove(m_TargetObject.transform.parent.gameObject);

                            //--------------------------------------------------
                            //消すエフェクトはこのへん
                            //---------------------------------------------------
                            m_EffectManager.PlayEffect(0, m_TargetObject.transform.position);

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
