using UnityEngine;
using TMPro;

public class TextDisappear : MonoBehaviour
{
    public float disappearTime = 1.5f; // Time in seconds before text disappears
    private float timer = 0f;
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= disappearTime)
        {
            textComponent.enabled = false;
            Destroy(this.gameObject, 1f); // Destroy the game object after 1 second
        }
    }
}
