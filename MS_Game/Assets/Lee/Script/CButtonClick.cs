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
    private CGameObject m_ObjectScript;

    private GameObject m_Object;

    private GameObject m_TargetObject;

    private Vector3 m_ObjectPosition;

    private bool m_NestBreake;

    private CAudio m_AudioScript;
    private AudioSource m_Audio;

    // Start is called before the first frame update
    void Start()
    {
        m_PrefabList = this.gameObject.GetComponent<CPrefabList>();
        m_ObjectMoveScript = this.gameObject.GetComponent<CObjectMove>();
        m_TimeManager = this.gameObject.GetComponent<CGameTimeManager>();
        m_ObjectScript = this.gameObject.GetComponent<CGameObject>();

        m_AudioScript = this.gameObject.GetComponent<CAudio>();
        m_Audio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTree(int TreeID)
    {

        if(!m_ObjectMoveScript.GetSuccession())
        {
            m_Audio.PlayOneShot(m_AudioScript.SESelest);
        }

        if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
        {
            m_ObjectMoveScript.ResetMove();
        }

        m_ObjectMoveScript.SetNum(TreeID);
        m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.TREE);
        m_ObjectMoveScript.SetCost(m_TreeData.sheets[0].list[TreeID - 1].Cost);

        if (TreeID <= 5 || (TreeID >= 20 && TreeID <= 24))
        {
            m_ObjectMoveScript.SetTreeSize(CObjectMove.TreeSize.ONTAI);
        }
        else if ((TreeID >= 6 && TreeID <= 10) || (TreeID >= 25 && TreeID <= 29))
        {
            m_ObjectMoveScript.SetTreeSize(CObjectMove.TreeSize.NETTAI);
        }
        else if ((TreeID >= 11 && TreeID <= 15) || (TreeID >= 30 && TreeID <= 34))
        {
            m_ObjectMoveScript.SetTreeSize(CObjectMove.TreeSize.KANSOUTAI);
        }
        else if ((TreeID >= 16 && TreeID <= 19) || (TreeID >= 35 && TreeID <= 40))
        {
            m_ObjectMoveScript.SetTreeSize(CObjectMove.TreeSize.KANTAI);
        }

        if (TreeID <= 19)
        {
            m_ObjectMoveScript.SetTreeSiseSize(CTree.Size.BIG);
        }
        else
        {
            m_ObjectMoveScript.SetTreeSiseSize(CTree.Size.SMALL);
        }

        m_Object = (GameObject)Resources.Load(m_TreeData.sheets[0].list[TreeID - 1].Name);

        ObjectCreate();
        float y = Random.Range(0.0f, 360.0f);
        m_TargetObject.transform.Rotate(new Vector3(0, y, 0));


    }

    public void CreateNest(int NestID)
    {

        if (!m_ObjectMoveScript.GetSuccession())
        {
            m_Audio.PlayOneShot(m_AudioScript.SESelest);
        }

        if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
        {
            m_ObjectMoveScript.ResetMove();
        }

        m_ObjectMoveScript.SetNum(NestID);
        m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.NEST);

        m_ObjectMoveScript.SetCost(m_NestData.sheets[0].list[NestID - 1].Cost);

        m_Object = (GameObject)Resources.Load("Anima_Nest/" + m_NestData.sheets[0].list[NestID - 1].Name);

        ObjectCreate();

    }

    public void CreateMachine(int MachineID)
    {

        if (!m_ObjectMoveScript.GetSuccession())
        {
            m_Audio.PlayOneShot(m_AudioScript.SESelest);
        }

        if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
        {
            m_ObjectMoveScript.ResetMove();
        }

        m_ObjectMoveScript.SetNum(MachineID);
        m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.MACHINE);
        m_ObjectMoveScript.SetCost(m_MachineData.sheets[0].list[MachineID - 1].Cost);

        m_Object = (GameObject)Resources.Load("Machine/" + m_MachineData.sheets[0].list[MachineID - 1].Name);

        ObjectCreate();
    }

    public void CreateReaper()
    {

        if (!m_ObjectMoveScript.GetSuccession())
        {
            m_Audio.PlayOneShot(m_AudioScript.SESelest);
        }

        if (m_TargetObject != null && !m_ObjectMoveScript.GetSuccession())
        {
            m_ObjectMoveScript.ResetMove();
        }
        m_ObjectMoveScript.SetObjectNum(CObjectMove.CreateObject.REAPER);
        m_ObjectMoveScript.SetCost(500);

        m_Object = (GameObject)Resources.Load("Machine/刈取り機");

        ObjectCreate();
    }

    public void Cancel()
    {
        m_Audio.PlayOneShot(m_AudioScript.SEKettei);

        if (m_ObjectScript.GetMode() == CGameObject.ModeState.DES || m_ObjectScript.GetMode() == CGameObject.ModeState.INFOR)
        {
            m_ObjectScript.SetMode(CGameObject.ModeState.NORMAL);
        }
        else
        {
            m_NestBreake = true;
            m_ObjectMoveScript.ResetMove();
        }
        
    }

    public void RangeActive()
    {

        m_Audio.PlayOneShot(m_AudioScript.SEKettei);

        if (m_ObjectScript.GetRangeFlag())
        {
            m_ObjectScript.SetRangeFlag(false);
        }
        else
        {
            m_ObjectScript.SetRangeFlag(true);
        }
    }

    public void DesObj()
    {
        m_Audio.PlayOneShot(m_AudioScript.SEKettei);

        if (m_ObjectScript.GetMode() == CGameObject.ModeState.DES)
        {
            m_ObjectScript.SetMode(CGameObject.ModeState.NORMAL);
        }
        else if (m_ObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            m_NestBreake = true;
            m_ObjectMoveScript.ResetMove();
            m_ObjectScript.SetMode(CGameObject.ModeState.DES);
        }
        else
        {
            m_ObjectScript.SetMode(CGameObject.ModeState.DES);
        }
    }
    public void Information()
    {
        m_Audio.PlayOneShot(m_AudioScript.SEKettei);

        if (m_ObjectScript.GetMode() == CGameObject.ModeState.INFOR)
        {
            m_ObjectScript.SetMode(CGameObject.ModeState.NORMAL);
        }
        else if (m_ObjectScript.GetMode() == CGameObject.ModeState.OBJMOVE)
        {
            m_NestBreake = true;
            m_ObjectMoveScript.ResetMove();
            m_ObjectScript.SetMode(CGameObject.ModeState.INFOR);
        }
        else
        {
            m_ObjectScript.SetMode(CGameObject.ModeState.INFOR);
        }
    }

    public void ChangeTimeSpeed(int num)
    {
        m_Audio.PlayOneShot(m_AudioScript.SESelest);

        m_TimeManager.SetTimeSpeed(num);
    }

    private void ObjectCreate()
    {
        m_ObjectPosition = new Vector3(m_ObjectMoveScript.GetCreatePosition().x, 0.0f, m_ObjectMoveScript.GetCreatePosition().z);

        // プレハブを元にオブジェクトを生成する
        m_TargetObject = Instantiate(m_Object, m_ObjectPosition, Quaternion.identity);

        m_ObjectMoveScript.SetTargetObject(m_TargetObject);

        //m_ObjectMoveScript.SetObjectMove(true);
        m_ObjectScript.SetMode(CGameObject.ModeState.OBJMOVE);

        m_ObjectMoveScript.SetPlane();
    }

    public Vector3 GetObjectPosition()
    {
        return m_ObjectPosition;
    }

    public bool GetNestBreake()
    {
        return m_NestBreake;
    }
    public void SetNestBreake(bool flag)
    {
        m_NestBreake = flag;
    }
}
