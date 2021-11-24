using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNest : MonoBehaviour
{

    [SerializeField] private int m_TreeBigCount;   //樹木の数
    [SerializeField] private int m_TreeSmallCount; //低樹木の数

    [SerializeField] private int m_NestNum;        //各地帯での巣番号
    [SerializeField] private int m_NestNumAll;     //全体での番号

    [SerializeField] private float m_Range;


    public enum Climate
    {
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI,
        NONE
    }

    [SerializeField] private Climate m_Climate;
    private Climate m_NowZone = Climate.NONE;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void CountTreeBig(bool plus)
    {
        if(plus)
        {
            m_TreeBigCount++;
        }
        else if(!plus)
        {
            m_TreeBigCount--;
        }
    }
    public void CountTreeSmall(bool plus)
    {
        if (plus)
        {
            m_TreeSmallCount++;
        }
        else if(!plus)
        {
            m_TreeSmallCount--;
        }
    }
    public int GetTreeBig()
    {
        return m_TreeBigCount;
    }

    public int GetTreeSmall()
    {
        return m_TreeSmallCount;
    }

    public int GetNestNum()
    {
        return m_NestNum;
    }
    public int GetNestNumAll()
    {
        return m_NestNumAll;
    }
    public Climate GetClimate()
    {
        return m_Climate;
    }
    public Climate GetNowZone()
    {
        return m_NowZone;
    }

    public float GetRange()
    {
        return m_Range;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ONTAI")
        {
            m_NowZone = Climate.ONTAI;
        }
        else if (other.gameObject.tag == "NETTAI")
        {
            m_NowZone = Climate.NETTAI;
        }
        else if (other.gameObject.tag == "KANSOUTAI")
        {
            m_NowZone = Climate.KANSOUTAI;
        }
        else if (other.gameObject.tag == "KANTAI")
        {
            m_NowZone = Climate.KANTAI;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            m_NowZone = Climate.NONE;
        }
    }
}
