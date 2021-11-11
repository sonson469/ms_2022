using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PageManager : MonoBehaviour
{
    public int page = 0;
    [SerializeField] private GameObject PictureBook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=1; i< PictureBook.transform.childCount; ++i)
        {
            if (i == page)
            {
                PictureBook.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                PictureBook.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public int GetMaxPage()
    {
        return PictureBook.transform.childCount - 1;
    }
}
