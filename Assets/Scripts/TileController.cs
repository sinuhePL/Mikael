﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private int tileId;
    // Start is called before the first frame update

    public void InitializeTile(int i)
    {
        tileId = i;
    }

    private void OnMouseDown()
    {
        EventManager.RaiseEventOnTileClicked(tileId);
    }
}