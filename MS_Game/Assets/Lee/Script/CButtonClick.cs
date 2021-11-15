using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CButtonClick : MonoBehaviour
{
    [SerializeField] private TreeData m_TreeData;
    [SerializeField] private AnimalNestData m_NestData;
    [SerializeField] private MachineData m_MachineData;

    private CPrefabList m_PrefabList;
    private CObjectMove m_ObjectMoveScript;
    private CGameTimeManager m_TimeManager;

    private GameObject m_Object;

    private GameObject m_TargetObject;

    private Vector3 m_ObjectPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_PrefabList = this.gameObject.GetComponent<CPrefabList>();
        m_ObjectMoveScript = this.gameObject.GetComponent<CObjectMove>();
        m_TimeManager = this.gameObject.GetComponent<CGameTimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTree(int TreeID)
    {

        if(m_TreeData.sheets[0].list[TreeID-1].Cost <= m_TimeManager.GetMoney())
        {

            if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
            {
                m_ObjectMoveScript.TreeReset();
                Destroy(m_TargetObject);
            }

            m_ObjectMoveScript.SetNum(TreeID);
            m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.TREE);
            m_ObjectMoveScript.SetCost(m_TreeData.sheets[0].list[TreeID - 1].Cost);

            if (TreeID <= 19)
            {
                m_ObjectMoveScript.SetTreeSize(CObjectMove.TreeSize.BIG);
            }
            else if(TreeID >= 20)
            {
                m_ObjectMoveScript.SetTreeSize(CObjectMove.TreeSize.SMALL);
            }

            m_Object = (GameObject)Resources.Load(m_TreeData.sheets[0].list[TreeID - 1].Name);

            ObjectCreate();

        }
    }

    public void CreateNest(int NestID)
    {

        if (m_NestData.sheets[0].list[NestID - 1].Cost <= m_TimeManager.GetMoney())
        {

            if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
            {
                m_ObjectMoveScript.TreeReset();
                Destroy(m_TargetObject);
            }

            m_ObjectMoveScript.SetNum(NestID);
            m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.NEST);

            m_ObjectMoveScript.SetCost(m_NestData.sheets[0].list[NestID - 1].Cost);

            m_Object = (GameObject)Resources.Load("Anima_Nest/" + m_NestData.sheets[0].list[NestID - 1].Name);

            ObjectCreate();
        }
    }

    public void CreateMachine(int MachineID)
    {
        if (m_MachineData.sheets[0].list[MachineID - 1].Cost <= m_TimeManager.GetMoney())
        {

            m_ObjectMoveScript.TreeReset();


            if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
            {
                m_ObjectMoveScript.TreeReset();
                Destroy(m_TargetObject);
            }

            m_ObjectMoveScript.SetNum(MachineID);
            m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.MACHINE);
            m_ObjectMoveScript.SetCost(m_MachineData.sheets[0].list[MachineID - 1].Cost);

            m_Object = (GameObject)Resources.Load("Machine/" + m_MachineData.sheets[0].list[MachineID - 1].Name);

            ObjectCreate();

        }
    }

    public void Cancel()
    {
        m_ObjectMoveScript.ResetMove();
    }

    public void ChangeTimeSpeed(int num)
    {
        m_TimeManager.SetTimeSpeed(num);
    }

    private void ObjectCreate()
    {
        m_ObjectPosition = new Vector3(m_ObjectMoveScript.GetCreatePosition().x, 0.0f, m_ObjectMoveScript.GetCreatePosition().z);

        // プレハブを元にオブジェクトを生成する
        m_TargetObject = Instantiate(m_Object, m_ObjectPosition, Quaternion.identity);

        m_ObjectMoveScript.SetTargetObject(m_TargetObject);

        m_ObjectMoveScript.SetObjectMove(true);

        m_ObjectMoveScript.SetPlane();
    }

    public Vector3 GetObjectPosition()
    {
        return m_ObjectPosition;
    }
}
