using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour

{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    public void Play()
    {
        StartCoroutine(DelayedLoad());
    }
   
    private IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(1.2f); // Delay for  seconds
        SceneManager.LoadScene("Game");
    }
   
  
    public void Quit()
    {
        Application.Quit();
    }

}


