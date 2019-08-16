
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ammunition))]
public class Player : MonoBehaviour
{
    //[SerializeField] float dragSpeed = 1f;
    [Header("Player Color")]
    [Tooltip("R,G,B,A in that order")][SerializeField] Vector4 movingState = new Vector4(1f, 1f, 1f, 1f);
    [Tooltip("R,G,B,A in that order")][SerializeField] Vector4 aimingState = new Vector4(0.5f, 0.5f, 0.5f, 1f);

    [Header("Projectiles")]
    [SerializeField] GameObject projectileParent;
    [SerializeField] GameObject projectilePrefab;

    [Header("Movement")]
    [SerializeField] BoxCollider2D leftBound;
    [SerializeField] BoxCollider2D rightBound;

    bool leftProjectile;
    bool moveMode = true;

    Vector2 currentPosition;
    Vector2 lastPosition = Vector2.zero;
    SpriteRenderer sr;
    Ammunition ammo;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ammo = GetComponent<Ammunition>();
    }

    private void Update()
    {
        if (moveMode)
        {
            Movement();
        }
        else
        {
            CancelAim();
            Fire();
        }
        ColorIndicator();
    }

    private void Movement()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase) {
                case TouchPhase.Moved:
                    currentPosition = touchPosition;
                    if (lastPosition != Vector2.zero)
                    {
                        if (currentPosition != lastPosition)
                        {
                            var movedPosition = currentPosition.x - lastPosition.x;
                            var newPosition = transform.position.x + movedPosition;
                            var leftPoint = leftBound.transform.TransformPoint(leftBound.offset).x + (leftBound.size.x / 2) + (sr.size.x / 2f);
                            var rightPoint = rightBound.transform.TransformPoint(rightBound.offset).x - (rightBound.size.x / 2)  - (sr.size.y / 2f);
                            if (leftPoint < newPosition && newPosition < rightPoint)
                                transform.position = new Vector3(newPosition, 0f);
                        }
                    }
                    lastPosition = currentPosition;
                    break;
                case TouchPhase.Ended:
                    lastPosition = Vector2.zero;
                    moveMode = false;
                    break;
            }

        }
    }

    private void CancelAim()
    {
        if (Input.touchCount > 1)
        {
            moveMode = true;
        }
    }

    private void Fire()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    float firingAngle = Mathf.Atan((transform.position.x - touchPosition.x) / touchPosition.y) * Mathf.Rad2Deg;
                    GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0f, 0f, firingAngle)) as GameObject;
                    newProjectile.transform.parent = projectileParent.transform;
                    if(newProjectile.transform.position.x - transform.position.x > 0)
                    {
                        leftProjectile = false;
                    }
                    else
                    {
                        leftProjectile = true;
                    }
                    break;
                case TouchPhase.Ended:
                    moveMode = true;
                    break;
            }
        }
    }

    private void ColorIndicator()
    {
        if (moveMode)
        {
            Color color = movingState;
            sr.color = color;
        }
        else
        {
            Color color = aimingState;
            sr.color = color;
        }
    }
}