using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;
    public float speedMultiplier;
    public float speed = 2f;

    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public Vector2 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }
    // Start is called before the first frame update

    private void Awake()

    {

        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position; 
    }
    void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }
    private void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }
    private void FixedUpdate ()
    {

        Vector2 position = this.rigidbody.position;
        Vector2 transition = this.direction * this.speed * this.speedMultiplier;
        this.rigidbody.MovePosition(position + transition);

    }
    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }

     

 
}
