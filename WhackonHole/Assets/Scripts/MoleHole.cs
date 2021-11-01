using System.Collections;
using UnityEngine;

public class MoleHole : MonoBehaviour
{
    //possible state enum
    public enum MoleState
    {
        down,
        preparing,
        up,
        hit,
        receding,
        inactive,
        gameEnd
    
    }

    //important state variables (current state, good or bad mole)
    public MoleState state;
    private bool civilian = false;

    /// component and manager references
    private GameManager gm;
    private SpriteRenderer sr;
    private Animator anim;
    private AudioSource audioSource;

    //gameplay variables
    public float hideTimeMin;
    public float hideTimeMax;
    public float prepTimeMin;
    public float prepTimeMax;
    public float upTimeMin;
    public float upTimeMax;

    //sounds
    public AudioClip SFX_hitGood;
    public AudioClip SFX_hitBad;

    //score variables
    private int hitScore = 100;
    private int civilianPenalty = 50;

    //prefabs to spawn on hit
    public GameObject bonusSprite;
    public GameObject penaltySprite;
    
    // Start is called before the first frame update
    void Start()
    {
        //store references
        gm = GameManager.instance;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //turn off mole til game start
        state = MoleState.inactive;
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //update animator parameters
       anim.SetBool("CivilianParam", civilian);
       anim.SetInteger("stateEnum", (int)state);
    }

    void PopUp()
    {
        //25% chance of being a mole you don't wanna hit.
        float rand = Random.value;
        if (rand < .25f)
        {
            civilian = true;
        }
        
        state = MoleState.up;

        //set a random time as to when to go back down
        StartCoroutine(changeState(Random.Range(upTimeMin, upTimeMax)));
    }

    public void GetHit()
    {
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPos.z = 0;
        spawnPos += new Vector3(1, 1, 0);

        //cancel any calls to change state in the future
        StopAllCoroutines();

        //decide how to affect score and what FX to play
        if (civilian)
        {
            gm.score -= civilianPenalty;
            audioSource.PlayOneShot(SFX_hitBad);
            Instantiate(penaltySprite, spawnPos, Quaternion.identity);
        }
        else
        {
            gm.score += hitScore;
            audioSource.PlayOneShot(SFX_hitGood);
            Instantiate(bonusSprite, spawnPos, Quaternion.identity);
        }

        //stay in hit frame for a sec
        state = MoleState.hit;
        StartCoroutine(changeState(1f));
    }

    public void Hide()
    {
        //reset stuff
        civilian = false;
        sr.enabled = false;
        state = MoleState.down;
        StartCoroutine(changeState(Random.Range(hideTimeMin, hideTimeMax)));
    }

    void Prep()
    {
        //get ready to pop up
        sr.enabled = true;
        state = MoleState.preparing;
        StartCoroutine(changeState(Random.Range(prepTimeMin, prepTimeMax)));
    }

    void Recede()
    {
        state = MoleState.receding;
        //no need to start coroutine here,
        //Hiding is triggered by an Animation Event in the recede animation.
    }

    public void OnGameEnd()
    {
        StopAllCoroutines();
        sr.enabled = true;
        state = MoleState.gameEnd;
    }

    void OnMouseDown()
    {
        if (state == MoleState.up)
        {
            GetHit();
        }
    }

    public IEnumerator changeState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (GameManager.instance.GetGameMode() == GameManager.GameMode.end)
        {
            state = MoleState.gameEnd;
           
        }
        else
        {
            switch (state)
            {
                case MoleState.down:
                    Prep();
                    break;
                case MoleState.preparing:
                    PopUp();
                    break;
                case MoleState.up:
                    Recede();
                    break;
                case MoleState.hit:
                    Recede();
                    break;
                case MoleState.receding:
                    Hide();
                    break;
            }
        }
    }
}
