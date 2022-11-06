using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;
    [SerializeField] private Menu[] menus;

    private void Init() {
        instance = this;
    }

    private void Awake() {
        Init();
    }

    public void OpenMenu(string menuName) {
        for (int i = 0; i < menus.Length; i++) {
            if (menus[i].menuName == menuName) {    // Find Menu
                OpenMenu(menus[i]);
            }
            else if (menus[i].isOpen) {             // Is Opened
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu) {
        for (int i = 0; i < menus.Length; i++) {
             if (menus[i].isOpen) {
                CloseMenu(menus[i]);
            }
        }

        menu.Open();
    }

    public void CloseMenu(Menu menu) {
        menu.Close();
    }

}