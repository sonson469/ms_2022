using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimalCreate : MonoBehaviour
{

    public GameObject m_MyNest;
    public AnimalNestData m_NestData;

    public CNest m_NestScript;

    public CGameObject m_GameObjectScript;

    public void Start()
    {
        m_GameObjectScript = this.gameObject.GetComponent<CGameObject>();
    }

    public void CreateAnimal(int NestID)
    {
        GameObject Object = (GameObject)Resources.Load("Animal/" + m_NestData.sheets[0].list[NestID - 1].Name);
        Vector3 Position = new Vector3(0.0f, 0.0f, 0.0f);

        // プレハブを元にオブジェクトを生成する
        GameObject animal = Instantiate(Object, Position, Quaternion.identity);
    }

    public virtual void NestAnimal()
    {

    }
    
}
