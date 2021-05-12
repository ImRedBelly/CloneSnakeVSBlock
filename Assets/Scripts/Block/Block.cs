using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int destroyPriceRange;
    [SerializeField] private Color[] colors;
    [SerializeField] private SpriteRenderer spriteRenderer;


    private int destroyPrice;
    private int filling;


    public event UnityAction<int> FillingUpdated;
    public int LeftToFill => destroyPrice - filling;
    private void Start()
    {
        destroyPrice = Random.Range(destroyPriceRange.x, destroyPriceRange.y);
        FillingUpdated?.Invoke(LeftToFill);

        SetColor(colors[Random.Range(0, colors.Length)]);
    }

    public void Fill()
    {
        filling++;
        FillingUpdated?.Invoke(LeftToFill);

        if (filling == destroyPrice)
        {
            Destroy(gameObject);
        }
    }

    private void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}

