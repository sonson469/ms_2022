using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUIManager : MonoBehaviour
{

    [SerializeField] private GameObject[] m_GameObjects;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClassificationSelcet(int number)
    {
        for (int i = 0; i < m_GameObjects.Length; i++)
        {
            m_GameObjects[i].SetActive(false);
        }


        m_GameObjects[number].SetActive(true);
    }
}
