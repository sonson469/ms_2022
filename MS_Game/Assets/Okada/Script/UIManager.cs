using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private Button button;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIDisp()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);    
    }

    //public void ChangeColor()
    //{
    //    if (canvas.gameObject.activeSelf==false)
    //    {
    //        this.gameObject.GetComponent<Image>().color = Color.red;
    //    }
    //    else
    //    {
    //        this.gameObject.GetComponent<Image>().color = Color.white;
    //    }
    //}

}
