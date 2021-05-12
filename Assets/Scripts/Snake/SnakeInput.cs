using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public Vector2 GetDirectionToClick(Vector2 headPosition)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 1;
        mousePosition = Camera.main.ViewportToWorldPoint(mousePosition);
        Vector2 distance = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);

        return distance;
    }
}
