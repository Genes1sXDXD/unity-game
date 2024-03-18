using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public int objectID;
    public string nameItem;
    public GameObject prefab;
    private string[] objectNameDatabase = {"Wood","Stone","Iron"};

    private void Start()
    {
        for (int i = 0; i < objectNameDatabase.Length; i++)
        {
            if (nameItem == objectNameDatabase[i]) {
                objectID = i;
            }
        }
    }
}


