using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScreenActionsSceneGame1J : MonoBehaviour
{

    public GameObject Fondo;
    public GameObject PJugando;
    public TextMeshProUGUI Jugando;
    public GameObject PResultado;
    public TextMeshProUGUI Resultado;

    private float Contador;
    private bool Temporizador;


    public Pool Pool;

    public AudioSource MusicaFondo;

    private bool ResultadoEnEjecucion;



    private void Awake()
    {
        ReestablecerValores();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResultadoEnEjecucion = false;
        PantallaJugando();
    }

    // Update is called once per frame
    void Update()
    {
        if (Temporizador)
        {
            if (Contador >= 0)
            {
                Contador -= Time.deltaTime;
                int tiempoRedondeado = Mathf.CeilToInt(Contador);
                Jugando.text = tiempoRedondeado.ToString();
            }
            else
            {
                if (!ResultadoEnEjecucion)
                {
                    PantallaResultado();
                    ResultadoEnEjecucion = true;
                }


            }

        }
    }



    public void PantallaJugando()
    {
        

        Fondo.SetActive(false);
        PJugando.SetActive(true);
        PResultado.SetActive(false);

        //MusicaController.Instance.DesactivarAudio();
        //MusicaFondo.Play();
        Temporizador = true;
        Pool.burbujasFinales = false;

    }


    public void PantallaResultado()
    {
        RealmController.Instance.UpdateDataInt("NumPartidasJugadas1J", 1);

        RealmController.Instance.UpdateDataInt("NumPuntosTotales1J", RealmController.Instance.GetDataInt("PuntuacionTemporal1J"));

        if (RealmController.Instance.GetDataInt("PuntuacionTemporal1J") >
            RealmController.Instance.GetDataInt("PuntuacionMax1J"))
        {
            RealmController.Instance.UpdateDataInt("PuntuacionMax1J", RealmController.Instance.GetDataInt("PuntuacionTemporal1J"));
            Resultado.text = "New Record\n" + RealmController.Instance.GetDataInt("PuntuacionMax1J");
        }
        else
        {
            Resultado.text = "PUNTUACION\n" + RealmController.Instance.GetDataInt("PuntuacionTemporal1J");
        }

        


        Fondo.SetActive(true);
        PJugando.SetActive(false);
        PResultado.SetActive(true);
        ReestablecerValores();
    }

    public void SceneMenu1J()
    {
        SceneManager.LoadScene("Menu1J");
    }

    private void ReestablecerValores()
    {
        //MusicaController.Instance.ActivarAudio();
        //MusicaFondo.Stop();
        Pool.burbujasFinales = true;
        Temporizador = false;
        Contador = 10;
        Jugando.text = Contador.ToString();
        ResultadoEnEjecucion = false;
        RealmController.Instance.resetearData("PuntuacionTemporal1J");


    }

}
