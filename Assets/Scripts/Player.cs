using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int player = 0;
    public int sira = 0;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game");
        if (gameObject.name == "Red")
            player = 0;
        else
            player = 1;
    }

    // Update is called once per frame
    void Update()
    {
        sira = game.GetComponent<Game>().sira;
    }
}
