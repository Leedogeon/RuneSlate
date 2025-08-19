using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public List<string> items = new List<string>();

    public void UseItem(int Index)
    {
        if (items[Index] != null)
        {
            if (items[Index] == "Potion")
            {

            }
        }
    }



}
