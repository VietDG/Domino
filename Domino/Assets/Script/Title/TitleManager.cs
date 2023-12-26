using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    public int Title;

    public ItemTitle titlePrefab;

    public List<Transform> titleTrans = new List<Transform>();

    public List<ItemTitle> items = new List<ItemTitle>();

    public GameObject Main;

    public SlotHolder hold;

    private void Start()
    {
        SpawmTrans();
        SpawnTitle();
    }

    public void SpawnTitle()// sinh ra data
    {
        for (int i = 0; i < Title; i++)
        {
            ItemTitle item = Instantiate(titlePrefab, titleTrans[i]);

            ItemTitleData data = new ItemTitleData(i);

            item.InitTitleData(data);
            items.Add(item);
        }
    }

    public void SpawmTrans()// sinh ra vi tri
    {
        for (int i = 0; i < Title; i++)
        {
            titleTrans.Add(Main.transform.GetChild(i));
        }
    }

    public void CheckWin()
    {
        if (items.Count == 0)
        {
            Debug.LogError("Win");
        }
    }
}
