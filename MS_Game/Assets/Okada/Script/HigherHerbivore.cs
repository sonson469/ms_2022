using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherHerbivore : CAnimalCreate

{
    // Start is called before the first frame update
    public new void Start()
    {
        m_NestScript = m_MyNest.gameObject.GetComponent<CNest>();
        m_Manager = GameObject.FindWithTag("Manager");
        m_TimeManager = m_Manager.GetComponent<CGameTimeManager>();
        m_MyObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TimeManager.GetDayEnd())
        {
            NestAnimal();
            m_TimeManager.AddNestCount();
        }
    }

    public override void NestAnimal()
    {
        if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 5)
        {
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange());
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange());
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange());
        }
        else if (m_NestScript.GetTreeBig() + m_NestScript.GetTreeSmall() >= 3)
        {
            CreateAnimal(m_NestScript.GetNestNumAll(), m_MyObject, m_NestScript.GetRange());
        }
    }
}
