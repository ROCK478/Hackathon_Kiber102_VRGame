using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball_Basket : MonoBehaviour
{
    private Rigidbody rb;
    private float baseBounceForce;
    private float maxSpeed;
    public Transform player;           // Ссылка на игрока (камера)
    public float radiusFromPlayer = 1.5f;
    private float targetRadius;
    public AudioSource audioSource;
    public AudioClip[] bounceSound;
    public int bouncecount = 0;
    private int gr_touches = 0;
    public GameObject UiM;
    public UIManager UIMM;
    public int maxtouches=4;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UIMM = UiM.GetComponent<UIManager>();
        if (player == null) player = Camera.main.transform;

        SetDifficulty(GameSettings.difficultyLevel);
        targetRadius = radiusFromPlayer;
    }

    public void SetDifficulty(int level)
    {
        switch (level)
        {
            case 1: // Easy
                baseBounceForce = 3f;
                maxSpeed = 4f;
                maxtouches = 5;
                break;
            case 2: // Medium
                baseBounceForce = 3f;
                maxSpeed = 11f;
                maxtouches = 4;
                break;
            case 3: // Hard
                baseBounceForce = 3f;
                maxSpeed = 20f;
                maxtouches = 3;
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

         if (collision.gameObject.CompareTag("Ground"))
        {
            
            gr_touches++;
            if (gr_touches >= maxtouches && !GameSettings.trainingMode)
            {
                gr_touches = 0;
                if (GameSettings.isRight)
                {
                    switch (GameSettings.difficultyLevel)
                    {
                        case 1:
                            Records.easy_right_hand = math.max(bouncecount, Records.easy_right_hand);
                            break;
                        case 2:
                            Records.medium_right_hand = math.max(bouncecount, Records.medium_right_hand);
                            break;
                        case 3:
                            Records.hard_right_hand = math.max(bouncecount, Records.hard_right_hand);
                            break;
                    }
                    bouncecount=0;
                }
                else
                {
                    switch (GameSettings.difficultyLevel)
                    {
                        case 1:
                            Records.easy_left_hand = math.max(bouncecount, Records.easy_left_hand);
                            break;
                        case 2:
                            Records.medium_left_hand = math.max(bouncecount, Records.medium_left_hand);
                            break;
                        case 3:
                            Records.hard_left_hand = math.max(bouncecount, Records.hard_left_hand);
                            break;
                    }
                    bouncecount=0;
                }
                SaveLoadManager1.SaveRecords();
                UIMM.Start();
            }
            audioSource.PlayOneShot(bounceSound[Random.Range(0, bounceSound.Length)]);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f + baseBounceForce,
                rb.linearVelocity.z);
        }
        else if (collision.gameObject.name =="leftruka" || collision.gameObject.name == "rightruka")
        {
            gr_touches = 0;
            bouncecount++;
        }
        Debug.Log(collision.gameObject.name);
    }

    void FixedUpdate()
    {
        Vector3 vel = rb.linearVelocity;
        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        vel.z = Mathf.Clamp(vel.z, -maxSpeed, maxSpeed);
        vel.y = Mathf.Max(vel.y, -maxSpeed);
        rb.linearVelocity = vel;
        Vector3 fromPlayer = transform.position - player.position;
        fromPlayer.y = 0;
        fromPlayer = fromPlayer.normalized * targetRadius;
        Vector3 desiredPosition = player.position + fromPlayer;
        desiredPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * 8f);
    }

    void Update()
    {
        SetDifficulty(GameSettings.difficultyLevel);
    }
}

