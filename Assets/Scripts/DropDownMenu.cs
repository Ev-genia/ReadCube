using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    public Text menu;
    private AudioSource AudioS;

    void Start()
    {
        AudioS = GetComponent<AudioSource>(); 
    }

    public void InputMenu(int value)
    {
        if (value == 0)
        {
            menu.text = "НУ-НО-НА-НЭ-НЫ-Н";
            
        }
        if (value == 1)
        {
            menu.text = "А-О-У-Ы-Э";
            AudioS.Play();
        }
        if (value == 2)
        {
            menu.text = "СУ-СО-СА-СЭ-СЫ-С";
        }
    }
}
