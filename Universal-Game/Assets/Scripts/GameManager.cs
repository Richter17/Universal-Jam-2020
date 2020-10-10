using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public List<Item> items;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        player.ItemCollected += OnItemCollected;
        player.VisitSS += OnVisit;
        player.playerOxygen.PlayerDied += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        Debug.Log("GAME OVER");
        Debug.Log("YOU LOST");
    }

    private void OnItemCollected(int id)
    {
        Debug.Log("Player collected item: " + id);
        Item item = items.Find(i => i.id == id);
        if (!item) return;
        item.gameObject.SetActive(false);
        items.Remove(item);
        if (items.Count == 0)
        {
            Debug.Log("all items found");
            gameOver = true;
        }
    }

    private void OnVisit()
    {
        Debug.Log("Player visit the spaceship");
        if (gameOver)
        {
            Debug.Log("Player won");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
