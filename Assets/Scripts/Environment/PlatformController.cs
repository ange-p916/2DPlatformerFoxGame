using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : RaycastController
{
    public bool isPlayerOn;
    public float totalLerpTime;
    public Transform[] points;
    public int[] movePoints;
    public LayerMask PassengerMask;
    List<PassengerMovement> passengerMovement;
    Dictionary<Transform, Controller2D> passengerDictionary = new Dictionary<Transform, Controller2D>();

    public Vector3 whatDirection;
    Vector3 vel;
    UtilityManager utility;
    RaycastHit2D vHit;

    public override void Start()
    {
        base.Start();
        utility = new UtilityManager();
        movePoints = new int[] { 0, 1 };
    }

    void Update()
    {
        UpdateRaycastOrigins();
        //move code below here
        if(isPlayerOn)
        {
            vel = MovePlatform();
        }
        else
        {
            vel = Vector3.zero;
        }
        

        //move code above here

        CalculatePassengerMovement(vel);

        MovePassengers(true);
        
        
        transform.Translate(vel);
        MovePassengers(false);
    }

    IEnumerator WaitToMoveBack(float secs, bool upOrDown)
    {
        yield return new WaitForSeconds(totalLerpTime + secs);
        //do some code here
    }

    Vector3 MovePlatform()
    {
        Vector3 newPos = utility.StartLerping(points[movePoints[0]].transform.position, points[movePoints[1]].transform.position, totalLerpTime);

        if (utility.curLerpTime >= totalLerpTime)
        {
            if(transform.position == points[movePoints[1]].position)
            {
                utility.curLerpTime = 0f;
                Array.Reverse(movePoints);
                newPos = utility.StartLerping(points[movePoints[0]].transform.position, points[movePoints[1]].transform.position, totalLerpTime);
                //print("we're there now");
            }
        }

        return newPos - transform.position;
    }

    void MovePassengers(bool beforeMovePlatform)
    {
        foreach(PassengerMovement pas in passengerMovement)
        {
            if(!passengerDictionary.ContainsKey(pas.transform))
            {
                passengerDictionary.Add(pas.transform, pas.transform.GetComponent<Controller2D>());
            }

            if (pas.moveBeforePlatform == beforeMovePlatform)
            {
                passengerDictionary[pas.transform].Move(pas.velocity,Vector2.zero,pas.standingOnPlatform);
            }
        }
    }

    void CalculatePassengerMovement(Vector3 velocity)
    {
        HashSet<Transform> movedPassengers = new HashSet<Transform>();
        passengerMovement = new List<PassengerMovement>();

        float directionX = Mathf.Sign(velocity.x);
        float directionY = Mathf.Sign(velocity.y);

        //vert move platform
        if (velocity.y != 0 || velocity.y == 0)
        {
            float rayLength = Mathf.Abs(velocity.y) + skinWidth;

            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, PassengerMask);

                if (hit)
                {
                    if (!movedPassengers.Contains(hit.transform))
                    {
                        movedPassengers.Add(hit.transform);
                        float pushX = (directionY == 1) ? velocity.x : 0;
                        float pushY = velocity.y - (hit.distance - skinWidth) * directionY;

                        passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(pushX, pushY), directionY == 1, true));
                        
                    }
                    
                }
            }
        }

        //hor move platform
        if (velocity.x != 0)
        {
            float rayLength = Mathf.Abs(velocity.x) + skinWidth;

            for (int i = 0; i < horizontalRayCount; i++)
            {
                Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, PassengerMask);

                if (hit)
                {
                    if (!movedPassengers.Contains(hit.transform))
                    {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x - (hit.distance - skinWidth) * directionX;
                        float pushY = -skinWidth;

                        passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(pushX, pushY), false, true));
                    }
                }
            }
        }

        //passenger on top of a hor or down move platform
        if(directionY == -1 || velocity.y == 0 && velocity.x != 0)
        {
            float rayLength = skinWidth * 2;

            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, PassengerMask);

                if (hit)
                {
                    if (!movedPassengers.Contains(hit.transform))
                    {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x;
                        float pushY = velocity.y;

                        passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(pushX, pushY), true, false));
                    }
                }
            }
        }
    }

    struct PassengerMovement
    {
        public Transform transform;
        public Vector3 velocity;
        public bool standingOnPlatform;
        public bool moveBeforePlatform;

        public PassengerMovement(Transform _transform, Vector3 _velocity, bool _standingOnPlatform, bool _moveBeforePlatform)
        {
            transform = _transform;
            velocity = _velocity;
            standingOnPlatform = _standingOnPlatform;
            moveBeforePlatform = _moveBeforePlatform;
        }
    }

}