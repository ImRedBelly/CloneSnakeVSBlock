using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : MonoBehaviour
{
    [SerializeField] private Segment segmentSnake;

    public List<Segment> Generate(int count)
    {
        List<Segment> tail = new List<Segment>();
        for (int i = 0; i < count; i++)
        {
            tail.Add(Instantiate(segmentSnake, transform));
        }
        return tail;
    }


}
