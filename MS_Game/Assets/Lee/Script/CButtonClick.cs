using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CButtonClick : MonoBehaviour
{
    [SerializeField] private TreeData m_TreeData;
    private CPrefabList m_PrefabList;
    private CObjectMove m_ObjectMoveScript;

    private GameObject m_Object;

    private GameObject m_TargetObject;

    private Vector3 m_ObjectPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_PrefabList = this.gameObject.GetComponent<CPrefabList>();
        m_ObjectMoveScript = this.gameObject.GetComponent<CObjectMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CeateTree(int TreeID)
    {
        if(m_TreeData.sheets[0].list[TreeID-1].Cost <= 10000)
        {

            m_Object = (GameObject)Resources.Load(m_TreeData.sheets[0].list[TreeID - 1].Name);

            m_ObjectPosition = new Vector3(5.0f, 0.0f, 0.0f);

            // プレハブを元にオブジェクトを生成する
            m_TargetObject = Instantiate(m_Object,m_ObjectPosition,Quaternion.identity);

            m_ObjectMoveScript.SetTargetObject(m_TargetObject);

            m_ObjectMoveScript.SetObjectMove(true);

            m_ObjectMoveScript.SetPlane();
        }
    }

    public Vector3 GetObjectPosition()
    {
        return m_ObjectPosition;
    }
}
