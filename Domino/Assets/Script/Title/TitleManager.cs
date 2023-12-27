using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Type
{
    NONE,
    NGANG,
    DOC
}

public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    public int Title;

    public ItemTitle titlePrefab;

    public List<ItemTitle> items = new List<ItemTitle>();

    public Transform Main;

    public SlotHolder hold;

    public List<Sprite> _spriteValue;

    private void Start()
    {
        SpawnTitle();
    }

    public void SpawnTitle()// sinh ra data
    {
        for (int i = 0; i < Title; i++)
        {
            int rd = Random.Range(0, _spriteValue.Count);
            int rd1 = Random.Range(0, _spriteValue.Count);
            List<int> id = new List<int> { rd, rd1 };

            ItemTitle item = Instantiate(titlePrefab, Main.GetChild(i));

            ItemTitleData data = new ItemTitleData(id);

            item.InitTitleData(data, _spriteValue);
            items.Add(item);
            item.gameObject.name = $"{rd}--{rd1}";
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
