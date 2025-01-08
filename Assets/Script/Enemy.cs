using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int pointValue = 10; 

   
    private void OnDestroy()
    {
        
        ScoreManager.instance.AddScore(pointValue);
    }

    
    public void OnHit()
    {
        
        Destroy(gameObject);
    }
}