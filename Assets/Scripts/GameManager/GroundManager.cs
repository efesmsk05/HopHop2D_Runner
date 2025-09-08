using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundManager : MonoBehaviour
{
    public static GroundManager instance;
    private GameObject destructibleGround;
    GameObject moveBox;
    public GameObject obstacleGameObject;
    public GameObject coinGameObject;
    public GameObject dirt›mg;
    public GameObject donwDirt›mg;
    public Sprite down;
    public Sprite normal;


    public GameObject colider;
   
    BoxCollider2D groundCollider;
    public float screenRight;
    public float groundHeight;
    public  float groundRight;

    public bool isGeneratable;
    public bool isSpawnable;

    [SerializeField] private float ObstacleNum;

    float timer;

    float downTimer;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        groundCollider = GetComponent<BoxCollider2D>(); 
        screenRight = Camera.main.transform.position.x + 10f;
        groundHeight = transform.position.y + (groundCollider.size.y / 2);

        isGeneratable = false;

    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x -= (PlayerManager.instance.accelerationXvelocity.x/6f) * Time.deltaTime;

        groundRight = transform.position.x + (groundCollider.size.x / 2);

        // spawn Control
        SpawnCheck();


        // destroy
        if(groundRight < -screenRight)
        {
            Destroy(gameObject);
            return;
        }




        transform.position = pos;

        



    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;


        if (PlayerManager.instance.isTouchDownTag == true)
        {
            downTimer += Time.deltaTime;

            if (this.gameObject.tag == "Down")
            {
                Vector2 downpos = this.transform.position;
                downpos.y -= 8.5f * Time.deltaTime;


                this.transform.position = downpos;

                PlayerManager.instance.isTouchDownTag = false;

            }
            else
            {
                this.transform.position = pos;
            }


        }
    }

    public void SpawnCheck()
    {
        if (!isGeneratable)
        {

            if (groundRight < screenRight)
            {
                isSpawnable = true;

                isGeneratable = true;
                //generateGround();


            }
            else
            {
                isSpawnable = false;
            }

        }
    }


    public  void generateGround()
    {
        moveBox = Instantiate(gameObject);
        BoxCollider2D moveBoxColider = GetComponent<BoxCollider2D>();
        Vector2 boxPos;


        // random tag chance




        // y random range height 
        float maxHeight = PlayerManager.instance.transform.position.y - (moveBoxColider.size.y / 2 ) + (PlayerManager.instance.jumpPower/1.7f) * 0.001f;
        float trueHeight = Mathf.Clamp(maxHeight, -7f,-2f);
        float minHeight = -7f;

        int tagChance = Random.Range(0, 101);
        if (tagChance < 15)
        {
            // down tag
            if(PlayerManager.instance.accelerationXvelocity.x > 67f)
            {
                moveBox.gameObject.tag = "Down";
                moveBox.GetComponentInChildren<SpriteRenderer>().sprite = down;// sprite change

                //down y pos limitation
                minHeight = -4.9f;
                maxHeight -= .5f;


            }


        }


        boxPos.y = Random.Range(minHeight, trueHeight);

        // x random distance
        
        float minx = screenRight + 9f;
        float maxX = (minx + 1)+ (PlayerManager.instance.accelerationXvelocity.x * 0.05f)+ 1f;

        float trueDistance = Random.Range(minx,maxX);

        boxPos.x = trueDistance;


        moveBox.transform.position = boxPos;





        if (tagChance > 20) // obstacle and normal ground
        {
            // normal tag
            moveBox.GetComponentInChildren<SpriteRenderer>().sprite = normal;

            moveBox.gameObject.tag = "Normal";
            moveBox.GetComponentInChildren<SpriteRenderer>().color = Color.white;



            float coinNum = Random.Range(0, 2);
            if(PlayerManager.instance.accelerationXvelocity.x > 60f)// early obstacle Control
            {
                ObstacleNum = Random.Range(0, 3);

            }
            else
            {
                ObstacleNum = Random.Range(0, 2);

            }

            for (int x = 0; x < ObstacleNum; x++)
            {

                GameObject obstacle = Instantiate(obstacleGameObject.gameObject);
                float obstacleY = moveBox.transform.position.y + (moveBoxColider.size.y / 2) + 1f;
                float groundHalfWidht = moveBox.transform.position.x; // ground orta nokta
                float left = groundHalfWidht - 2f;
                float right = groundHalfWidht + 2f;
                float obstacleX = Random.Range(left, right);

                Vector2 obstaclePos = new Vector2(obstacleX, obstacleY);

                obstacle.transform.position = obstaclePos;
            }

            for (int x = 0; x < coinNum; x++)
            {
                GameObject coin = Instantiate(coinGameObject.gameObject);
                float coinMaxY = moveBox.transform.position.y + (moveBoxColider.size.y / 2) + 4.5f;
                float cowMinY = moveBox.transform.position.y + (moveBoxColider.size.y / 2) + 3f;

                float coinY = Random.Range(cowMinY,coinMaxY);
                float groundHalfWidht = moveBox.transform.position.x; // ground orta nokta
                float left = groundHalfWidht - 6f;
                float right = groundHalfWidht + 6f;
                float coinX = Random.Range(left, right);


                Vector2 coinPos = new Vector2(coinX, coinY);



                coin.transform.position = coinPos;


            }

        }

    }


}
