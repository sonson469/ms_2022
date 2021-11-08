using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNest : MonoBehaviour
{

    [SerializeField] private int m_TreeBigCount;   //樹木の数
    [SerializeField] private int m_TreeSmallCount; //低樹木の数

    [SerializeField] private int m_NestNum;        //各地帯での巣番号
    [SerializeField] private int m_NestNumAll;     //全体での番号

    public enum Climate
    {
        ONTAI,
        NETTAI,
        KANSOUTAI,
        KANTAI
    }

    [SerializeField] private Climate m_Climate;

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
}
