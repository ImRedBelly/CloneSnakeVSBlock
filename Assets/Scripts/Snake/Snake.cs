using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent(typeof(SnakeInput))]
[RequireComponent(typeof(SnakeGenerator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead head;
    [SerializeField] private int tailSize;
    [SerializeField] private SnakeInput snakeInput;
    [SerializeField] private SnakeGenerator snakeGenerator;

    [SerializeField] private float speed;
    [SerializeField] private float tailSpringiness;

    private List<Segment> tail;


    public event UnityAction<int> SizeUpdated;
    private void Awake()
    {
        snakeGenerator = GetComponent<SnakeGenerator>();
        tail = snakeGenerator.Generate(tailSize);

    }
    private void Start()
    {
        SizeUpdated?.Invoke(tail.Count);

    }

    private void OnEnable()
    {
        head.BlockCollided += OnBlockColided;
        head.BonusCollected += OnBonusCollected;
    }

    private void FixedUpdate()
    {
        Move(head.transform.position + head.transform.up * speed * Time.fixedDeltaTime);
        head.transform.up = snakeInput.GetDirectionToClick(head.transform.position);
    }

    private void OnDisable()
    {
        head.BlockCollided -= OnBlockColided;
        head.BonusCollected -= OnBonusCollected;
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = head.transform.position;

        foreach (var segment in tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition, tailSpringiness * Time.fixedDeltaTime);
            previousPosition = tempPosition;
        }
        head.Move(nextPosition);
    }

    private void OnBlockColided()
    {
        Segment deltaSegment = tail[tail.Count - 1];
        tail.Remove(deltaSegment);
        Destroy(deltaSegment.gameObject);

        SizeUpdated?.Invoke(tail.Count);
    }

    private void OnBonusCollected(int bonusSize)
    {
        tail.AddRange(snakeGenerator.Generate(bonusSize));
        SizeUpdated?.Invoke(tail.Count);
    }
}
