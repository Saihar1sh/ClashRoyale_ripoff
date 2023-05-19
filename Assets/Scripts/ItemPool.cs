using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : GenericPoolService<ItemPool> 
{
    protected override ItemPool CreateItem()
    {
        //creating items
        return base.CreateItem();
    }
}
