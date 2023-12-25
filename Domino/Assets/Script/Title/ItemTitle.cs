using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemTitleData
{
    public int id;

    public ItemTitleData() { }

    public ItemTitleData(int id) { this.id = id; }
}

public class ItemTitle : MonoBehaviour
{
    public ItemTitleData data;

    public void InitTitleData(ItemTitleData data)
    {
        this.data = data;
    }
}
