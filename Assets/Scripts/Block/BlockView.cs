using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof( Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text view;
    [SerializeField] private Block block;

    private void OnEnable()
    {
        block.FillingUpdated += OnFillingUpdate;
    }
    private void OnDisable()
    {
        block.FillingUpdated -= OnFillingUpdate;
    }
    private void OnFillingUpdate(int leftToFill)
    {
        view.text = leftToFill.ToString();
    }
}

