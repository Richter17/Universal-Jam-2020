using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCanvas : MonoBehaviour
{
    private List<IconItem> items;
    public int count;
    public IconItem prefab;

    public void Show(int size)
    {
        items = new List<IconItem>();
        count = 0;
        for (int i = 0; i < size; i++)
        {
            IconItem img = Instantiate(prefab, transform.GetChild(0));
            items.Add(img);
        }
    }

    public void DeleteItem()
    {
        items[count].Change();
        count++;
    }
}
