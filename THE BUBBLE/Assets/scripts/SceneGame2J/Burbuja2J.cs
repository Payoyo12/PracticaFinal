using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burbuja2J : MonoBehaviour
{

    //vidas

    private int burbujaVida = 1;

    //Datos
    //private PlayerProfile _playerProfile;

    //audio

    public GameObject audioBurbuja16;

    //collider

    private BoxCollider2D[] burbujaBoxCollider2D;


    private void Awake()
    {
        //_playerProfile = RealmController.Instance.GetPlayerProfile();

        audioBurbuja16 = GameObject.FindGameObjectWithTag("burbujaexplot16");
    }

    // Start is called before the first frame update
    private void Start()
    {
        burbujaBoxCollider2D = gameObject.GetComponents<BoxCollider2D>();
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
            burbujaBoxCollider2D[0].enabled = true;
            burbujaBoxCollider2D[1].enabled = true;
        }

    }

    private void OnMouseDown()
    {
        if (gameObject.tag.Equals("burbuja"))
        {
            burbujaVida--;
        }

        

        if (burbujaVida == 0)
        {
            audioBurbuja16.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("burbujaexplot16");
            burbujaBoxCollider2D[0].enabled = false;
            burbujaBoxCollider2D[1].enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            //_playerProfile.PuntuacionTemporal1J++;
            //_playerProfile.NumBurbujasTotales1J++;
            //_playerProfile.NumBurbujasAzules1J++;

        }

    }

    public void DestroyBubble()
    {
        gameObject.SetActive(false);
    }








}
