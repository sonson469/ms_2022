using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerHerbivore : CAnimalCreate
{

    // Start is called before the first frame update
    void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void NestAnimal()
    {
        if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 3)
        {
            CreateAnimal(m_NestScript.GetNestNumAll());
            CreateAnimal(m_NestScript.GetNestNumAll());
            CreateAnimal(m_NestScript.GetNestNumAll());
        }
        else if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 1)
        {
            CreateAnimal(m_NestScript.GetNestNumAll());
        }
    }
}
