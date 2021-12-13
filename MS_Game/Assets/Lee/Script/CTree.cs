using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTree : MonoBehaviour
{

    public enum Size
    {
        BIG,
        SMALL,
        NONE
    }

    public enum State
    {
        PUT,    //�u�����Ƃ��Ă�Ƃ�
        SAPLING, //�c��
        COMPLETE,  //����(��������Ă���)
        WITHER,   //�͂�
        DES       //������
    }

    public enum Zone
    {
        NONE,
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI
    }

    private Size m_Size;

    private int m_Day;   //�c�؂���̌o�ߓ���

    [SerializeField] private int m_ReaperNumMax;    //Max�����萔
    private int m_ReaperNum;   //�����萔

    private bool m_Reaper = false;

    private int m_Cost;

    private State m_State = State.PUT;

    private CGameTimeManager m_TimeManager;
    private CGameObject m_ObjectScript;
    private GameObject m_Manager;

    private COntaiTree m_Ontai;
    private CNettaiTree m_Nettai;
    private CKansoutaiTree m_Kansoutai;
    private CKantaiTree m_Kantai;

    private GameObject m_DesObj;

    [Header("�K���n��")]
    [SerializeField] private Zone m_MyZone;   //�K���n��
    private Zone m_NowZone = Zone.NONE;   //������n��

    [Header("�c��")]
    [SerializeField] private GameObject SaplingObject;
    [Header("����")]
    [SerializeField] private GameObject CompleteObject;
    [Header("�V��")]
    [SerializeField] private GameObject WitherObject;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_ObjectScript = m_Manager.GetComponent<CGameObject>();

        m_DesObj = this.gameObject.transform.GetChild(3).gameObject;

        CompleteObject.SetActive(true);
        SaplingObject.SetActive(false);
        WitherObject.SetActive(false);

        if(m_MyZone == Zone.ONTAI)
        {
            m_Ontai = this.gameObject.GetComponent<COntaiTree>();
        }
        else if(m_MyZone == Zone.NETTAI)
        {
            m_Nettai = this.gameObject.GetComponent<CNettaiTree>();
        }
        else if(m_MyZone == Zone.KANSOUTAI)
        {
            m_Kansoutai = this.gameObject.GetComponent<CKansoutaiTree>();
        }
        else if(m_MyZone == Zone.KANTAI)
        {
            m_Kantai = this.gameObject.GetComponent<CKantaiTree>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //�P�����[�h���͑I��p�̉~�����łĂ���
        if(m_ObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            m_DesObj.SetActive(true);
        }
        else
        {
            m_DesObj.SetActive(false);
        }

        //------------------------------------------
        // ���ʂ̎���
        //------------------------------------------
        if (m_Size == Size.BIG)
        {
            if (m_State == State.PUT)
            {
                if (!CompleteObject.activeSelf)
                    CompleteObject.SetActive(true);

                if (SaplingObject.activeSelf)
                    SaplingObject.SetActive(false);
            }
            else if (m_State == State.SAPLING)
            {
                if (CompleteObject.activeSelf)
                    CompleteObject.SetActive(false);

                if (!SaplingObject.activeSelf)
                    SaplingObject.SetActive(true);

                if (m_TimeManager.GetDayEnd())
                {
                    m_Day++;
                }

                if (m_Day >= 2)
                {
                    if (m_MyZone == m_NowZone)
                    {
                        m_State = State.COMPLETE;
                    }
                    else
                    {
                        m_State = State.WITHER;
                    }
                }


            }
            else if (m_State == State.COMPLETE)
            {
                if (!CompleteObject.activeSelf)
                    CompleteObject.SetActive(true);

                if (SaplingObject.activeSelf)
                    SaplingObject.SetActive(false);
            }
            else if (m_State == State.WITHER)
            {
                if (!WitherObject.activeSelf)
                    WitherObject.SetActive(true);

                if (SaplingObject.activeSelf)
                    SaplingObject.SetActive(false);

            }
        }
        //------------------------------------------
        // �����
        //------------------------------------------
        else if(m_Size == Size.SMALL)
        {
            if (m_State == State.PUT)
            {
                if (!CompleteObject.activeSelf)
                    CompleteObject.SetActive(true);

                if (SaplingObject.activeSelf)
                    SaplingObject.SetActive(false);
            }
            else if (m_State == State.SAPLING)
            {
                if (CompleteObject.activeSelf)
                    CompleteObject.SetActive(false);

                if (!SaplingObject.activeSelf)
                    SaplingObject.SetActive(true);

                if (m_TimeManager.GetDayEnd())
                {
                    m_Day++;
                }

                if (m_Day >= 2)
                {
                    if (m_MyZone == m_NowZone)
                    {
                        m_State = State.COMPLETE;
                    }
                    else
                    {
                        m_State = State.WITHER;
                    }
                }


            }
            else if (m_State == State.COMPLETE)
            {
                if (!CompleteObject.activeSelf)
                    CompleteObject.SetActive(true);

                if (SaplingObject.activeSelf)
                    SaplingObject.SetActive(false);

                if (m_TimeManager.GetDayEnd())
                {
                    if(m_Reaper)
                    {
                        m_TimeManager.AddMoney(m_Cost);
                        m_ReaperNum++;
                    }
                }

                if(m_ReaperNum >= m_ReaperNumMax)
                {
                    m_State = State.DES;
                }
            }
            else if (m_State == State.WITHER)
            {
                if (!WitherObject.activeSelf)
                    WitherObject.SetActive(true);

                if (SaplingObject.activeSelf)
                    SaplingObject.SetActive(false);
            }
            else if(m_State == State.DES)
            {
                TreeReset();
                m_ObjectScript.TreeList.Remove(this.gameObject);

                //--------------------------------------------------
                //�����G�t�F�N�g�͂��̂ւ�
                //---------------------------------------------------

                Destroy(this.gameObject);
            }
        }
    }

    public void SetSapling()
    {
        m_State = State.SAPLING;
    }

    public void SetSize(Size size)
    {
        m_Size = size;
    }

    public void SetReaper(bool flag)
    {
        m_Reaper = flag;
    }

    public void SetCost(int cost)
    {
        m_Cost = cost;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ONTAI")
        {
            m_NowZone = Zone.ONTAI;
        }
        else if (other.gameObject.tag == "NETTAI")
        {
            m_NowZone = Zone.NETTAI;
        }
        else if (other.gameObject.tag == "KANSOUTAI")
        {
            m_NowZone = Zone.KANSOUTAI;
        }
        else if (other.gameObject.tag == "KANTAI")
        {
            m_NowZone = Zone.KANTAI;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Machine")
        {
            m_NowZone = Zone.NONE;
        }
    }

    public void TreeReset()
    {
        if (m_MyZone == Zone.ONTAI)
        {
            m_Ontai.ResetList();
        }
        else if (m_MyZone == Zone.NETTAI)
        {
            m_Nettai.ResetList();
        }
        else if (m_MyZone == Zone.KANSOUTAI)
        {
            m_Kansoutai.ResetList();
        }
        else if (m_MyZone == Zone.KANTAI)
        {
            m_Kantai.ResetList();
        }
    }

}
