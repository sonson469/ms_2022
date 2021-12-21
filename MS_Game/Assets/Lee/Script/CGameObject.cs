using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameObject : MonoBehaviour
{

    public List<GameObject> TreeList = new List<GameObject>(); //�������ꂽ����
    public int m_TreeBigCount;     //���؂̐�
    public int m_TreeSmallCount;   //����؂̐�

    public List<List<GameObject>> AnimalList = new List<List<GameObject>>();�@//�������ꂽ����

    public List<GameObject> AnimalNestList = new List<GameObject>();  //�������ꂽ��
    public List<GameObject> MachineList = new List<GameObject>();  //�������ꂽ�@�B
    public List<GameObject> ReaperList = new List<GameObject>();   //�������ꂽ�����@

    [SerializeField] private TreeData m_TreeData;
    public int[] m_TreeNameCount = new int[(int)TreeNumber.TREEMAX];

    [SerializeField] private AnimalNestData m_NestData;
    public int[] m_NestNameCount = new int[(int)NestNumber.NESTMAX];

    public int[] m_MachineNameCount = new int[(int)MachineNumber.MACHINEMAX];

    [SerializeField] private bool m_RangeFlag = false;

    public GameObject fade;//�C���X�y�N�^����Prefab������Canvas������
    public FadeManager m_FadeManager;

    public enum ModeState
    {
        NORMAL,
        OBJMOVE,
        DES,
        INFOR
    }

    private ModeState m_ModeState;

    private void Start()
    {

        m_FadeManager.fadeIn();

        for(int i = 0; i < 40; i++)
        {
            AnimalList.Add(new List<GameObject>());
        }

        m_ModeState = ModeState.NORMAL;
        
    }

    public enum TreeNumber
    {
        KEYAKI,
        UME,
        TAKE,
        MATU,
        SAKURA,
        KAPOKKU,
        MAHOGANI,
        ASAIYASI,
        TOWARAN,
        WOKINGUPAMU,
        NATUMEYASHI,
        AKASHIYA,
        ITIZIKU,
        HAROKISHIRON,
        BAOBABU,
        DAKEKANBA,
        YANAGI,
        KONARA,
        DAKEMOMI,
        YATUDE,
        KUTINASHI,
        BURUBERI,
        RABENDA,
        ROZUMARI,
        RATANNYASHI,
        ASERORA,
        SATOUKIBI,
        KOHINOKI,
        RAHURESHIA,
        SABOTEN,
        ENOKOROGUSA,
        PANPASUGURASU,
        JATOROFA,
        SORUGAMU,
        MIZUGOKE,
        ONIIWAHIGE,
        HAKUSANNITIGE,
        TAKANESUMIRE,
        KOMAKUSA,
        HISU,
        TREEMAX,
    }

    public enum AnimalNumber
    {
        HATUKANEZUMI,
        AMAKAERU,
        SHIMAHEBI,
        RESSAPANDA,
        NIHONNITATI,
        YAMAINU,
        OOTAKA,
        HUKUROU,
        GURIZURI,
        TORA,
        SYOUGARAGO,
        KAPIBARA,
        KOARA,
        WONBATTO,
        OOARIKUI,
        TASUMANIADEBIRU,
        OOKOUMORI,
        GORIRA,
        WANI,
        ZYAGA,
        HARINEZUMI,
        ARUMAZIRO,
        RAKUDA,
        SHIMAUMA,
        SABARU,
        ZYAKKARU,
        KABA,
        SAI,
        ZOU,
        RAION,
        PENGIN,
        AZARASHI,
        TONAKAI,
        ZYAKOUUSHI,
        HOKKYOKUKITUNE,
        SHIROHUKUROU,
        KUZURI,
        TUNDORAOOKAMI,
        SEIUTI,
        HOKKYOKUGUMA
    }

    public enum NestNumber
    {
        HATUKANEZUMI,
        AMAKAERU,
        SHIMAHEBI,
        RESSAPANDA,
        NIHONNITATI,
        YAMAINU,
        OOTAKA,
        HUKUROU,
        GURIZURI,
        TORA,
        SYOUGARAGO,
        KAPIBARA,
        KOARA,
        WONBATTO,
        OOARIKUI,
        TASUMANIADEBIRU,
        OOKOUMORI,
        GORIRA,
        WANI,
        ZYAGA,
        HARINEZUMI,
        ARUMAZIRO,
        RAKUDA,
        SHIMAUMA,
        SABARU,
        ZYAKKARU,
        KABA,
        SAI,
        ZOU,
        RAION,
        PENGIN,
        AZARASHI,
        TONAKAI,
        ZYAKOUUSHI,
        HOKKYOKUKITUNE,
        SHIROHUKUROU,
        KUZURI,
        TUNDORAOOKAMI,
        SEIUTI,
        HOKKYOKUGUMA,
        NESTMAX,
    }

    public enum MachineNumber
    {
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI,
        MACHINEMAX
    }
    private void Update()
    {
        //Debug.Log(m_ModeState);
    }

    //���O���Ƃɉ����邩������
    public void TreeNameCount(int num)
    {
        m_TreeNameCount[num]++;
    }
    public int GetNestNameCount(int num)
    {
        return m_NestNameCount[num - 1];
    }

    public void NestNameCount(int num)
    {
        m_NestNameCount[num]++;
    }
    public void NestNameCountMinus(int num)
    {
        m_NestNameCount[num - 1]--;
    }

    public void MachineNameCount(int num)
    {
        m_MachineNameCount[num]++;
    }

    public void SetMode(ModeState state)
    {
        m_ModeState = state;
    }

    public ModeState GetMode()
    {
        return m_ModeState;
    }

    public void SetRangeFlag(bool flag)
    {
        m_RangeFlag = flag;
    }

    public bool GetRangeFlag()
    {
        return m_RangeFlag;
    }

}
