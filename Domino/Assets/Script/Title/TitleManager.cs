using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    public int Title;

    public ItemTitle titlePrefab;

    public List<Transform> titleTrans = new List<Transform>();

    private void Start()
    {
        SpawnTitle();
    }

    public void SpawnTitle()
    {
        for (int i = 0; i < Title; i++)
        {
            ItemTitle item = Instantiate(titlePrefab, titleTrans[i]);

            ItemTitleData data = new ItemTitleData(i);

            item.InitTitleData(data);
        }
    }
}
