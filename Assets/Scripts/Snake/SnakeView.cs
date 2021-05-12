using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Snake))]
public class SnakeView : MonoBehaviour
{
    [SerializeField] private Snake snake;
    [SerializeField] private TMP_Text view;

    private void OnEnable()
    {
        snake.SizeUpdated += OnSizeUpdated;
    }
    private void OnDisable()
    {
        snake.SizeUpdated -= OnSizeUpdated;
    }
    private void OnSizeUpdated(int size)
    {
        view.text = size.ToString();
    }
}
