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

    protected List<GameObject> m_MyAnimalList = new List<GameObject>();  //自分の巣で生成された動物

    public GameObject a;

    public void Start()
    {
    }

    public void CreateAnimal(int NestID,GameObject nest,float range,int num)   //巣番号、対象の巣、生成範囲、生成動物の食物連鎖の種類
    {
        GameObject Object = (GameObject)Resources.Load("Animal/" + m_AnimalData.sheets[0].list[NestID - 1].Name);

        float posX = Random.Range(-range,range);
        float posZ = Random.Range(-range, range);

        Vector3 Position = new Vector3(nest.transform.position.x + posX, 0.0f, nest.transform.position.z + posZ);

        // プレハブを元にオブジェクトを生成する
        GameObject animal = Instantiate(Object, Position, Quaternion.identity);

        AnimalMove animalmove = animal.GetComponent<AnimalMove>();
        animalmove.SetTagetNest(nest);
        animalmove.SetRange(range);

        if(num == 1)
        {
            HigherCarnivore animscript = nest.GetComponent<HigherCarnivore>();
            animscript.AddMyList(animal);
        }
        else if(num == 2)
        {
            HigherHerbivore animscript = nest.GetComponent<HigherHerbivore>();
            animscript.AddMyList(animal);
        }
        else if (num == 3)
        {
            LowerCarnivore animscript = nest.GetComponent<LowerCarnivore>();
            animscript.AddMyList(animal);
        }
        else if (num == 4)
        {
            LowerHerbivore animscript = nest.GetComponent<LowerHerbivore>();
            animscript.AddMyList(animal);
        }

    }

    public virtual void NestAnimal()
    {

    }
    
    
}
