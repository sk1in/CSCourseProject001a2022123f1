using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Turn manager handles the switch between players with the help of health state inclueded here.
//Forgive the complications but so is life.
public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;

    //13 as UI health bar visual items.
    //Higher float changes to slower UI only if effect is calculate to a lower rate on the collider
    [Header ("13 as start")]
    [SerializeField] public float maxHealth;
    [Header("Layer mask with items reducing health")]
    [SerializeField] private LayerMask mask;

    private int currentPlayerIndex;
    private bool waitingForNextTurn, healthWarning, once;   
    public bool ending;
    private float turnDelay, collisionTime, lastCollision, collisionRate, lastRecord, timer;
    public float currentHealth;
    SphereCollider collider;
    private float waitTime = 5.0f;

    CharacterController cc;
    Animator anim;

    static int activePlayer;

    private void Awake()
    {
        Debug.Log("001: " + instance);
        if (instance == null)
        {
            instance = this;


            Debug.Log("22-1: " + ActiveObject());



            if (PlayerPrefs.GetInt("activePlayer") != 0 )
            {
                currentPlayerIndex = PlayerPrefs.GetInt("activePlayer");
            }
            else
                currentPlayerIndex = 1;

            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
            //playerTwo.gameObject.transform.GetChild(0).GetComponent<Camera>().enabled = false;


            Debug.Log("22-1a: " + ActiveObject());
            if (GameObject.Find(ActiveObject()).name != playerTwo.name )
            {
                playerTwo.GetComponentInChildren<AnimationsManager>().enabled = false;                
            }
            else
                playerTwo.GetComponentInChildren<AnimationsManager>().enabled = true;


            if (GameObject.Find(ActiveObject()).name != playerOne.name)
            {
                playerOne.GetComponentInChildren<AnimationsManager>().enabled = false;
            }
            else
                playerOne.GetComponentInChildren<AnimationsManager>().enabled = true;
        }

        collider = GameObject.Find(ActiveObject()).GetComponentInChildren<SphereCollider>();
        //Debug.Log("22a1: " + GameObject.Find(ActiveObject()));


        //To stop player
        cc = GameObject.Find(ActiveObject()).GetComponent<CharacterController>();
        anim = GameObject.Find(ActiveObject()).transform.GetChild(0).gameObject.GetComponent<Animator>();

        collisionRate = 1.0f;
        once = true;
        //Debug.Log("22a1: " + collider.name);
    }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("22a: " + currentHealth);
        Debug.Log("22a0: " + GameObject.Find(ActiveObject()).transform.GetChild(1).transform);
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
       
        if (collider.enabled)
        {
            Debug.Log("22a2: " + collider.gameObject.tag);
        }

        ActiveObject();
        Debug.Log("22c: " + ActiveObject());


        timer += Time.deltaTime;
        Debug.Log("22a4a1ab1b : " + timer);

        if (healthWarning && timer > waitTime)
        {
            Debug.Log("22a4a1ab1ba : " + timer);
            if (timer >= 7)
            {
                ending = true;
                cc.enabled = false;
                anim.speed = 0f;


                Debug.Log("22b: " + timer);
                if (timer >= 9)
                {
                    //End game
                    Debug.Log("22ba: " + timer);
                    Debug.Log("22ca: " + instance.currentPlayerIndex);
                    ChangeTurn();
                    activePlayer = instance.currentPlayerIndex;
                    Debug.Log("22cab: " + instance.currentPlayerIndex);
                    //DontDestroyOnLoad(GameObject.Find(ActiveObject()));
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }
            }
        }
        //Use to measure collision, depending on how long the player stays colliding or how this evades the collisions. 
        float sphereR = collider.GetComponent<SphereCollider>().radius;
        if (Physics.CheckSphere(collider.transform.position, sphereR, mask))
        {
            collisionTime = Mathf.Min(collisionTime + collisionRate * Time.deltaTime, 100.0f);
            //Debug.Log("22a4a1 : " + collisionTime);
        }
        //Debug.Log("22a4a1b : " + collisionTime);
        //Debug.Log("22a4a1ab : " + lastCollision);

        if (collisionTime != lastCollision)
        {
            //Update 20fps * 13 = 260
            //Gives more or less 10 hits, 6 if too relaxed or higher if agile.
            //Cirka 6 seconds health if hit continuously  
            currentHealth -= collisionTime/260;
            Debug.Log("22a4a1ab1 : " + currentHealth);
            lastCollision = collisionTime;
           
            if (currentHealth <= 2 && once)
            {
                healthWarning = true;
                once = false;
                timer = timer - waitTime;
                Debug.Log("22a4a1ab1a : " + healthWarning);
            }

        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }
        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }
    
    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }

    public static string ActiveObject()
    {
        Debug.Log("002 : " + instance.currentPlayerIndex);

        if (instance.currentPlayerIndex == 1)
        {
            Debug.Log("003 : " + TurnManager.instance.playerOne.name);
            return TurnManager.instance.playerOne.name;
        }

        else
        {
            Debug.Log("004 : " + TurnManager.instance.playerTwo.name);
            return TurnManager.instance.playerTwo.name;
        }
    }


    void OnDisable()
    {
        Debug.Log("22d : " + activePlayer);
        PlayerPrefs.SetInt("activePlayer", activePlayer);
    }

    void OnEnable()
    {
        activePlayer = PlayerPrefs.GetInt("activePlayer");
        Debug.Log("22da : " + activePlayer);
    }

    //public void TakeDamage(float damage)
    //{
    //    currentHealth -= damage;

    //    //healthBar.fillAmount = currentHealth / maxHealth;

    //    if (currentHealth <= 0)
    //    {
    //        // Set back to initial position
    //        //transform.position = initialPosition;
    //        //transform.eulerAngles = initialRotation;

    //        Destroy(gameObject);
    //    }
    //}
}












//Scary
//anim.enabled = false;

//Still position, idle still active
//foreach (AnimatorControllerParameter parameter in anim.parameters)
//{
//    anim.SetBool(parameter.name, false);
//}
