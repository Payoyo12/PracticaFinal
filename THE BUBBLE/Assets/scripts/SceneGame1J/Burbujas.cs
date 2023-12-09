using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burbujas : MonoBehaviour
{
    //vidas

    private int burbujaVida = 1;
    private int burbujaDoradaVida = 3;

    //Datos

    //audio

    public GameObject audioBurbuja16;
    public GameObject audioBurbujaDorada;

    //collider
    private BoxCollider2D[] burbujaBoxColliders;
    //private BoxCollider2D[] burbujaBoxCollider2D;

    private void Awake()
    {


        audioBurbuja16 = GameObject.FindGameObjectWithTag("burbujaexplot16");
        audioBurbujaDorada = GameObject.FindGameObjectWithTag("burbujaexplotdorada");
    }

    // Start is called before the first frame update
    private void Start()
    {
        burbujaBoxColliders = gameObject.GetComponents<BoxCollider2D>();
        //burbujaBoxCollider2D = gameObject.GetComponents<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnEnable()
    {
        if (gameObject.tag.Equals("burbuja"))
        {
            burbujaVida = 1;
            //burbujaBoxCollider2D[0].enabled = true;
            //burbujaBoxCollider2D[1].enabled = true;
        }

        if (gameObject.tag.Equals("burbujaDorada"))
        {
            burbujaDoradaVida = 3;
            //burbujaBoxCollider2D[0].enabled = true;
            //burbujaBoxCollider2D[1].enabled = true;
        }

        foreach (var burbujaBoxCollider in burbujaBoxColliders) burbujaBoxCollider.enabled = true;
        audioBurbuja16.GetComponent<AudioSource>().Stop();
        audioBurbujaDorada.GetComponent<AudioSource>().Stop();
    }

    private void OnMouseDown()
    {
        if (gameObject.tag.Equals("burbuja"))
        {
            burbujaVida--;
        }

        if (gameObject.tag.Equals("burbujaDorada"))
        {
            burbujaDoradaVida--;
        }

        if (burbujaVida == 0)
        {
            audioBurbuja16.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("burbujaexplot16");
            foreach (var burbujaBoxCollider in burbujaBoxColliders) burbujaBoxCollider.enabled = false;
            //burbujaBoxCollider2D[0].enabled = false;
            //burbujaBoxCollider2D[1].enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            RealmController.Instance.UpdateDataInt("PuntuacionTemporal1J", 1);
            RealmController.Instance.UpdateDataInt("NumBurbujasTotales1J", 1);
            RealmController.Instance.UpdateDataInt("NumBurbujasAzules1J", 1);

        }

        if (burbujaDoradaVida == 0)
        {
            audioBurbujaDorada.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("burbujaexplot16");
            //burbujaBoxCollider2D[0].enabled = false;
            //burbujaBoxCollider2D[1].enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            RealmController.Instance.UpdateDataInt("PuntuacionTemporal1J", 3);
            RealmController.Instance.UpdateDataInt("NumBurbujasTotales1J", 1);
            RealmController.Instance.UpdateDataInt("NumBurbujasDoradas1J", 1);

        }
    }
    
    public void DestroyBubble()
    {
        gameObject.SetActive(false);
    }
}