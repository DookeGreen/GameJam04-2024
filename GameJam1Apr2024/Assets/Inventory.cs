using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodTXT;
    [SerializeField] private TextMeshProUGUI fishTXT;
    [SerializeField] private TextMeshProUGUI coockedfishTXT;
    [SerializeField] private GameObject[] Items;

    public string EquippedItem;
    public int woodQuantity;
    public int fishQuantity;
    public int coockedfishQuantity;
    private float scrollDelta;

    void Update()
    {
        woodTXT.text = woodQuantity.ToString();
        fishTXT.text = fishQuantity.ToString();
        coockedfishTXT.text = coockedfishQuantity.ToString();

        for (int i = 0; i < Items.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i < Items.Length)
            {
                SetEquippedState(i);
            }
        }
        scrollDelta = -10 * Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta != 0)
        {
            int currentIndex = GetEquippedIndex();
            int newIndex = (currentIndex + Mathf.RoundToInt(scrollDelta)) % Items.Length;
            if (newIndex < 0)
                newIndex = Items.Length - 1;
            SetEquippedState(newIndex);
        }
    }

    void SetEquippedState(int equippedIndex)
    {
        EquippedItem = Items[equippedIndex].name;

        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].GetComponent<Equipped>().equipped = (i == equippedIndex);
        }
    }
    int GetEquippedIndex()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].GetComponent<Equipped>().equipped)
            {
                return i;
            }
        }
        return -1; // No equipped item found
    }
}
