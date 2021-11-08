using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerCarnivore : CAnimalCreate
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void NestAnimal()
    {
        if (m_NestScript.GetClimate() == CNest.Climate.ONTAI)
        {
            if (m_NestScript.GetNestNum() == 3)
            {
                
            }
        }
        else if (m_NestScript.GetClimate() == CNest.Climate.NETTAI)
        {

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANSOUTAI)
        {

        }
        else if (m_NestScript.GetClimate() == CNest.Climate.KANTAI)
        {

        }
    }

}
