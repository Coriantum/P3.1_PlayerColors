using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<Color> colores = new List<Color>(){
        Color.black,
        Color.blue,
        Color.cyan,
        Color.gray,
        Color.green,
        Color.magenta,
        Color.red,
        Color.yellow,
        Color.white,
        new Color(78,1,1,76)
    };

    // Crear otra lista "contenedor" o de "Colores ocupados"
    public List<Color> coloresOcupados = new List<Color>();

    public List<GameObject> players = new List<GameObject>();

    //Objeto para instanciar
    public GameObject player;


    //Adquirimos una nueva posicion aleatoria
    Vector3 randomPosition;


    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        //players = new List<GameObject>(Resources.LoadAll<GameObject>("Player"));
        
        randomPosition = new Vector3(Random.Range(-3f, 3f),1f, Random.Range(-3f,3f));

        // Mientras hayan menos de 6 players,ejecutará el metodo CreatePlayer cada 5 seg
        if(players.Count < 6){
            Invoke("CreatePlayer", 5f);
            //CreatePlayer();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    //Metodo que mueva el player
    public void Move(){
        //Adquirimos una nueva posicion aleatoriamente
        //Vector3 randomPosition = new Vector3(Random.Range(-3f, 3f),1f, Random.Range(-3f,3f));

        // La posicion generada será según la randomPosition
        transform.position = randomPosition;

    }

    // Metodo encargado de la generacion aleatoria de colores y asignacion
    public void GetRandomColor(){
        Color randomColor = colores[Random.Range(0,colores.Count)];
        rend.material.color = randomColor;

    }

    // Metodo que cree o genere el player
    public void CreatePlayer(){
        
        for(int i =0; i< 6; i++){
            //Instancia nuevo objeto
            GameObject playerGameobject = Instantiate(player, randomPosition, Quaternion.identity);
            players[i] = playerGameobject;
            Move();
            
            // Asignamos color
            GetRandomColor();

            
        }
    }

    
    
    
}
