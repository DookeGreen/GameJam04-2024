using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnPressE : MonoBehaviour
{
    public GameObject Game;
    public GameObject Player;
    public GameObject ExclamationPoint;
    public string NecessaryEquippedItem;
    private int Activity;
    public int ActivityNum;
    public object ScriptName;
    public float timer;
    public bool done = true;
    private float currentTimer;
    private GameObject spawnedObject;
    private GameObject exclamation;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] private int score;
    public TextMeshProUGUI ErrorTXT;
    private bool timerStart;
    private bool timerDone = false;
    private bool GameStart;
    private float currentTimer2;
    private float timer2 = 0.5f;
    private bool timerStart2;
    private bool timerDone2 = false;
    private bool SpawnedExlamation = false;
    // Update is called once per frame
    void Update()
    {
        if(timerStart && currentTimer < timer)
        {
            currentTimer += Time.deltaTime;
        }
        else if(currentTimer >= timer){
            timerStart = false;
            timerDone = true;
        }
        if(timerStart2 && currentTimer2 < timer2)
        {
            currentTimer2 += Time.deltaTime;
        }
        else if(currentTimer2 >= timer2){
            timerStart2 = false;
            timerDone2 = true;
        }
        if(timerDone2 && !GameStart)
        {
            GameStart = true;
            Destroy(exclamation);
            spawnedObject = Instantiate(Game, transform);
        }
        if(timerDone && timer > 0f && !SpawnedExlamation)
        {
            SpawnedExlamation = true;
            if(ExclamationPoint != null)
            {
                timerStart2 = true;
                exclamation = Instantiate(ExclamationPoint, transform);
                Activity = 4;
                transform.parent.GetComponentInChildren<Animator>().SetInteger("Activity", Activity);
            }
            timerDone = false;
        }
        if(Input.GetKeyDown(KeyCode.E) && done && transform.parent.GetComponent<Inventory>().EquippedItem == NecessaryEquippedItem)
        {
            Activity = ActivityNum;
            if(transform.parent.GetComponent<Inventory>().EquippedItem == "Pan")
            {
                if(transform.parent.GetComponent<Inventory>().fishQuantity > 0)
                {
                    transform.parent.GetComponentInChildren<Animator>().SetInteger("Activity", Activity);
                    done = false;
                    GameStart = false;
                    Player.GetComponent<PlayerMovement>().canMove = false;
                    sr.enabled = false;
                    timerStart = true;
                    if(timer == 0f)
                    {
                        spawnedObject = Instantiate(Game, transform);
                    }
                }
                else
                {
                    ErrorTXT.text = "Not enough fish!";
                }

            }
            else
            {
                transform.parent.GetComponentInChildren<Animator>().SetInteger("Activity", Activity);
                done = false;
                GameStart = false;
                Player.GetComponent<PlayerMovement>().canMove = false;
                sr.enabled = false;
                timerStart = true;
                if(timer == 0f)
                {
                    spawnedObject = Instantiate(Game, transform);
                }
            }

        }
        else if(Input.GetKeyDown(KeyCode.E) && done)
        {
            ErrorTXT.text = "Wrong item equipped!";
        }
        if(spawnedObject != null)
        {
            if(spawnedObject.GetComponentInChildren<WoodCutting>() != null)
            {
                if((spawnedObject.GetComponentInChildren<WoodCutting>()).finished == true)
                {
                    done = true;
                    Thing();
                }
            }
            else if(spawnedObject.GetComponentInChildren<Fishing>() != null)
            {
                if((spawnedObject.GetComponentInChildren<Fishing>()).finished == true)
                {
                    currentTimer = 0f;
                    currentTimer2 = 0f;
                    timerDone2 = false;
                    timerDone = false;
                    timerStart = false;
                    timerStart2 = false;
                    SpawnedExlamation = false;
                    GameStart = false;
                    done = true;
                    Thing();
                }
            }
            else if(spawnedObject.GetComponentInChildren<Cooking>() != null)
            {
                if((spawnedObject.GetComponentInChildren<Cooking>()).finished == true)
                {
                    done = true;
                    Thing();
                }
            }
                
        }
    }
    void Thing()
    {
        Activity = 0;
        transform.parent.GetComponentInChildren<Animator>().SetInteger("Activity", Activity);
        if(spawnedObject.GetComponentInChildren<WoodCutting>() != null)
        {
            score = spawnedObject.GetComponentInChildren<WoodCutting>().score;
            if(score % 2 == 1)
            {
                transform.parent.GetComponent<Inventory>().woodQuantity += (score + 1) / 2;
            }
            else
            {
                transform.parent.GetComponent<Inventory>().woodQuantity += (score / 2);
            }
        }
        else if(spawnedObject.GetComponentInChildren<Fishing>() != null)
        {
            score = spawnedObject.GetComponentInChildren<Fishing>().score;
            transform.parent.GetComponent<Inventory>().fishQuantity += score;
        }
        else if(spawnedObject.GetComponentInChildren<Cooking>() != null)
        {
            score = spawnedObject.GetComponentInChildren<Cooking>().score;
            transform.parent.GetComponent<Inventory>().coockedfishQuantity += score;
            transform.parent.GetComponent<Inventory>().fishQuantity -= score;
        }
        Destroy(spawnedObject);
        Player.GetComponent<PlayerMovement>().canMove = true;
        sr.enabled = true;
    }
}
