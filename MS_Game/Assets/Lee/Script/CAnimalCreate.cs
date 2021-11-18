using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimalCreate : MonoBehaviour
{

    [Header("�q�I�u�W�F�N�g�̑�")]
    [SerializeField] protected GameObject m_MyNest;
    [SerializeField] private AnimalData m_AnimalData;

    protected CNest m_NestScript;

    protected GameObject m_Manager;
    protected CGameTimeManager m_TimeManager;

    protected GameObject m_MyObject;

    protected List<GameObject> m_MyAnimalList = new List<GameObject>();  //�����̑��Ő������ꂽ����

    public GameObject a;

    public void Start()
    {
    }

    public void CreateAnimal(int NestID,GameObject nest,float range,int num)   //���ԍ��A�Ώۂ̑��A�����͈́A���������̐H���A���̎��
    {
        GameObject Object = (GameObject)Resources.Load("Animal/" + m_AnimalData.sheets[0].list[NestID - 1].Name);

        float posX = Random.Range(-range,range);
        float posZ = Random.Range(-range, range);

        Vector3 Position = new Vector3(nest.transform.position.x + posX, 0.0f, nest.transform.position.z + posZ);

        // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
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
