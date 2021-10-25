using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTreeSmall : MonoBehaviour
{
    private List<GameObject> InNestList = new List<GameObject>();

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
        if (other.gameObject.tag == "Nest")
        {
            InNestList.Add(other.gameObject);
            CNest NestScript = other.gameObject.GetComponent<CNest>();
            NestScript.CountTreeSmall(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Nest")
        {
            InNestList.Remove(other.gameObject);
            CNest NestScript = other.gameObject.GetComponent<CNest>();
            NestScript.CountTreeSmall(false);

        }
    }

    public void ResetList()   //オブジェクトを消すときリスト内の木の数をリセットさせる
    {
        for (int i = 0; i < InNestList.Count; i++)
        {
            CNest NestScript = InNestList[i].GetComponent<CNest>();
            NestScript.CountTreeSmall(false);
        }
        InNestList.Clear();
    }
}
