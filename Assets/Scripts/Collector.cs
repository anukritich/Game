using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinCount = 0;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectibles"))
        {
            
            CollectCollectible(other.gameObject);
            UpdateCoinText();
        }
        if (other.CompareTag("Bubble"))
        {
            CollectBubble(other.gameObject);
        }
        // if (other.CompareTag("Finish"))
        //{
        //    Debug.Log("Plane");
        //    SceneManager.LoadScene("Start");
        //}
    }

    private void CollectCollectible(GameObject collectible)
    {
        Debug.Log("Collecting " + collectible.name);
        Destroy(collectible); // Destroy the collectible object
        coinCount++;
       
    }

    private void CollectBubble(GameObject bubble)
    {
        Debug.Log("Stamina");
        Destroy(bubble); // Destroy the bubble object
        StaminaConroller.instance.RefillStamina();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Collectibles: " + coinCount.ToString();
    }
}
