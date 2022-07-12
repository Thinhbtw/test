using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHealth : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField]int curHealth;
    [SerializeField] WInCondition wInCondition;
    public bool Winning, runProgress;
    Rigidbody2D rb;
    LevelComplete myScript;
    UIGameplay uiGameplay;

    private static FishHealth instance;
    public static FishHealth Instance => instance;


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            instance = this;

        curHealth = StaticClass.startHealth;
        rb = GetComponent<Rigidbody2D>();
        Winning = false;
    }

    private void OnEnable()
    {
        myScript = GameObject.FindObjectOfType<LevelComplete>();
        uiGameplay = FindObjectOfType<UIGameplay>();
        
    }

    void Start()
    {
        
        animator.SetLayerWeight(1, 0);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Poison")
        {
            animator.Play(StaticClass.Fish_clipDie);
            myScript.setGameEnd(false);
            UiEnd.Instance.DieWhenWinning();
            if (Winning)
                 uiGameplay.levelAt = uiGameplay.levelAt - 1;

        }

        if (curHealth > 0)
        {
            if (collision.gameObject.tag == "Lava")
            {
                animator.Play(StaticClass.Fish_clipHurt, -1, 0f);
                curHealth = Mathf.Clamp(curHealth - 1, 0, StaticClass.startHealth);
                Destroy(collision.gameObject);


            }
        }

        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Boulder" || collision.gameObject.tag == "Spike" || collision.gameObject.tag == "IceBlock")
        {
            animator.SetLayerWeight(1, 0);
            animator.Play(StaticClass.Fish_clipDie);
            myScript.setGameEnd(false);
            UiEnd.Instance.DieWhenWinning();
            if (Winning)
                uiGameplay.levelAt = uiGameplay.levelAt - 1;

        }

        if (collision.gameObject.tag == "Bomb")
        {
            animator.SetLayerWeight(1, 0);
            animator.Play(StaticClass.Fish_clipBurn);
            myScript.setGameEnd(false);
            UiEnd.Instance.DieWhenWinning();
            if (Winning)
                uiGameplay.levelAt = uiGameplay.levelAt - 1;
        }
    }

    public IEnumerator ProgressBar()
    {
        yield return new WaitForSeconds(3.35f);
        uiGameplay.levelAt++;
    }


    // Update is called once per frame
    void Update()
    {

        if (wInCondition.count >= StaticClass.WinningCondition && !myScript.isDed)
        {
            runProgress = true;
            animator.Play(StaticClass.Fish_clipWin);
            animator.SetLayerWeight(1, 1);

            Winning = true;
            myScript.setGameEnd(true);
            if(runProgress)
            {         
                StartCoroutine(ProgressBar());
                runProgress = false;
            }
            wInCondition.count = 0;
        }

        if (curHealth == 0)
        {
            
            animator.Play(StaticClass.Fish_clipBurn);
            if (!myScript.check)
            {
                myScript.setGameEnd(false);
                UiEnd.Instance.DieWhenWinning();
            }
            animator.SetLayerWeight(1, 0);
            if (Winning)
                uiGameplay.levelAt = uiGameplay.levelAt - 1;
        }
        
    }
}
