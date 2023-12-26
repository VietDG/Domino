using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private TitleManager _titleManager;
    public TitleManager TitleManager => _titleManager;
}

