using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary : MonoBehaviour
{
    [SerializeField]
    private List<Item> ItemCollection;

    private void Awake()
    {
        //ItemCollection = new List<Item>();
        //GenerateItem(new Item { itemID=0, itemName="Apple", itemDescription="A red apple", itemCount=1});
        //GenerateItem(new Item { itemID=1, itemName="Red Potion", itemDescription="A red potion that seems to heal the person who drinks it", itemCount=1});
        //GenerateItem(new Item { itemID=2, itemName="Blue Potion", itemDescription="A blue potion that seems to give magical energy to who drinks it", itemCount=1});
        //GenerateItem(new Item { itemID=3, itemName="Long Sword", itemDescription="A iron long sword", itemCount=1});
        //GenerateItem(new Item { itemID=4, itemName="Kiteshield", itemDescription="A iron kiteshield", itemCount=1});
    }

    private void GenerateItem(Item item)
    {
        ItemCollection.Add(item);
    }

    public Item getItemById(int itemID)
    {
        return ItemCollection[itemID];
    }

    public Item getItemByIndex(int Index)
    {
        return ItemCollection[Index];
    }

    public List<Item> getItemCollection()
    {
        return ItemCollection;
    }

    public int GetCollectionCount()
    {
        return ItemCollection.Count;
    }

    public void AddToCollection(Item item)
    {
        ItemCollection.Add(item);
    }

    public int GetLastIndex()
    {
        return ItemCollection.Count - 1;
    }

    public void RemoveLast()
    {
        ItemCollection.RemoveAt(ItemCollection.Count-1);
    }
}
