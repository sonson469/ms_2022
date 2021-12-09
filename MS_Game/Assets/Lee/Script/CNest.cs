using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNest : MonoBehaviour
{

    [SerializeField] private int m_TreeBigCount;   //é˜ñÿÇÃêî
    [SerializeField] private int m_TreeSmallCount; //í·é˜ñÿÇÃêî

    [SerializeField] private int m_NestNum;        //äeínë—Ç≈ÇÃëÉî‘çÜ
    [SerializeField] private int m_NestNumAll;     //ëSëÃÇ≈ÇÃî‘çÜ

    [SerializeField] private float m_Range;

    [SerializeField] private bool m_Put;


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

    public void SetNowZone(Climate climate)
    {
        m_NowZone = climate;
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

}
