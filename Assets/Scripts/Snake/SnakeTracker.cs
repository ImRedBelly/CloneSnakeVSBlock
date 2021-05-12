using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTracker : MonoBehaviour
{
    [SerializeField] private SnakeHead snakeHead;
    [SerializeField] private float speed;
    [SerializeField] private float offsetY;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), speed * Time.fixedDeltaTime);


    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(transform.position.x, snakeHead.transform.position.y + offsetY, transform.position.z);
    }
}
