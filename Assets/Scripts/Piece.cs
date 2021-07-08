using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Piece : MonoBehaviour
{
    public PieceType pType;
    public string team;
    public int positionX;
    public int positionY;
    public int sira=0;//0 red,1 blue
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        if (team == "Red")
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            player = GameObject.Find("Red");
        }
        else
        {
            player = GameObject.Find("Blue");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.ToString() == "SetupScene")
        {
            
        }
        else
        {
            if (player.GetComponent<Player>().sira == 0) //red takımın sırası
            {
                if (team == "Blue")
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }
            }
            if (player.GetComponent<Player>().sira == 1) //blue takımın sırası
            {
                if (team == "Blue")
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }
                else
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
            }
        }
    }
    private void OnMouseUp()
    {
        if (SceneManager.GetActiveScene().name.ToString() == "SetupScene")
        {
            StartCoroutine(WaitForClick());
        }
        else
        {
            GameObject temp = new GameObject();
            List<GameObject> enabled = new List<GameObject>();
            List<GameObject> disabled = new List<GameObject>();
            List<GameObject> enemyr = new List<GameObject>();
            List<GameObject> enemyg = new List<GameObject>();
            int dist = GetComponent<PieceAttributes>().move;
            if (pType.ToString() == "Dragon") //Dragonın movementı
            {
                List<GameObject> add1 = new List<GameObject>();
                List<GameObject> add2 = new List<GameObject>();
                List<GameObject> add3 = new List<GameObject>();
                List<GameObject> add4 = new List<GameObject>();
                List<GameObject> add5 = new List<GameObject>();
                List<GameObject> add6 = new List<GameObject>();
                List<GameObject> adddisable = new List<GameObject>();
                foreach (var item in player.GetComponent<Player>().game.GetComponent<Game>().map)
                {
                    if (positionX == item.GetComponent<Click>().x && positionY == item.GetComponent<Click>().y)
                        temp = item;
                    for (int i = 1; i <= 10; i++)
                    {
                        if (item.GetComponent<Click>().x == positionX + i && item.GetComponent<Click>().y == positionY)//sağ
                        {
                            add1.Add(item);
                        }
                        if(item.GetComponent<Click>().x == positionX - i && item.GetComponent<Click>().y == positionY)//sol
                        {
                            add2.Add(item);
                        }
                        if (item.GetComponent<Click>().x == positionX && item.GetComponent<Click>().y == positionY + i) //sağyukar
                        {
                            add3.Add(item);
                        }
                        if(item.GetComponent<Click>().x == positionX && item.GetComponent<Click>().y == positionY - i) //solaşağı
                        {
                            add4.Add(item);
                        }
                        if (item.GetComponent<Click>().x == positionX - i && item.GetComponent<Click>().y == positionY + i)//solyukarı
                        {
                            add5.Add(item);
                        }
                        if(item.GetComponent<Click>().x == positionX + i && item.GetComponent<Click>().y == positionY - i)//sağaşağı
                        {
                            add6.Add(item);
                        }
                    }
                    adddisable.Add(item);
                }
                add2.Reverse();
                add4.Reverse();
                add6.Reverse();
                foreach (var item in add1)
                {
                    if (item.GetComponent<Click>().onIt == null)
                    {
                        enabled.Add(item);
                        adddisable.Remove(item);
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Mountain")
                    {
                        enemyr.Add(item);
                        break;
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                    {
                        if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Catapult" || item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Trebuchet")
                        {
                            enemyr.Add(item);
                            break;
                        }
                        enemyg.Add(item);
                    }
                }
                foreach (var item in add2)
                {
                    if (item.GetComponent<Click>().onIt == null)
                    {
                        enabled.Add(item);
                        adddisable.Remove(item);
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Mountain")
                    {
                        enemyr.Add(item);
                        break;
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                    {
                        if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Catapult" || item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Trebuchet")
                        {
                            enemyr.Add(item);
                            break;
                        }
                        enemyg.Add(item);
                    }
                }
                foreach (var item in add3)
                {
                    if (item.GetComponent<Click>().onIt == null)
                    {
                        enabled.Add(item);
                        adddisable.Remove(item);
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Mountain")
                    {
                        enemyr.Add(item);
                        break;
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                    {
                        if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Catapult" || item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Trebuchet")
                        {
                            enemyr.Add(item);
                            break;
                        }
                        enemyg.Add(item);
                    }
                }
                foreach (var item in add4)
                {
                    if (item.GetComponent<Click>().onIt == null)
                    {
                        enabled.Add(item);
                        adddisable.Remove(item);
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Mountain")
                    {
                        enemyr.Add(item);
                        break;
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                    {
                        if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Catapult" || item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Trebuchet")
                        {
                            enemyr.Add(item);
                            break;
                        }
                        enemyg.Add(item);
                    }
                }
                foreach (var item in add5)
                {
                    if (item.GetComponent<Click>().onIt == null)
                    {
                        enabled.Add(item);
                        adddisable.Remove(item);
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Mountain")
                    {
                        enemyr.Add(item);
                        break;
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                    {
                        if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Catapult" || item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Trebuchet")
                        {
                            enemyr.Add(item);
                            break;
                        }
                        enemyg.Add(item);
                    }
                }
                foreach (var item in add6)
                {
                    if (item.GetComponent<Click>().onIt == null)
                    {
                        enabled.Add(item);
                        adddisable.Remove(item);
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Mountain")
                    {
                        enemyr.Add(item);
                        break;
                    }
                    else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                    {
                        if (item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Catapult" || item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString() == "Trebuchet")
                        {
                            enemyr.Add(item);
                            break;
                        }
                        enemyg.Add(item);
                    }
                }
                foreach (var item in adddisable)
                {
                    disabled.Add(item);
                }
            }
            else //kalan taşların movementı
            {
                foreach (var item in player.GetComponent<Player>().game.GetComponent<Game>().map)
                {
                    int dist2 = 0;
                    if (dist != 0)
                        dist2 = 1;
                    if (distance(positionX, positionY, item.GetComponent<Click>().x, item.GetComponent<Click>().y) <= dist2)
                    {
                        if (item.GetComponent<Click>().onIt == null)
                        {
                            enabled.Add(item);
                        }
                        else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                        {
                            if (item.GetComponent<Click>().onIt.GetComponent<Piece>().GetComponent<PieceAttributes>().trump == pType.ToString()) 
                            {
                                enemyr.Add(item);
                            }
                            else if(GetComponent<PieceAttributes>().strenght >= item.GetComponent<Click>().onIt.GetComponent<Piece>().GetComponent<PieceAttributes>().strenght || GetComponent<PieceAttributes>().trump==item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString())
                            {
                                enemyg.Add(item);
                            }
                            else
                            {
                                enemyr.Add(item);
                            }
                        }
                        else if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team == team)
                            disabled.Add(item);
                        if (positionX == item.GetComponent<Click>().x && positionY == item.GetComponent<Click>().y)
                            temp = item;
                    }
                    else
                    {
                        disabled.Add(item);
                    }
                }
                if (dist >= 2)
                {
                    for (int i = 0; i < dist - 1; i++)
                    {
                        List<GameObject> addenable = new List<GameObject>();
                        List<GameObject> addenemyg = new List<GameObject>();
                        List<GameObject> addenemyr = new List<GameObject>();
                        foreach (var item in enabled)
                        {
                            foreach (var item2 in disabled)
                            {
                                if (distance(item.GetComponent<Click>().x, item.GetComponent<Click>().y, item2.GetComponent<Click>().x, item2.GetComponent<Click>().y) <= 1)
                                {
                                    if (item2.GetComponent<Click>().onIt == null)
                                    {
                                        addenable.Add(item2);
                                    }
                                    else if (item2.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                                    {
                                        if (item2.GetComponent<Click>().onIt.GetComponent<Piece>().GetComponent<PieceAttributes>().trump == pType.ToString())
                                        {
                                            addenemyr.Add(item2);
                                        }
                                        if (GetComponent<PieceAttributes>().trump != null)
                                        {
                                            if (GetComponent<PieceAttributes>().trump.ToString() == item2.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString())
                                                addenemyg.Add(item2);
                                            else
                                            {
                                                if (GetComponent<PieceAttributes>().strenght >= item2.GetComponent<Click>().onIt.GetComponent<Piece>().GetComponent<PieceAttributes>().strenght)
                                                {
                                                    addenemyg.Add(item2);
                                                }
                                                else
                                                {
                                                    addenemyr.Add(item2);
                                                }
                                            }
                                        }
                                        else 
                                        {
                                            if (GetComponent<PieceAttributes>().strenght >= item2.GetComponent<Click>().onIt.GetComponent<Piece>().GetComponent<PieceAttributes>().strenght)
                                            {
                                                addenemyg.Add(item2);
                                            }
                                            else
                                            {
                                                addenemyr.Add(item2);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var item in addenable)
                        {
                            enabled.Add(item);
                            disabled.Remove(item);
                        }
                        foreach (var item in addenemyg)
                        {
                            enemyg.Add(item);
                            disabled.Remove(item);
                        }
                        foreach (var item in addenemyr)
                        {
                            enemyr.Add(item);
                            disabled.Remove(item);
                        }
                    }
                }
                if (GetComponent<PieceAttributes>().range > 0)
                {
                    Debug.Log("rangl");
                    List<GameObject> addenemyg = new List<GameObject>();
                    foreach (var item in disabled)
                    {
                        if (item.GetComponent<Click>().onIt != null)
                        {
                            if (item.GetComponent<Click>().onIt.GetComponent<Piece>().team != team)
                            {
                                if(distance(positionX,positionY,item.GetComponent<Click>().x, item.GetComponent<Click>().y)<= GetComponent<PieceAttributes>().range)
                                {
                                    if (GetComponent<PieceAttributes>().strenght >= item.GetComponent<Click>().onIt.GetComponent<Piece>().GetComponent<PieceAttributes>().strenght || GetComponent<PieceAttributes>().trump == item.GetComponent<Click>().onIt.GetComponent<Piece>().pType.ToString())
                                    {
                                        addenemyg.Add(item);
                                    }
                                }
                            }
                        }
                    }
                    foreach (var item in addenemyg)
                    {
                        enemyg.Add(item);
                        disabled.Remove(item);
                    }
                }
            }
            foreach (var item in enabled)
            {
                item.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                item.GetComponent<PolygonCollider2D>().enabled = true;
            }
            foreach (var item in disabled)
            {
                item.GetComponent<Renderer>().material.SetColor("_Color", new Color(70f / 255f, 70f / 255f, 70f / 255f));
                item.GetComponent<PolygonCollider2D>().enabled = false;
            }
            foreach (var item in enemyg)
            {
                item.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                item.GetComponent<PolygonCollider2D>().enabled = true;
            }
            foreach (var item in enemyr)
            {
                item.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                item.GetComponent<PolygonCollider2D>().enabled = false;
            }
            StartCoroutine(WaitForClick(temp));
        }
    }
    IEnumerator WaitForClick(GameObject temp=null)
    {
        while(true){
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.name == "Hexagon(Clone)")
                    {
                        if (SceneManager.GetActiveScene().name.ToString() == "SampleScene")
                        {
                            if (distance(positionX,positionY, hit.collider.GetComponent<Click>().x, hit.collider.GetComponent<Click>().y) <= GetComponent<PieceAttributes>().move)
                            {
                                positionX = hit.collider.GetComponent<Click>().x;
                                positionY = hit.collider.GetComponent<Click>().y;
                                this.transform.position = new Vector3(positionX * 0.9f + (positionY * 0.45f), positionY * 0.75f, -1);
                            }
                            player.GetComponent<Player>().game.GetComponent<Game>().sira = (player.GetComponent<Player>().game.GetComponent<Game>().sira + 1) % 2;
                            boardColorBase();
                            if(hit.collider.GetComponent<Click>().onIt!=null)
                                Destroy(hit.collider.GetComponent<Click>().onIt.GetComponent<Piece>().gameObject);
                            if (distance(positionX, positionY, hit.collider.GetComponent<Click>().x, hit.collider.GetComponent<Click>().y) <= GetComponent<PieceAttributes>().move) 
                            {
                                hit.collider.GetComponent<Click>().onIt = GetComponent<Piece>();
                                temp.GetComponent<Click>().onIt = null;
                            }
                        }
                        else
                        {
                            GameObject game = new GameObject();
                            game = GameObject.Find("Game");
                            foreach (var item in game.GetComponent<Game>().map)
                            {
                                if (item.GetComponent<Click>().x==positionX && item.GetComponent<Click>().y == positionY)
                                {
                                    item.GetComponent<PolygonCollider2D>().enabled = true;
                                }
                            }
                            positionX = hit.collider.GetComponent<Click>().x;
                            positionY = hit.collider.GetComponent<Click>().y;
                            hit.collider.GetComponent<PolygonCollider2D>().enabled = false;
                            this.transform.position = new Vector3(positionX * 0.9f + (positionY * 0.45f), positionY * 0.75f, -1);
                        }
                    }
                    if (SceneManager.GetActiveScene().name.ToString() == "SampleScene")
                        boardColorBase();
                }
                yield break;
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (SceneManager.GetActiveScene().name.ToString() == "SampleScene")
                    boardColorBase();
                yield break;
            }
            yield return null;
        }
    }
    private int distance(int pieceX,int pieceY,int x,int y) //Taşın konumu ile, altıgenin arasındaki mesafeyi bulma
    {
        return Math.Max(Math.Abs(pieceX - x), Math.Max(Math.Abs(pieceY - y), Math.Abs((-pieceX + (-pieceY)) - (-x + (-y)))));
    }
    private void boardColorBase()
    {
        foreach (var item in player.GetComponent<Player>().game.GetComponent<Game>().map)
        {
            item.GetComponent<Renderer>().material.SetColor("_Color", new Color(70f / 255f, 70f / 255f, 70f / 255f));
            item.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
}
