using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTitle : MonoBehaviour
{
    public List<ItemTitle> bonusTitle = new List<ItemTitle>();

    [SerializeField] ItemTitle titlePrefabs;

    [SerializeField] List<Transform> _bonusTitleTrans;

    [SerializeField] SlotHolder slotHolder;

    [SerializeField] GameObject _addTile;
    [SerializeField] AddBonusTitle _addBonusTitle;

    private int bonusTitleNumber = 3;


    private void Start()
    {
        ActionEvent.OnAddBonusTitle += AddBonusTitle;
        AddBonusTitle();
    }

    private void OnDestroy()
    {
        ActionEvent.OnAddBonusTitle -= AddBonusTitle;
    }

    public void AddBonusTitle()
    {
        for (int i = 0; i < bonusTitleNumber; i++)
        {
            int rd = Random.Range(0, TitleManager.Instance._spriteValue.Count);
            int rd1 = Random.Range(0, TitleManager.Instance._spriteValue.Count);
            List<int> id = new List<int> { rd, rd1 };
            ItemTitle item = Instantiate(titlePrefabs, _bonusTitleTrans[i]);

            ItemTitleData data = new ItemTitleData(id, new Vector2Int(0, 0));

            item.InitTitleData(data, TitleManager.Instance._spriteValue);
            bonusTitle.Add(item);
            item.type = Type.AddTile;
        }
        //  _addBonusTitle.ResetPos();
        _addTile.gameObject.SetActive(false);
    }

    public void OnclickNewTitle(ItemTitle title)
    {
        bonusTitle.Remove(title);
        if (bonusTitle.Count == 0)
        {
            //_addBonusTitle.ResetPos();
            Debug.LogError("het bai");
            _addTile.gameObject.SetActive(true);
            return;
        }
        _addTile.gameObject.SetActive(false);
        //  slotHolder.AddItemToSlot(title);

    }
}
