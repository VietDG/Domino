using DG.Tweening;
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

    //public void Movement(Vector3 target, Transform trans, System.Action callBack)
    //{
    //    Vector3 thisPos = this.transform.position;
    //    float height = (thisPos - target).magnitude / 4;
    //    Vector3 direc = (thisPos - target).normalized;
    //    Vector3 topPos = (thisPos + target) / 2 + new Vector3(-direc.y, direc.x) * height;

    //    this.transform.DOScale(0.7f, _duration);
    //    this.transform.DORotate(new Vector3(0, 0, 360), 1.4f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    //    this.transform.DOPath(new Vector3[] { thisPos, topPos, target }, _duration, PathType.CatmullRom).OnComplete(() =>
    //    {
    //        SoundManager.Instance.PlaySfxRewind(GlobalSetting.GetSFX("bling"));
    //        vfx.SetActive(true);
    //        trans.DOPunchScale(new Vector2(1.1f, 1.1f), 0.1f).SetEase(Ease.OutElastic).OnComplete(() =>
    //        {
    //            this.gameObject.SetActive(false);
    //            callBack?.Invoke();
    //        });
    //    });
    //}
}
