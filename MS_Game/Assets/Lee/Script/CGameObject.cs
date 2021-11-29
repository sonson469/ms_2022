using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameObject : MonoBehaviour
{

    public List<List<GameObject>> TreeList = new List<List<GameObject>>();  //�������ꂽ����
    public int m_TreeBigCount;     //���؂̐�
    public int m_TreeSmallCount;   //����؂̐�

    public List<List<GameObject>> AnimalList = new List<List<GameObject>>();�@//�������ꂽ����
    public List<GameObject> AnimalNestList = new List<GameObject>();  //�������ꂽ��
    public List<GameObject> MachineList = new List<GameObject>();  //�������ꂽ�@�B

    [SerializeField] private TreeData m_TreeData;
    public int[] m_TreeNameCount = new int[(int)TreeNumber.TREEMAX];

    [SerializeField] private AnimalNestData m_NestData;
    public int[] m_NestNameCount = new int[(int)NestNumber.NESTMAX];

    public int[] m_MachineNameCount = new int[(int)MachineNumber.MACHINEMAX];

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
        
    }

    //���O���Ƃɉ����邩������
    public void TreeNameCount(int num)
    {
        m_TreeNameCount[num]++;
    }

    public void NestNameCount(int num)
    {
        m_NestNameCount[num]++;
    }
    
    public void MachineNameCount(int num)
    {
        m_MachineNameCount[num]++;
    }

}
