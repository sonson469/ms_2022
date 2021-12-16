using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{



}

public class SaveControl:Save
{
    private CGameObject m_CGameObj;
    private GameObject m_Manager;


    void save()
    {
        m_Manager = GameObject.FindWithTag("Manager");
        m_CGameObj = m_Manager.GetComponent<CGameObject>();

        Debug.Log("Save");

        SaveManager.SetClass("GameObj", m_CGameObj);

        Debug.Log("Load");

        m_CGameObj = SaveManager.GetClass("GameObj", new CGameObject());

        Debug.Log(m_CGameObj.ToString());
    }


}

