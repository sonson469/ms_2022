using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBook_Active : MonoBehaviour
{
    public GameObject PictureBook;
    public GameObject MenuButton;

    public void OnClick()
    {
        PictureBook.SetActive(true);
        MenuButton.SetActive(true);
    }

    public void OffClick()
    {
        PictureBook.SetActive(false);
        MenuButton.SetActive(false);
    }
}
