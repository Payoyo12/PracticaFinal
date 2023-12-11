using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    //burbujas

    public GameObject burbujas;       // Referencia prefab a instanciar
    private GameObject[] burbujasArray;   // Array de objetos a reciclar (piscina de objetos)
    private int burbujasArraySize = 30; // Tamanyo del array
    private int burbujasArrayIndice = -1;   // Indice de la posicion del array (indica la bala a activar)
    private float burbujasVelocity = 200;

    public GameObject burbujasDoradas;       // Referencia prefab a instanciar
    private GameObject[] burbujasDoradasArray;   // Array de objetos a reciclar (piscina de objetos)
    private int burbujasDoradasArraySize = 2; // Tamanyo del array
    private int burbujasDoradasArrayIndice = -1;   // Indice de la posicion del array (indica la bala a activar)
    private float burbujasDoradasVelocity = 200;
    private int randomAparicion;    //momento en el que aparecera la burbujaDorada

    //vectores aleatorios

    private int arrayVectoresSize = 4;
    private Vector3[] arrayVectores;
    private int random;

    // Variables para el temporizador

    private float incrementadorDeTiempo = 0f;

    //fin de partida
    public bool burbujasFinales = false;

    // Start is called before the first frame update
    private void Start()
    {
        //burbujas
        burbujasArray = new GameObject[burbujasArraySize]; // Creamos el array con un tamaño igual al de la variable int burbujasArraySize
        for (int i = 0; i < burbujasArraySize; i++)// Creamos todas las burbujas, las colocamos como hijas de este gameobject y las desactivamos
        {
            burbujasArray[i] = Instantiate(burbujas, transform.position, Quaternion.identity);
            burbujasArray[i].transform.parent = gameObject.transform;
            burbujasArray[i].SetActive(false);
            Debug.Log("tamaño del array: " + burbujasArraySize);
            Debug.Log("creando burbuja " + i);
        }

        burbujasDoradasArray = new GameObject[burbujasDoradasArraySize]; // Creamos la array con un tamaño igual al de la variable int primera
        for (int i = 0; i < burbujasDoradasArraySize; i++)// Creamos todas las balas, las colocamos como hijas de este gameobject y las desactivamos
        {
            burbujasDoradasArray[i] = Instantiate(burbujasDoradas, transform.position, Quaternion.identity);
            burbujasDoradasArray[i].transform.parent = gameObject.transform;
            burbujasDoradasArray[i].SetActive(false);
        }

        randomAparicion = Random.Range(0, 10000);

        ////vectores aleatorios
        arrayVectores = new Vector3[arrayVectoresSize]; // Creamos la array con un tamaño igual al de la variable int primera

        arrayVectores[0] = new Vector3(-3.5f, 7.5f, -1);
        arrayVectores[1] = new Vector3(3.5f, 7.5f, -1);
        arrayVectores[2] = new Vector3(-3.5f, -5.5f, -1);
        arrayVectores[3] = new Vector3(3.5f, -5.5f, -1);

        random = Random.Range(0, 4);
    }

    // Update is called once per frame
    private void Update()
    {
        if (burbujasFinales == true)
        {
            desactivador();
        }
        else
        {
            random = Random.Range(0, 4);

            incrementadorDeTiempo += Time.deltaTime;

            if (incrementadorDeTiempo > 0.5f)
            {

                burbujasArrayIndice++; // Tras diparar pasamos a la siguiente burbuja

                // Si nos salimos del rango del array, volvemos a cero.
                if (burbujasArrayIndice >= burbujasArraySize)
                {
                    burbujasArrayIndice = 0;
                }

                Activador(burbujasArray, burbujasArrayIndice, burbujasArraySize, burbujasVelocity);

                incrementadorDeTiempo = 0f;
            }

            randomAparicion = Random.Range(0, 25);

            if (randomAparicion == 20)
            {
                burbujasDoradasArrayIndice++; // Tras diparar pasamos a la siguiente burbuja

                // Si nos salimos del rango del array, volvemos a cero.
                if (burbujasDoradasArrayIndice >= burbujasDoradasArraySize)
                {
                    burbujasDoradasArrayIndice = 0;
                }

                Activador(burbujasDoradasArray, burbujasDoradasArrayIndice, burbujasDoradasArraySize, burbujasDoradasVelocity);

                
            }
        }
    }

    
    public void Activador(GameObject[] Array, int indice, int ArraySize, float Velocity)
    {

        if (Array[indice].activeSelf == false)
        {
            Array[indice].transform.position = arrayVectores[random]; // Ponemos la burbuja en una de las cuatro salidas

            Array[indice].SetActive(true); // Activamos la burbuja
        }

        //movimiento

        if (Array[indice].transform.position.Equals(arrayVectores[0]))
        {
            //Debug.Log("0");

            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.right * Velocity);
            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.down * Velocity);
        }
        else if (Array[indice].transform.position.Equals(arrayVectores[1]))
        {
            //Debug.Log("1");

            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.left * Velocity);
            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.down * Velocity);
        }
        else if (Array[indice].transform.position.Equals(arrayVectores[2]))
        {
            //Debug.Log("2");

            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.right * Velocity);
            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.up * Velocity);
        }
        else if (Array[indice].transform.position.Equals(arrayVectores[3]))
        {
            //Debug.Log("3");

            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.left * Velocity);
            Array[indice].GetComponent<Rigidbody2D>().AddForce(Vector3.up * Velocity);
        }
    }

    private void desactivador()
    {
        //burbujas
        for (int i = 0; i < burbujasArraySize; i++)
        {
                burbujasArray[i].SetActive(false);
        }

        for (int i = 0; i < burbujasDoradasArraySize; i++)
        {
                burbujasDoradasArray[i].SetActive(false);
        }
    }
}