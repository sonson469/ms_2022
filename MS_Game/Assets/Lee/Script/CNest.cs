using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNest : MonoBehaviour
{

    [SerializeField] private int m_TreeBigCount;   //é˜ñÿÇÃêî
    [SerializeField] private int m_TreeSmallCount; //í·é˜ñÿÇÃêî

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
}
