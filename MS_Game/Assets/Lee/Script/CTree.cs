using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PUT,    //置こうとしてるとき
        SAPLING, //苗木
        COMPLETE,  //成木(完成されてる状態)
        WITHER,   //枯れ
        DES       //消える
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

    private int m_Day;   //苗木からの経過日数

    [SerializeField] private int m_ReaperNumMax;    //Max刈り取り数
    private int m_ReaperNum;   //刈り取り数

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
    private GameObject m_InforObj;

    private GameObject m_InforCanvas;

    private Text m_StateText;
    private Text m_KaritoriText;
    private Text m_UrineText;

    [Header("適応地域")]
    [SerializeField] private Zone m_MyZone;   //適応地域
    private Zone m_NowZone = Zone.NONE;   //今いる地域

    [Header("苗木")]
    [SerializeField] private GameObject SaplingObject;
    [Header("成木")]
    [SerializeField] private GameObject CompleteObject;
    [Header("老木")]
    [SerializeField] private GameObject WitherObject;

    private GameObject m_SapUI;
    private GameObject m_CompUI;
    private GameObject m_WithUI;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_ObjectScript = m_Manager.GetComponent<CGameObject>();

        m_DesObj = this.gameObject.transform.GetChild(3).gameObject;
        m_InforObj = this.gameObject.transform.GetChild(4).gameObject;

        m_InforCanvas = this.gameObject.transform.GetChild(5).gameObject;

        GameObject obj = m_InforCanvas.gameObject.transform.GetChild(0).gameObject;

        m_StateText = obj.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();
        m_KaritoriText = obj.gameObject.transform.GetChild(4).gameObject.GetComponent<Text>();
        m_UrineText = obj.gameObject.transform.GetChild(5).gameObject.GetComponent<Text>();

        m_CompUI = obj.gameObject.transform.GetChild(3).gameObject;
        m_SapUI = obj.gameObject.transform.GetChild(6).gameObject;
        m_WithUI = obj.gameObject.transform.GetChild(7).gameObject;

        m_CompUI.SetActive(false);
        m_SapUI.SetActive(false);
        m_WithUI.SetActive(false);

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

        m_InforCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //表示するテキスト
        if (m_InforCanvas.activeSelf)
        {
            if (m_Size == Size.BIG)
            {
                if (m_State == State.SAPLING)
                {
                    if(m_CompUI.activeSelf)
                    {
                        m_CompUI.SetActive(false);
                    }
                    if(!m_SapUI.activeSelf)
                    {
                        m_SapUI.SetActive(true);
                    }
                    if(m_WithUI.activeSelf)
                    {
                        m_WithUI.SetActive(false);
                    }

                    m_StateText.text = "成長前";
                }
                else if (m_State == State.COMPLETE)
                {
                    if (!m_CompUI.activeSelf)
                    {
                        m_CompUI.SetActive(true);
                    }
                    if (m_SapUI.activeSelf)
                    {
                        m_SapUI.SetActive(false);
                    }
                    if (m_WithUI.activeSelf)
                    {
                        m_WithUI.SetActive(false);
                    }
                    m_StateText.text = "成長成功";
                }
                else if (m_State == State.WITHER)
                {
                    if (m_CompUI.activeSelf)
                    {
                        m_CompUI.SetActive(false);
                    }
                    if (m_SapUI.activeSelf)
                    {
                        m_SapUI.SetActive(false);
                    }
                    if (!m_WithUI.activeSelf)
                    {
                        m_WithUI.SetActive(true);
                    }
                    m_StateText.text = "成長失敗";
                }

                m_KaritoriText.text = "";
                m_UrineText.text = "";
            }
            else if (m_Size == Size.SMALL)
            {
                if (m_State == State.SAPLING)
                {
                    if (m_CompUI.activeSelf)
                    {
                        m_CompUI.SetActive(false);
                    }
                    if (!m_SapUI.activeSelf)
                    {
                        m_SapUI.SetActive(true);
                    }
                    if (m_WithUI.activeSelf)
                    {
                        m_WithUI.SetActive(false);
                    }
                    m_StateText.text = "成長前";
                }
                else if (m_State == State.COMPLETE)
                {
                    if (!m_CompUI.activeSelf)
                    {
                        m_CompUI.SetActive(true);
                    }
                    if (m_SapUI.activeSelf)
                    {
                        m_SapUI.SetActive(false);
                    }
                    if (m_WithUI.activeSelf)
                    {
                        m_WithUI.SetActive(false);
                    }
                    m_StateText.text = "成長成功";
                }
                else if (m_State == State.WITHER)
                {
                    if (m_CompUI.activeSelf)
                    {
                        m_CompUI.SetActive(false);
                    }
                    if (m_SapUI.activeSelf)
                    {
                        m_SapUI.SetActive(false);
                    }
                    if (!m_WithUI.activeSelf)
                    {
                        m_WithUI.SetActive(true);
                    }
                    m_StateText.text = "成長失敗";
                }

                int num = m_ReaperNumMax - m_ReaperNum;
                m_KaritoriText.text = "刈り取り残り : " + num.ToString();
                m_UrineText.text = "売値 : " + m_Cost.ToString() + "G";
            }

        }


        //撤去モード時は選択用の円柱がでてくる
        if (m_ObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            m_DesObj.SetActive(true);
            m_InforObj.SetActive(false);
        }
        else if(m_ObjectScript.GetMode() == CGameObject.ModeState.INFOR)
        {
            m_DesObj.SetActive(false);
            m_InforObj.SetActive(true);
        }
        else
        {
            m_InforObj.SetActive(false);
            m_DesObj.SetActive(false);
        }

        //------------------------------------------
        // 普通の樹木
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
        // 低樹木
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
                //消すエフェクトはこのへん
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

    public void SetInformation(bool flag)
    {
        m_InforCanvas.SetActive(flag);
    }

}
