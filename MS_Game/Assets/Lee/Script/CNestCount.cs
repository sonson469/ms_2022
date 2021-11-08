using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNestCount : MonoBehaviour
{

    public int[] m_NestNameCount = new int[(int)CGameObject.NestNumber.NESTMAX];

    [SerializeField] private AnimalNestData m_NestData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < (int)CGameObject.NestNumber.NESTMAX; i++)
        {
            if (other.gameObject.tag == "n" + m_NestData.sheets[0].list[i].Name)
            {
                m_NestNameCount[i]++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < (int)CGameObject.NestNumber.NESTMAX; i++)
        {
            if (other.gameObject.tag == "n" + m_NestData.sheets[0].list[i].Name)
            {
                m_NestNameCount[i]++;
            }
        }
    }
}
