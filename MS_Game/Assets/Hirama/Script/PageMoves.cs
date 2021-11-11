using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PageMoves : MonoBehaviour
{
    [SerializeField] private PageManager MenuButton;
    [SerializeField] int PageNo;

    public void OnClick()
    {
        MenuButton.page += PageNo;
        if (MenuButton.page < 1)
        {
            MenuButton.page = MenuButton.GetMaxPage();

        }
        else if (MenuButton.page > MenuButton.GetMaxPage())
        {
            MenuButton.page = 1;
        }
    }

    public void QuickClick()
    {
        MenuButton.page = PageNo;
    }
}