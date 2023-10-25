using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanMove : MonoBehaviour
{
    private Pacmanmovement controls;
    public float moveSpeed = 10f;
    string move = "";
   
    // Checks
    public Transform[] checkList = new Transform[4]; // Direction checks go here, U, D, L, R
    public float distanceToWall = 0.4f; // How close the wall needs to be to register
    public LayerMask wallMask; // What layer is wall?
    public Vector2 checkSize;
    private Vector2 checkSizeH;

    public SpriteRenderer MySpriteRenderer;
    public Sprite[] PacmanSprites = new Sprite[4];

    void Awake()
    {
        checkSizeH = new Vector2(checkSize.y, checkSize.x);
        controls = new Pacmanmovement();
    }

    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }

    void HandleMovement(Vector3 direction)
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    bool CheckDirection(Transform checkPoint, bool v)
    {
        if (v)                               //Origin,           size,angle, mask
            return Physics2D.OverlapBox(checkPoint.position, checkSize, 0f, wallMask);
        else
            return Physics2D.OverlapBox(checkPoint.position, checkSizeH, 0f, wallMask);
        //return false;

    }

    // Update is called once per frame
    void Update()
    {
        if (controls.Pacman.Up.triggered)
        {
            move = "up";
            MySpriteRenderer.sprite = PacmanSprites[0];
        }
        else if (controls.Pacman.Down.triggered)
        {
            move = "down";
            MySpriteRenderer.sprite = PacmanSprites[1];
        }
        else if (controls.Pacman.Left.triggered)
        {
            move = "left";
            MySpriteRenderer.sprite = PacmanSprites[2];
        }
        else if (controls.Pacman.Right.triggered)
        {
            move = "right";
            MySpriteRenderer.sprite = PacmanSprites[3];
        }

    }

    void FixedUpdate()
    {
        Debug.Log(move);
        if (move == "up" && !CheckDirection(checkList[0], true))
        {
            HandleMovement(new Vector3(0f, 1f, 0f));
        }
        else if (move == "down" && !CheckDirection(checkList[1], true))
        {
            HandleMovement(new Vector3(0f, -1f, 0f));
        }
        else if (move == "left" && !CheckDirection(checkList[2], false))
        {
            HandleMovement(new Vector3(-1f, 0f, 0f));
        }
        else if (move == "right" && !CheckDirection(checkList[3], false))
        {
            HandleMovement(new Vector3(1f, 0f, 0f));
        }
        else
        {
            HandleMovement(new Vector3(0f, 0f, 0f));
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(checkList[0].position, new Vector3(checkSize.x, checkSize.y, 1));
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(checkList[1].position, new Vector3(checkSize.x, checkSize.y, 1));
        Gizmos.color = new Color(1, 0, 1, 0.5f);
        Gizmos.DrawCube(checkList[2].position, new Vector3(checkSize.y, checkSize.x, 1));
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(checkList[3].position, new Vector3(checkSize.y, checkSize.x, 1));
    }
    
        }
    

