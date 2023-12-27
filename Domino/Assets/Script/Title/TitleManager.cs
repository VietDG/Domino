using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    public int Title;

    public ItemTitle titlePrefab;

    public List<Transform> titleTrans = new List<Transform>();

    public List<ItemTitle> items = new List<ItemTitle>();

    public GameObject Main;

    public SlotHolder hold;

    public Sprite[] _spriteValue;

    private void Start()
    {
        SpawmTrans();
        SpawnTitle();
    }

    public void SpawnTitle()// sinh ra data
    {
        for (int i = 0; i < Title; i++)
        {
            int rd = Random.Range(0, _spriteValue.Length);
            int rd1 = Random.Range(0, _spriteValue.Length);
            List<int> id = new List<int> { rd, rd1 };
            ItemTitle item = Instantiate(titlePrefab, titleTrans[i]);

            ItemTitleData data = new ItemTitleData(id);

            item.InitTitleData(data);
            items.Add(item);
            item.gameObject.name = $"{rd}--{rd1}";
        }
    }

    public void SpawmTrans()// sinh ra vi tri
    {
        for (int i = 0; i < Title; i++)
        {
            titleTrans.Add(Main.transform.GetChild(i));
        }
    }

    public void SpawmImgItem(List<SpriteRenderer> ava, List<int> id)
    {
        ava[0].sprite = _spriteValue[id[0]]; 
        ava[1].sprite = _spriteValue[id[1]];
    }

    public void CheckWin()
    {
        if (items.Count == 0)
        {
            Debug.LogError("Win");
        }
    }
}
