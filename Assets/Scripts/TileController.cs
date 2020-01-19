﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileController : MonoBehaviour
{
    public int tileId;
    // Start is called before the first frame update

    public void InitializeTile(int i)
    {
        tileId = i;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !BattleManager.isInputBlocked)
        {
            EventManager.RaiseEventOnTileClicked(tileId);
        }
    }
}
