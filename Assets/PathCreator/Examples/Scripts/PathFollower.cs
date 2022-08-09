using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;


        float currentSpeed = 0;
        float originalSpeed = 0;

        // for input from the UI/buttons:
        public string message;
        public int integer;
        public float floatingPointNumber;
        public float secondsToStop = 1;

        void Start() {
            currentSpeed = speed;
            originalSpeed = speed;
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void toggleMovement()
        {
            // if (speed > 0) {
            //     speed = 0;
            // }
            // else {
            //     speed = 5;
            // }
            
            StartCoroutine(slowDownSpeedUp(speed, 1));
        }

        IEnumerator slowDownSpeedUp(float currentSpeed, float secondsToStop)
        {
            if (currentSpeed > 0) {
                while (currentSpeed > 0)
                {
                    currentSpeed -= secondsToStop * Time.deltaTime;
                    speed = currentSpeed;
                    yield return null;
                }
                
                Debug.Log("Stopped moving.");
                yield break;
            }

            else {
                while (currentSpeed < originalSpeed)
                {
                    currentSpeed += secondsToStop * Time.deltaTime;
                    speed = currentSpeed;
                    yield return null;
                }
                
                Debug.Log("Started moving again");
                yield break;
            }
        }
    }
}