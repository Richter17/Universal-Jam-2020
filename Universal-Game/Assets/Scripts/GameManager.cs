using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public List<Item> items;
    public ItemCanvas itemCanvas;
    public bool gameOver = false;
    public Spaceship spaceship;
    public GameObject wonPanel;
    public GameObject diePanel;

    // Start is called before the first frame update
    void Start()
    {
        player.ItemCollected += OnItemCollected;
        player.VisitSS += OnVisit;
        player.playerOxygen.PlayerDied += OnPlayerDeath;
        itemCanvas.Show(items.Count);
        player.transform.position = spaceship.transform.position;
    }

    private void OnPlayerDeath()
    {
        Debug.Log("GAME OVER");
        diePanel.SetActive(true);
    }

    private void OnItemCollected(int id)
    {
        Item item = items.Find(i => i.id == id);
        if (!item) return;
        Debug.Log("Player collected item: " + id);
        item.gameObject.SetActive(false);
        itemCanvas.DeleteItem();
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
            wonPanel.SetActive(true);
            player.playerOxygen.isCounting = false;
        }
    }

    public void OnExitClick()
    {
        ScenesManager.LoadScene(0);
    }

    public void OnReturnClick()
    {
        ScenesManager.ReloadScene();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
