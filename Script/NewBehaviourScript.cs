using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    AudioSource StartingSound;
    Vector3 moveDirection = Vector3.zero;
    public Camera RunCam;
    public Camera TalkNPC;

    const int MinLane = -1;
    const int MaxLane = 1;
    const float LaneWidth = 1.0f;
    const float StunDuration = 0.5f;
    const int DefaultLife = 100;

   
    int targetLane;
    int life = DefaultLife;
    float recoverTime = 0.0f;
    float StartingDuration = 3.0f;
    public bool IsPause = false;
    public int TalkFlag = 0;
    public int Bonus = 0;
    public int WrongRate = 0;
    public int Coin = 0;
    public bool IsFinish = false;
    public int GetCoin=0;
    public int WrongDialogue = 0;
    public int TotalDialogue = 3;
    public GameObject Skin;
    public Material[] skin1;

    float backVol;
    float effVol;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    public bool IsNotReady()
    {
        return StartingDuration > 0;
    }

    void PlaySound(string name)
    {
        effVol = PlayerPrefs.GetFloat("effVol");
        GameObject.Find(name).GetComponent<AudioSource>().volume = effVol;
        GameObject.Find(name).GetComponent<AudioSource>().Play();
    }

    public int Life()
    {
        return life;
    }

    public bool IsStan()
    {
        return recoverTime > 0.0f || life <= 0;
    }

    public void MinusLife()
    {
        life -= 1;
    }

    public int IsTalking()
    {
        return TalkFlag;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backVol");
        effVol = PlayerPrefs.GetFloat("effVol");
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        StartingSound = GetComponent<AudioSource>();
        InvokeRepeating("MinusLife", 3f, 0.5f);
        PlaySound("BGM");
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = backVol;
        RunCam.enabled = true;
        TalkNPC.enabled = false;
        
        if (PlayerPrefs.GetInt("OnSkin1") == 1)
        {
            Skin.GetComponent<SkinnedMeshRenderer>().material = skin1[0];
        }
        else if (PlayerPrefs.GetInt("OnSkin2") == 1)
        {
            Skin.GetComponent<SkinnedMeshRenderer>().material = skin1[1];
        }
        else if (PlayerPrefs.GetInt("OnSkin3") == 1)
        {
            Skin.GetComponent<SkinnedMeshRenderer>().material = skin1[2];
        }
        else
        {
            Skin.GetComponent<SkinnedMeshRenderer>().material = skin1[3];
        }
        Coin = PlayerPrefs.GetInt("Coin");
        if (PlayerPrefs.GetInt("Speed") == 0)
        {
            speedZ = 5;
        }
        else
        {
            speedZ = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        backVol = PlayerPrefs.GetFloat("backVol");
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = backVol;
        //debug
        if (Input.GetKeyDown("left"))
            MoveToLeft();
        if (Input.GetKeyDown("right"))
            MoveToRight();
        if(Input.GetKeyDown("space"))
            Jump();

        if (IsPause == true)
        {
            Time.timeScale = 0;
        }
        else if (IsPause == false)
        {
            Time.timeScale = 1;
        }

        if (IsTalking() >0)
        {
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            RunCam.enabled = false;
            TalkNPC.enabled = true;
            CancelInvoke("MinusLife");
        }

        else if (IsNotReady())
        {
            if (StartingDuration == 3.0f){
                StartingSound.Play();
            }
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            StartingDuration -= Time.deltaTime;
        }


        else if (IsStan())
        {
            
                moveDirection.x = 0.0f;
                moveDirection.z = 0.0f;
                recoverTime -= Time.deltaTime;
            
        }

       

        else
        {
            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            
        }
        

        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded)
            moveDirection.y = 0;

        animator.SetBool("Run", moveDirection.z > 0.0f);

        if (life > 100)
            life = 100;

        if (life <= 0)
        {
            life = 0;
            animator.SetTrigger("Die");
            animator.SetTrigger("End");
        }
    }

    public void MoveToLeft()
    {
        PlaySound("ButtonSound");
        if (IsStan())
            return;
        if (controller.isGrounded && (targetLane > MinLane))
        {
            targetLane--;
        }
        
    }

    public void MoveToRight()
    {
        PlaySound("ButtonSound");
        if (IsStan())
            return;
        if (controller.isGrounded && (targetLane < MaxLane))
        {
            targetLane++;

        }
    }

    public void Jump()
    {
        PlaySound("ButtonSound");
        if (IsStan())
        {
            return;
        }
        if (controller.isGrounded)
        {

            animator.SetTrigger("Jump");
            moveDirection.y = speedJump;
        }
    }

    public void Pause()
    {
        PlaySound("ButtonSound");
        if (IsPause==false)
        {
            IsPause=true;
        }
        else
        {
            IsPause = false;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStan())
            return;
        if (hit.gameObject.tag == "Penalty")
        {
            
            life = life - 20;
            Bonus = Bonus - 10;
            WrongRate = WrongRate + 1;
            
            if (life <= 0)
            {
                animator.SetTrigger("Die");
                animator.SetTrigger("End");
            }
            recoverTime = StunDuration;
            animator.SetTrigger("Damage");
            PlaySound(hit.gameObject.name + "Sound");
            Destroy(hit.gameObject);
            
            
        }
       
        if(hit.gameObject.tag == "Coin")
        {
            life += 2;
            Bonus = Bonus + 10;
            PlaySound("Coin");
            Destroy(hit.gameObject);
            Coin = Coin + 1;
            GetCoin++;
            PlayerPrefs.SetInt("Coin", Coin);
        }

        if(hit.gameObject.tag == "Correct")
        {
            PlaySound(hit.gameObject.name + "Sound");
            life += 10;
            Bonus = Bonus + 50;
            Destroy(hit.gameObject);
            
        }

        if(hit.gameObject.tag == "TalkNPC")
        {
            TalkFlag++;
            PlaySound("FinishLine");

            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "Penalty0")
        {
            life = life - 5;
            if (life <= 0)
            {
                animator.SetTrigger("Die");
                animator.SetTrigger("End");
            }
            recoverTime = StunDuration;
            animator.SetTrigger("Damage");
            Destroy(hit.gameObject);
            PlaySound("WrongAnswer");
        }
    }
}
