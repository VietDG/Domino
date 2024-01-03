using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonMonoBehaviour<SlotManager>
{
    [SerializeField] SlotHolder _holder;
    [SerializeField] BonusTitle _bonusTitle;

    private ItemTitle itemTitle;

    public void AddItemToSlot(ItemTitle title)
    {
        this.itemTitle = title;

        if (_holder.titleSlot.type == Type.NGANG)
        {
            Debug.Log("Ngang");
            TypeHorizontal(title);
            return;
        }

        if (_holder.titleSlot.type == Type.DOC)
        {
            Debug.Log("Doc");
            TypeVertical(title);
        }
    }

    public void InitSlot(int id)//data slot
    {
        Debug.LogError(id);
        _holder.InitTitleDataToSlot(itemTitle);
        _holder.titleSlot.data.ID[0] = id;
        _holder.titleSlot.data.ID[1] = id;

        _holder.titleSlot.InitTitleData(_holder.titleSlot.data, TitleManager.Instance._spriteValue);
    }

    public void AddTileBooster(ItemTitle itemTitle)
    {
        itemTitle.type = Type.NGANG;
        _holder.InitTitleDataToSlot(itemTitle);
        _holder.RemoveDataFormList(itemTitle, true);

        _holder.titleSlot.InitTitleData(_holder.titleSlot.data, TitleManager.Instance._spriteValue);

        _bonusTitle.OnclickNewTitle(itemTitle);
    }

    private void TypeHorizontal(ItemTitle title)
    {
        if (title.data.ID[0] == _holder.titleSlot.data.ID[0] && title.data.ID[1] == _holder.titleSlot.data.ID[1])
        {
            title.type = Type.NGANG;
            _holder.RemoveDataFormList(itemTitle, true);
            TitleManager.Instance.CheckWin();
            InitSlot(title.data.ID[0]);
            Debug.Log(3);
            return;
        }
        Debug.LogWarning($"{title.data.ID[0] == _holder.titleSlot.data.ID[0]}-----1{title.data.ID[0] == _holder.titleSlot.data.ID[1]}");
        if (title.data.ID[0] == _holder.titleSlot.data.ID[0] || title.data.ID[0] == _holder.titleSlot.data.ID[1])
        {
            RemoveTitle(title);
            InitSlot(title.data.ID[1]);
            Debug.Log(1);
            return;
        }
        Debug.LogWarning($"{title.data.ID[1] == _holder.titleSlot.data.ID[0]}-----2{title.data.ID[1] == _holder.titleSlot.data.ID[1]}");

        if (title.data.ID[1] == _holder.titleSlot.data.ID[0] || title.data.ID[1] == _holder.titleSlot.data.ID[1])
        {
            RemoveTitle(title);
            InitSlot(title.data.ID[0]);
            Debug.Log(2);
        }
    }

    #region Type Dọc
    private void TypeVertical(ItemTitle title)
    {
        if (title.data.ID[0] == _holder.titleSlot.data.ID[0] && title.data.ID[1] == _holder.titleSlot.data.ID[1])
        {
            title.type = Type.NGANG;
            _holder.RemoveDataFormList(itemTitle, true);
            TitleManager.Instance.CheckWin();
            InitSlot(title.data.ID[0]);
            return;
        }

        foreach (var item in title.data.ID)
        {
            if (_holder.titleSlot.data.ID[0] == item)
            {
                RemoveTitle(title);
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
    #endregion

    private void RemoveTitle(ItemTitle title)
    {
        _holder.RemoveDataFormList(title, false);
        TitleManager.Instance.CheckWin();
    }
}
