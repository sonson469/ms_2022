using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectMove : MonoBehaviour
{

    private int m_TargetObjectCost;      //�ړ�������I�u�W�F�N�g�̃R�X�g

    [SerializeField] private GameObject m_Plane;  //�u���Ƃ��I�u�W�F�N�g�̉��ɕ~�����
    [SerializeField] private GameObject m_Button;  //�L�����Z���{�^��

    [SerializeField] private Vector3 m_TargetPosition;    //�ړ�������I�u�W�F�N�g�̍��W
    [SerializeField] private Vector3 m_PutPosition;    //�ݒu�����I�u�W�F�N�g�̍��W
    [SerializeField] private Vector3 m_PutBeforePosition;    //1�O�ɐݒu�����I�u�W�F�N�g�̍��W
    [SerializeField] private Vector3 m_Vector;           //�P�O�Ɛݒu�����I�u�W�F�̃x�N�g��

    public GameObject m_TargetObject;     //�ړ�������I�u�W�F�N�g

    private CButtonClick m_ButtonScript;  //�N���b�N�̃X�N���v�g

    private CGameObject m_GameObjectScript;
    private CGameTimeManager m_TimeScript;

    private bool m_Succession;     //�A���Œu���Ă��Ԃ�

    private int m_Num;     //�u���Ώۂ̔ԍ�

    private bool m_OnObj;

    public enum CreateObject     //�u���I�u�W�F�N�g�̎�ޔԍ��p
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

    private CreateObject m_CreateObjectNum; //�I�u�W�F�N�g�̎�ޔԍ�
    private TreeSize m_TreeSize = TreeSize.NONE;        //�؂������Ƃ��Ɏ��؂�����؂����ʗp

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
        Ray ray = m_MainCamera.ScreenPointToRay(m_MainCamera.transform.forward); //�J�������烌�C���΂�
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

            //�}�E�X�œ������Ă鏰�̈ʒu�Ɠ����ɂ���
            m_TargetObject.transform.position = new Vector3(m_Plane.transform.position.x, m_TargetObject.transform.position.y, m_Plane.transform.position.z);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                m_Succession = true;
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------
            // �ݒu
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------
            if(m_Succession)
            {
                //�@�B�̎��A���̋@�B�̒n�ʂƐڂ��Ă��炨���Ȃ�
                if (m_CreateObjectNum == CreateObject.MACHINE)
                {
                    CMachine machinescript = m_TargetObject.GetComponent<CMachine>();
                    if (!machinescript.GetCanPut())
                        return;
                }

                //��������Ă���u��
                if (m_TargetObjectCost <= m_TimeScript.GetMoney())
                {

                    //---------------------------------
                    // �ݒu�G�t�F�N�g�͂��̂ւ�
                    //-----------------------------------

                    //�����I�u�W�F�N�g�����ɐݒu���Ă���
                    if (m_PutPosition != null)
                    {
                        m_PutBeforePosition = m_PutPosition;
                    }

                    //�u�����I�u�W�F�N�g�̍��W���i�[
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

                    //�ׂɂ����Ă���
                    if (m_Vector.magnitude == 1.0f)
                    {
                        m_Plane.transform.position = new Vector3(m_PutPosition.x + m_Vector.x, 0.52f, m_PutPosition.z + m_Vector.z);

                    }
                    //�����������͗׈ȊO
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
