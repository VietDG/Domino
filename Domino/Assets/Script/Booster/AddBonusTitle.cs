using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonusTitle : MonoBehaviour
{

    public Vector2 Lerp;

    private Vector2 _OriginalPos;

    private void OnEnable()
    {
        _OriginalPos = this.transform.position;

        this.transform.position = Lerp;

        this.transform.DOMove(_OriginalPos, 0.5f).SetEase(Ease.OutBack);
    }

    public void OnMouseDown()
    {
        ActionEvent.OnAddBonusTitle?.Invoke();

        this.transform.DOMove(_OriginalPos, 0.5f).SetEase(Ease.OutBack);
    }

    public void ResetPos()
    {
        this.transform.position = Lerp;
    }
}
