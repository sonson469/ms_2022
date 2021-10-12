using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPrefabList : MonoBehaviour
{
    [SerializeField] private static int m_TreeNum = 40;
    [SerializeField] private GameObject[] m_TreePrefabs = new GameObject[m_TreeNum];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreeCreate(int TreeID)
    {

        Instantiate(m_TreePrefabs[TreeID -1],new Vector3(5.0f, 0.0f, 0.0f),Quaternion.identity);
    }
}
