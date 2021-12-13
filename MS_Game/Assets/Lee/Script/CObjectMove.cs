using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectMove : MonoBehaviour
{

    private int m_TargetObjectCost;      //移動させるオブジェクトのコスト

    [SerializeField] private GameObject m_Plane;  //置くときオブジェクトの下に敷くやつ
    [SerializeField] private GameObject m_Button;  //キャンセルボタン

    [SerializeField] private Vector3 m_TargetPosition;    //移動させるオブジェクトの座標
    [SerializeField] private Vector3 m_PutPosition;    //設置したオブジェクトの座標
    [SerializeField] private Vector3 m_PutBeforePosition;    //1個前に設置したオブジェクトの座標
    [SerializeField] private Vector3 m_Vector;           //１個前と設置したオブジェのベクトル

    public GameObject m_TargetObject;     //移動させるオブジェクト

    private CButtonClick m_ButtonScript;  //クリックのスクリプト

    private CGameObject m_GameObjectScript;
    private CGameTimeManager m_TimeScript;

    private bool m_Succession;     //連続で置いてる状態か

    private int m_Num;     //置く対象の番号

    private bool m_OnObj;

    public enum CreateObject     //置くオブジェクトの種類番号用
    { 
        TREE,
        NEST,
        MACHINE,
        REAPER,
        NULL
    }

    public enum TreeSize
    {
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI,
        NONE
    }

    private CreateObject m_CreateObjectNum; //オブジェクトの種類番号
    private TreeSize m_TreeSize = TreeSize.NONE;        //木だったときに樹木か低樹木か判別用

    private CTree.Size m_TreeSizeSize = CTree.Size.NONE;

    private RaycastHit m_RaycastHit;

    private Camera m_MainCamera;
    private Vector3 m_CreatePosition;


    // Start is called before the first frame update
    void Start()
    {
        m_ButtonScript = this.gameObject.GetComponent<CButtonClick>();
        m_GameObjectScript = this.gameObject.GetComponent<CGameObject>();
        m_TimeScript = this.gameObject.GetComponent<CGameTimeManager>();

        m_Vector = new Vector3(2.0f, 0, 0);

        m_RaycastHit = new RaycastHit();
        m_MainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = m_MainCamera.ScreenPointToRay(m_MainCamera.transform.forward); //カメラからレイを飛ばす
        if (Physics.Raycast(ray, out m_RaycastHit))
        {

            m_CreatePosition = new Vector3 (Mathf.Round(m_RaycastHit.point.x + 16.5f), 0, Mathf.Round(m_RaycastHit.point.z - 1.5f));
            

        }

        if (m_GameObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            if(!m_Button.activeSelf)
            {
                m_Button.SetActive(true);
            }

            //マウスで動かしてる床の位置と同じにする
            m_TargetObject.transform.position = new Vector3(m_Plane.transform.position.x, m_TargetObject.transform.position.y, m_Plane.transform.position.z);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                m_Succession = true;
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------
            // 設置
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------
            if(m_Succession)
            {
                //機械の時、他の機械の地面と接してたらおけない
                if (m_CreateObjectNum == CreateObject.MACHINE)
                {
                    CMachine machinescript = m_TargetObject.GetComponent<CMachine>();
                    if (!machinescript.GetCanPut())
                        return;
                }

                //お金足りてたら置く
                if (m_TargetObjectCost <= m_TimeScript.GetMoney())
                {

                    //---------------------------------
                    // 設置エフェクトはこのへん
                    //-----------------------------------

                    //同じオブジェクトを既に設置してたら
                    if (m_PutPosition != null)
                    {
                        m_PutBeforePosition = m_PutPosition;
                    }

                    //置いたオブジェクトの座標を格納
                    m_PutPosition = m_TargetObject.transform.position;

                    if (m_PutBeforePosition != null)
                    {
                        m_Vector = m_PutPosition - m_PutBeforePosition;
                    }

                    m_TimeScript.UseMoney(m_TargetObjectCost);

                    if (m_CreateObjectNum == CreateObject.TREE)
                    {
                        m_GameObjectScript.TreeList.Add(m_TargetObject);
                        m_GameObjectScript.TreeNameCount(m_Num - 1);

                        CTree treescript = m_TargetObject.GetComponent<CTree>();
                        treescript.SetSapling();
                        treescript.SetSize(m_TreeSizeSize);
                        treescript.SetCost(m_TargetObjectCost * 2);
                        m_ButtonScript.CreateTree(m_Num);

                    }
                    else if (m_CreateObjectNum == CreateObject.NEST)
                    {
                        m_OnObj = true;
                        m_GameObjectScript.AnimalNestList.Add(m_TargetObject);
                        m_GameObjectScript.NestNameCount(m_Num - 1);

                        CNestCount script = m_TargetObject.GetComponent<CNestCount>();
                        script.SetPut();

                        m_ButtonScript.CreateNest(m_Num);
                    }
                    else if (m_CreateObjectNum == CreateObject.MACHINE)
                    {
                        CMachine machinescript = m_TargetObject.GetComponent<CMachine>();
                        machinescript.SetPut();

                        m_GameObjectScript.MachineList.Add(m_TargetObject);
                        m_GameObjectScript.MachineNameCount(m_Num - 1);
                        m_ButtonScript.CreateMachine(m_Num);
                    }
                    else if(m_CreateObjectNum == CreateObject.REAPER)
                    {
                        CReaper reaperscript = m_TargetObject.GetComponent<CReaper>();
                        m_GameObjectScript.ReaperList.Add(m_TargetObject);
                        m_ButtonScript.CreateReaper();
                    }

                    //隣においてた時
                    if (m_Vector.magnitude == 1.0f)
                    {
                        m_Plane.transform.position = new Vector3(m_PutPosition.x + m_Vector.x, 0.52f, m_PutPosition.z + m_Vector.z);

                    }
                    //初期もしくは隣以外
                    else
                    {
                        m_Plane.transform.position = new Vector3(m_PutPosition.x + 1.0f, 0.52f, m_PutPosition.z);
                    }

                    m_Succession = false;
                }
            }
        }
    }

    public void ResetMove()
    {
        m_GameObjectScript.SetMode(CGameObject.ModeState.NORMAL);
        m_Plane.SetActive(false);
        m_Button.SetActive(false);

        if (m_CreateObjectNum == CreateObject.TREE)
        {
            TreeReset();
        }
        else if(m_CreateObjectNum == CreateObject.NEST)
        {
            CNestCount nestscript = m_TargetObject.GetComponent<CNestCount>();
            nestscript.ResetList();
        }

        Destroy(m_TargetObject);

        m_TargetPosition = new Vector3(0, 0, 0);
        m_PutPosition = new Vector3(0, 0, 0);
        m_PutBeforePosition = new Vector3(0, 0, 0);
        m_Vector = new Vector3(2, 0, 0);
        m_TargetObject = null;
        m_CreateObjectNum = CreateObject.NULL;
    }

    public void TreeReset()
    {
        if (m_TreeSize == TreeSize.ONTAI)
        {
            COntaiTree treescript = m_TargetObject.GetComponent<COntaiTree>();
            treescript.ResetList();
        }
        else if (m_TreeSize == TreeSize.NETTAI)
        {
            CNettaiTree treescript = m_TargetObject.GetComponent<CNettaiTree>();
            treescript.ResetList();
        }
        else if (m_TreeSize == TreeSize.KANSOUTAI)
        {
            CKansoutaiTree treescript = m_TargetObject.GetComponent<CKansoutaiTree>();
            treescript.ResetList();
        }
        else if (m_TreeSize == TreeSize.KANTAI)
        {
            CKantaiTree treescript = m_TargetObject.GetComponent<CKantaiTree>();
            treescript.ResetList();
        }

        m_TreeSize = TreeSize.NONE;
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

    public void SetNum(int num)
    {
        m_Num = num;
    }

    public void SetObjectNum(CreateObject num)
    {
        m_CreateObjectNum = num;
    }

    public void SetTreeSize(TreeSize size)
    {
        m_TreeSize = size;
    }

    public void SetTreeSiseSize(CTree.Size size)
    {
        m_TreeSizeSize = size;
    }

    public void SetCost(int cost)
    {
        m_TargetObjectCost = cost;
    }

    public void SetOnObj(bool flag)
    {
        m_OnObj = flag;
    }

    public bool GetSuccession()
    {
        return m_Succession;
    }

    public Vector3 GetCreatePosition()
    {
        return m_CreatePosition;
    }

    public bool GetOnOjb()
    {
        return m_OnObj;
    }
}
