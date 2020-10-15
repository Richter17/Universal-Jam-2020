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
    public TMPro.TextMeshProUGUI missionTxt;
    public Transform arrow;

    // Start is called before the first frame update
    void Start()
    {
        player.ItemCollected += OnItemCollected;
        player.VisitSS += OnVisit;
        player.playerOxygen.PlayerDied += OnPlayerDeath;
        itemCanvas.Show(items.Count);
        player.transform.position = spaceship.transform.position;
        
        player.gameObject.SetActive(false);
        StartCoroutine(DelayInvoke(5, delegate
        {
            missionTxt.text = "Find all Spaceship pieces.";
            player.canMove = true;
            player.gameObject.SetActive(true);
        }));
    }

    private IEnumerator DelayInvoke(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    private void OnPlayerDeath()
    {
        Debug.Log("GAME OVER");
        diePanel.SetActive(true);
        player.canMove = false;
    }

    private void OnItemCollected(int id)
    {
        Item item = items.Find(i => i.id == id);
        if (!item) return;
        Debug.Log("Player collected item: " + id);
        item.gameObject.SetActive(false);
        itemCanvas.DeleteItem();
        items.Remove(item);
        player.playerOxygen.RefillOxygen();
        if (items.Count == 0)
        {
            Debug.Log("all items found");
            missionTxt.text = "Return to spaceship ASAP!";
            gameOver = true;
        }
    }

    private void OnVisit()
    {
        Debug.Log("Player visit the spaceship");
        if (gameOver)
        {
            var ss = spaceship.transform.parent.GetComponentInChildren<SpaceshipAnimation>();
            ss.ToggleDestroyState(false);
            ss.TakeOff();
            Debug.Log("Player won");
            wonPanel.SetActive(true);
            player.playerOxygen.isCounting = false;
            player.canMove = false;
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

    private void PointArrow()
    {
        //search closest item
        float dis = float.MaxValue;
        Item i = null;
        foreach (var item in items)
        {
            float calcDis = Vector3.Distance(item.transform.position, player.transform.position);
            if(calcDis < dis)
            {
                dis = calcDis;
                i = item;
            }
        }
        if(i)
            arrow.LookAt(i.transform.position, player.transform.up);
        else
            arrow.LookAt(spaceship.transform.position, player.transform.up);

    }

    // Update is called once per frame
    void Update()
    {
        //cheats
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.playerOxygen.RefillOxygen();
        }
        PointArrow();
    }
}
