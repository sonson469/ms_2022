using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimalCreate : MonoBehaviour
{

    [Header("子オブジェクトの巣")]
    protected GameObject m_MyNest;
    [SerializeField] private AnimalNestData m_NestData;

    protected CNest m_NestScript;

    protected GameObject m_Manager;
    protected CGameTimeManager m_TimeManager;

    public void Start()
    {
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
