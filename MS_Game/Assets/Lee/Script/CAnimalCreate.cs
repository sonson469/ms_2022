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
    protected CGameObject m_GameObjectScript;

    protected GameObject m_MyObject;

    protected List<GameObject> m_MyAnimalList = new List<GameObject>();  //�����̑��Ő������ꂽ����

    protected int m_MaxAnimal = 8;   //���


    public void Start()
    {
    }

    public void CreateAnimal(int NestID,GameObject nest,float range,int num)   //���ԍ��A�Ώۂ̑��A�����͈́A�n��
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
            COntai animscript = nest.GetComponent<COntai>();
            animscript.AddMyList(animal);
        }
        else if (num == 2)
        {
            CNettai animscript = nest.GetComponent<CNettai>();
            animscript.AddMyList(animal);
        }
        else if (num == 3)
        {
            CKansoutai animscript = nest.GetComponent<CKansoutai>();
            animscript.AddMyList(animal);
        }
        else if (num == 4)
        {
            CKantai animscript = nest.GetComponent<CKantai>();
            animscript.AddMyList(animal);
        }

    }

    public virtual void NestAnimal()
    {

    }
    
    
}
