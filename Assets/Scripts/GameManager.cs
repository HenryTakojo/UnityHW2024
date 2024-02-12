using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public object enemy;

    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
        
        GameObject gameObject = new GameObject();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateEnemies(int num)
    {
        enemies = new GameObject[num];
        for (int i = 0; i < enemies.Length; i++)
        {
            
        }
    }
}
