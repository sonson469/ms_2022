using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectMove : MonoBehaviour
{
    private bool m_ObjectMove = false;     //�ړ����[�h���ǂ���

    [SerializeField] private GameObject m_Plane;  //�u���Ƃ��I�u�W�F�N�g�̉��ɕ~�����
    [SerializeField] private GameObject m_Button;  //�L�����Z���{�^��

    [SerializeField] private Vector3 m_TargetPosition;    //�ړ�������I�u�W�F�N�g�̍��W
    [SerializeField] private Vector3 m_PutPosition;    //�ݒu�����I�u�W�F�N�g�̍��W
    [SerializeField] private Vector3 m_PutBeforePosition;    //1�O�ɐݒu�����I�u�W�F�N�g�̍��W
    [SerializeField] private Vector3 m_Vector;           //�P�O�Ɛݒu�����I�u�W�F�̃x�N�g��

    public GameObject m_TargetObject;     //�ړ�������I�u�W�F�N�g

    private CButtonClick m_ButtonScript;  //�N���b�N�̃X�N���v�g

    private bool m_Succession;     //�A���Œu���Ă��Ԃ�

    private int m_Num;     //�u���Ώۂ̔ԍ�

    public enum CreateObject     //�u���I�u�W�F�N�g�̎�ޔԍ��p
    { 
        TREE,
        NEST,
        MACHINE,
        NULL
    }

    public enum TreeSize
    {
        BIG,
        SMALL,
        NULL
    }

    private CreateObject m_CreateObjectNum; //�I�u�W�F�N�g�̎�ޔԍ�
    private TreeSize m_TreeSize = TreeSize.NULL;        //�؂������Ƃ��Ɏ��؂�����؂����ʗp

    private RaycastHit m_RaycastHit;

    private Camera m_MainCamera;
    private Vector3 m_CreatePosition;


    // Start is called before the first frame update
    void Start()
    {
        m_ButtonScript = this.gameObject.GetComponent<CButtonClick>();

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
        

        if (m_ObjectMove)
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

                //�����I�u�W�F�N�g�����ɐݒu���Ă���
                if (m_PutPosition != null)
                {
                    m_PutBeforePosition = m_PutPosition;
                    
                }

                //�u�����I�u�W�F�N�g�̍��W���i�[
                m_PutPosition = m_TargetObject.transform.position;

                if(m_PutBeforePosition != null)
                {
                    m_Vector = m_PutPosition - m_PutBeforePosition;
                }

                if(m_CreateObjectNum == CreateObject.TREE)
                {
                    m_ButtonScript.CreateTree(m_Num);
                }
                else if(m_CreateObjectNum == CreateObject.NEST)
                {
                    m_ButtonScript.CreateNest(m_Num);
                }
                else if (m_CreateObjectNum == CreateObject.MACHINE)
                {
                    m_ButtonScript.CreateMachine(m_Num);
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

    public void ResetMove()
    {
        m_ObjectMove = false;
        m_Plane.SetActive(false);
        m_Button.SetActive(false);

        TreeReset();

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
        if (m_TreeSize == TreeSize.BIG)
        {
            CTreeBig treescript = m_TargetObject.GetComponent<CTreeBig>();
            treescript.ResetList();

        }
        else if (m_TreeSize == TreeSize.SMALL)
        {
            CTreeSmall treescript = m_TargetObject.GetComponent<CTreeSmall>();
            treescript.ResetList();
        }

        m_TreeSize = TreeSize.NULL;
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

    public bool GetSuccession()
    {
        return m_Succession;
    }

    public Vector3 GetCreatePosition()
    {
        return m_CreatePosition;
    }
}
