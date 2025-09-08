using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;   

    [SerializeField]public  Rigidbody2D rb;
    public Vector2 velocity;
    public Vector2 accelerationXvelocity;
    public Vector2 vecGravity;

    public Transform groundCheckTransform;
    public Transform ObstacleToucTransform;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;


    [Header("Jump System")]
    public float fallMultiplier;
    public float jumpMultiplier;
    [SerializeField] public float jumpPower = 10f;
    public float jumpTimer;
    float jumpCounter;
    bool isJumping;
    bool _isGrounded;


    [Header("Velocity X Accelaration")]
    float acceleration = 10f;
    float maxVelocityX = 105f;
    float maxAcceleration = 10f;
    public float distance = 0f;

    [Header("Players")]
    public GameObject[] players;
    public static bool standartColor;
    public static bool blueColor;
    public static bool pinkColor;
    public static bool bronwColor;
    public static bool spacielColor;

    // obstacle trriger
    public bool isTriggered = false;
    public bool isTouchDownTag = false;

    //coin trriger
    public bool coinTouched = false;

    //game Over
    public bool gameOver = false;

    public bool coinSound;

    //Dobule Jump
    public static bool doubleTapActive = false;
    bool doubleJumpTimer = false;
    public static float doubleJumpCounter = 10;
    public static float doubleJumpSecond;
    public static int level; 


    private void Awake()
    {
        if(instance == null)
            { instance = this; }

        doubleJumpLevel();

    }

    void Start()
    {
        print(level);
        rb = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);

        doubleJumpCounter = doubleJumpSecond;
        ChangePlayerColor();
    }

    void Update()
    {
        doubleJumpLevel();

        MoveVector();
        Acceleration();

        distance += accelerationXvelocity.x/2f * Time.deltaTime;

        if(doubleTapActive == true)
        {
            if (doubleJumpTimer == true) // Double Jump Timer // Stamina Stage
            {
                while (doubleJumpCounter > 0)
                {
                    doubleJumpCounter -= Time.deltaTime;
                    
                    return;
                }
                doubleJumpTimer = false;
                doubleJumpCounter = doubleJumpSecond;
            }
        }


    }
    void FixedUpdate()
    {
        isGrounded();

        gameOverControl();

    }

    void MoveVector()
    {
        //Dobule Tap for Double Jump

        if(doubleTapActive == true)
        {
            if (doubleJumpTimer == false)
            {
                if (Input.touchCount == 1) // double tap control
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (isGrounded() == false) // double jump
                        {
                            isJumping = false;
                            rb.velocity = new Vector2(velocity.x, jumpPower + 5f);
                            jumpCounter = 0f;

                            doubleJumpTimer = true;
                        }
                    }
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded()) // tuþa basýnca 
        {
            isJumping = true;
            rb.velocity = new Vector2(velocity.x , jumpPower );
            jumpCounter = 0f;


        }





        if (rb.velocity.y < 0)// düþme anýnda
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }

        if(rb.velocity.y > 0 && isJumping) // jump timer
        {
            jumpCounter += Time.deltaTime;

            if (jumpCounter > jumpTimer)
            {
                isJumping = false;
            }

            float t = jumpCounter / jumpTimer; // yavaþ artýyor
            float currentJumpM = jumpMultiplier; 

            if(t > .5f)
            {
                currentJumpM = jumpMultiplier * (1 - t); // yarým saniye sonra karakter daha yavaþ yukarý çýkýyor yukarý çýktýkça hýzýmýz azalýyor
            }

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;

        }

        if(Input.GetKeyUp(KeyCode.Mouse0)) // tuþu býraktýðýn zaman
        {
            isJumping = false;
            jumpCounter = 0f;

            // tuþu býraktýðýnda karakter yerden yüksekteyse daha hýzlý yere düþmesini saðlýyor (yükselme anýndaysa)
            if(rb.velocity.y > 0f) 
            {
                rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y * .6f);
            }
        }

    }

    void Acceleration()// giderek yavaþlayan hýzlanma fnc
    {
        float velocityRatio = accelerationXvelocity.x / maxVelocityX; // hýzlanma oraný 


        acceleration = maxAcceleration * (1 -velocityRatio);// gittikçe azalýyor

        jumpMultiplier += acceleration / 100f * Time.deltaTime;// zaman ilerledikçe zýplama gücün hýza baðlý olarak artýyor
        //print(jumpMultiplier);

        accelerationXvelocity.x += acceleration * Time.deltaTime;
        if(accelerationXvelocity.x >= maxVelocityX)
        {
            accelerationXvelocity.x = maxVelocityX;
        }

    }
    public bool isGrounded()
    {
        _isGrounded = Physics2D.OverlapCapsule(groundCheckTransform.position, new Vector2(0.33f, .20f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        return _isGrounded;
    }


    // trigger collision side
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            accelerationXvelocity.x -= accelerationXvelocity.x * 0.25f;

            isTriggered = true;
            
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinTouched = true;
            coinSound = true;

        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {
            isTouchDownTag = true;
        }

    }

    // player color store ui Control State

    public void ChangePlayerColor()
    {
        if(standartColor == true)
        {

            players[0].SetActive(true);
        }

        if(blueColor == true)
        {
            standartColor = false;
            players[0].SetActive(false);
            players[1].SetActive(true);

        }
        else
        {
            standartColor = true;
            players[0].SetActive(true);
            players[1].SetActive(false);

        }
        
        if(pinkColor == true)
        {
            standartColor= false;
            blueColor = false;
            spacielColor = false;
            bronwColor = false;


            for (int i = 0; i < 2; i++)
            {
                players[i].SetActive(false);

            }

            players[2].SetActive(true);

        }

        if(bronwColor == true)
        {
            standartColor = false;
            blueColor= false;
            pinkColor = false;
            spacielColor = false;

            for (int i = 0; i < 3; i++)
            {
                players[i].SetActive(false);

            }
            players[3].SetActive(true);

        }

        if(spacielColor == true)
        {

            standartColor = false;
            blueColor = false;
            pinkColor = false;
            bronwColor = false;


            for (int i = 0; i < 4; i++)
            {
                players[i].SetActive(false);

            }
            players[4].SetActive(true);
        }


    }

    public void doubleJumpLevel()
    {
        switch(level)
        {
            case 0:
                //double jump time
                doubleJumpSecond= 10;

                break;

            case 1:
                doubleJumpSecond = 7;



                break;

            case 2:
                doubleJumpSecond = 5;


                break;

            case 3:
                doubleJumpSecond = 3;

                break;

        }


    }



    void gameOverControl()
    {
        if(transform.position.y < Camera.main.transform.position.y - 9f)
        {
            print("game over");
            gameOver = true;

        }
    }


}
