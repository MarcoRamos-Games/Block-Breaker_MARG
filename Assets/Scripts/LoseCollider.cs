using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");  //Checks if the ball falls of the map annd if so trigger the game over scene
    }
}
