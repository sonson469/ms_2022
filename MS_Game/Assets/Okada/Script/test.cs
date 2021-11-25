using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public CSaveObj SaveObj = new CSaveObj();

    [System.Serializable]
    public class CSaveObj
    {
        public CGameObject m_GameObj;
        public CGameTimeManager m_GameTime;
    }

    void Start()
    {
        CSaveManager.DeleteAll();
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            Save();
    }

    private void Save()
    {
        //CSaveManager.SetInt("ii", SaveObj.m_GameObj.m_TreeNameCount[0]);
        //CSaveManager.SetClass("GameObj", SaveObj.m_GameObj);
        //CSaveManager.SetClass("GameTime", SaveObj.m_GameTime);
        //CSaveManager.SetFloat("Day",SaveObj.m_GameTime.GetGameDay());
        //CSaveManager.Save();

        //CSaveObj obj = CSaveManager.GetClass<CSaveObj>("GameObj", SaveObj);
        //Debug.Log(CSaveManager.GetInt("ii"));

        //Debug.Log(SaveObj.m_GameObj.ToString());
        //Debug.Log(obj.ToString());

        CSaveManager.SetClass<CGameObject>("gameObj", SaveObj.m_GameObj);
        Debug.Log("ÉZÅ[Éu");

    }

}
