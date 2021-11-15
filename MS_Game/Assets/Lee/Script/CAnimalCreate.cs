using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimalCreate : MonoBehaviour
{

    [Header("子オブジェクトの巣")]
    [SerializeField] protected GameObject m_MyNest;
    [SerializeField] private AnimalData m_AnimalData;

    protected CNest m_NestScript;

    protected GameObject m_Manager;
    protected CGameTimeManager m_TimeManager;

    protected GameObject m_MyObject;

    public GameObject a;

    public void Start()
    {
    }

    public void CreateAnimal(int NestID,GameObject nest,float range)   //巣番号、対象の巣、生成範囲
    {
        GameObject Object = (GameObject)Resources.Load("Animal/" + m_AnimalData.sheets[0].list[NestID - 1].Name);

        float posX = Random.Range(-range,range);
        float posZ = Random.Range(-range, range);

        Vector3 Position = new Vector3(nest.transform.position.x + posX, 0.0f, nest.transform.position.z + posZ);

        // プレハブを元にオブジェクトを生成する
        GameObject animal = Instantiate(Object, Position, Quaternion.identity);

    }

    public virtual void NestAnimal()
    {

    }
    
    
}
