using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNest : MonoBehaviour
{

    [SerializeField] private int m_TreeBigCount;   //÷–Ø‚Ì”
    [SerializeField] private int m_TreeSmallCount; //’á÷–Ø‚Ì”

    [SerializeField] private int m_NestNum;        //Še’n‘Ñ‚Å‚Ì‘ƒ”Ô†
    [SerializeField] private int m_NestNumAll;     //‘S‘Ì‚Å‚Ì”Ô†

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
