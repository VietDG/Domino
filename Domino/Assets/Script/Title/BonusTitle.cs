using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTitle : MonoBehaviour
{
    public List<ItemTitle> bonusTitle = new List<ItemTitle>();

    [SerializeField] ItemTitle titlePrefabs;

    [SerializeField] Transform _bonusTitleTrans;

    [SerializeField] SlotHolder slotHolder;

    private int bonusTitleNumber = 3;


    private void Start()
    {
        //   AddBonusTitle();
    }

    public void AddBonusTitle()
    {
        for (int i = 0; i < bonusTitleNumber; i++)
        {
            int rd = Random.Range(0, TitleManager.Instance._spriteValue.Count);
            int rd1 = Random.Range(0, TitleManager.Instance._spriteValue.Count);
            List<int> id = new List<int> { rd, rd1 };
            ItemTitle item = Instantiate(titlePrefabs, _bonusTitleTrans);
            ItemTitleData data = new ItemTitleData(id);

            item.InitTitleData(data, TitleManager.Instance._spriteValue);
            bonusTitle.Add(item);
        }
    }

    public void OnclickNewTitle(ItemTitle title)
    {
        bonusTitle.Remove(title);
        //  slotHolder.AddItemToSlot(title);
    }
}
