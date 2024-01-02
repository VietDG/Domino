using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonMonoBehaviour<SlotManager>
{
    [SerializeField] SlotHolder _holder;

    private ItemTitle itemTitle;

    public void AddItemToSlot(ItemTitle title)
    {
        this.itemTitle = title;

        if (_holder.titleSlot.type == Type.NGANG)
        {
            Debug.Log("Ngang");
            _holder.RemoveDataFormList(title, false);
            TitleManager.Instance.CheckWin();
            foreach (var item2 in title.data.ID)
            {
                if (_holder.titleSlot.data.ID[0] != item2)
                {
                    if (_holder.titleSlot.data.ID[0] != item2)
                    {
                        InitSlot(item2);
                        break;
                    }
                }
            }
            return;
        }
        if (_holder.titleSlot.type == Type.DOC)
        {
            Debug.Log("Doc");
            foreach (var item in title.data.ID)
            {
                if (_holder.titleSlot.data.ID[0] == item)
                {
                    _holder.RemoveDataFormList(title, false);
                    TitleManager.Instance.CheckWin();
                    foreach (var item2 in title.data.ID)
                    {
                        if (_holder.titleSlot.data.ID[0] != item2)
                        {
                            InitSlot(item2);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

    public void InitSlot(int id)//data slot
    {
        _holder.InitTitleDataToSlot(itemTitle);
        _holder.titleSlot.data.ID[0] = id;

        _holder.titleSlot.InitTitleData(_holder.titleSlot.data, TitleManager.Instance._spriteValue);
    }

    public void AddTileBooster(ItemTitle itemTitle)
    {
        this.itemTitle = itemTitle;
        itemTitle.type = Type.NGANG;
        _holder.InitTitleDataToSlot(itemTitle);

        _holder.titleSlot.InitTitleData(_holder.titleSlot.data, TitleManager.Instance._spriteValue);

        _holder.RemoveDataFormList(itemTitle, true);
    }
}
