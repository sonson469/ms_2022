using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CButtonClick : MonoBehaviour
{
    [SerializeField] private TreeDatas m_TreeData;
    private CPrefabList m_PrefabList;
    // Start is called before the first frame update
    void Start()
    {
        m_PrefabList = this.gameObject.GetComponent<CPrefabList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CeateTree(int TreeID)
    {
        if(m_TreeData.sheets[0].list[TreeID-1].Cost <= 400)
        {
            m_PrefabList.TreeCreate(TreeID);
        }
    }
}
