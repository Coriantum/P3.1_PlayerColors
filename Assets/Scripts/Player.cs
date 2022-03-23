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
    // public List<Color> coloresOcupados = new List<Color>();

    public List<GameObject> players = new List<GameObject>();

    //Objeto para instanciar
    public GameObject player;


    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        //players = new List<GameObject>(Resources.LoadAll<GameObject>("Player"));
        

        // Mientras hayan menos de 6 players,ejecutará el metodo CreatePlayer cada 5 seg a partir de una corrutina
        StartCoroutine(SpawnPlayerTime());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Creacion de corrutina que se encargue de los segundos que pasan de un spawn.
    IEnumerator SpawnPlayerTime(){
        
        // Crea el objeto
        for(int i = 0; i < 6; i++){
            CreatePlayer(player);
            
            yield return new WaitForSeconds(5f);
            
        }
        
    }


    // Metodo que cree o genere el player, genere una posicion y genere un color aleatorio
    public void CreatePlayer(GameObject player){ 
        
            Vector3 randomPosition = new Vector3(Random.Range(-3f, 3f),1f, Random.Range(-3f,3f));

            //Instancia nuevo objeto
            GameObject playerGameobject = Instantiate(player, randomPosition, Quaternion.identity);
            players.Add(playerGameobject);
            
            // Asignamos color
            GetRandomColor(playerGameobject);        

    }

    // Metodo encargado de la generacion aleatoria de colores y asignacion
    public void GetRandomColor(GameObject playerColor){

        int colorPos = Random.Range(0, colores.Count);
        Color randomColor = colores[Random.Range(0,colores.Count)];
        
        // Asigno color
        playerColor.GetComponent<Renderer>().material.color = colores[colorPos];

        // Borro en la lista dicho color elegido aleatoriamente de la lista para que no se repita
        colores.RemoveAt(colorPos);

    }
    
    
}
