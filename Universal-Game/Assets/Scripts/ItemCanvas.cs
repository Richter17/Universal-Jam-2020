using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCanvas : MonoBehaviour
{
    public List<Image> items;
    public int count;
    public Image prefab;

    public void Show(int size)
    {
        count = 0;
        for (int i = 0; i < size; i++)
        {
            Image img = Instantiate(prefab, transform.GetChild(0));
            items.Add(img);
        }
    }

    public void DeleteItem()
    {
        items[count].color = Color.black;
        count++;
    }
}
