using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameObject : MonoBehaviour
{

    //[SerializeField] private TreeData m_TreeData;

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
    public List<GameObject> TreeList = new List<GameObject>();  //ê∂ê¨Ç≥ÇÍÇΩé˜ñÿ
    public int m_TreeBigCount;     //é˜ñÿÇÃêî
    public int m_TreeSmallCount;   //í·é˜ñÿÇÃêî

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
    public List<GameObject> AnimalList = new List<GameObject>();  //ê∂ê¨Ç≥ÇÍÇΩìÆï®

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
    public List<GameObject> AnimalNestList = new List<GameObject>();  //ê∂ê¨Ç≥ÇÍÇΩëÉ

    public enum MachineNumber
    {
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI
    }
    public List<GameObject> MachineList = new List<GameObject>();  //ê∂ê¨Ç≥ÇÍÇΩã@äB


    [SerializeField] private TreeData m_TreeData;
    private int[] m_TreeNameCount = new int[(int)TreeNumber.TREEMAX];
    private void Update()
    {
        
    }

    public void TreeNameCount()
    {
        for (int i = 0; i <= TreeList.Count; i++)
        {
            if (TreeList[i].gameObject.name == m_TreeData.sheets[0].list[i].Name)
            {
                m_TreeNameCount[i]++;
            }
        }
    }
}
