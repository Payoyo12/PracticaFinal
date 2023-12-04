using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScreenActionsSceneGame1J : MonoBehaviour
{
    private PlayerProfile _playerProfile;

    public GameObject Fondo;
    public GameObject PJugando;
    public TextMeshProUGUI Jugando;
    public GameObject PResultado;
    public TextMeshProUGUI Resultado;

    private float Contador;
    private bool Temporizador;


    public Pool Pool;

    private void Awake()
    {
        _playerProfile = RealmController.Instance.GetPlayerProfile();

        ReestablecerValores();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        PantallaJugando();
    }

    // Update is called once per frame
    void Update()
    {
        if (Temporizador)
        {
            if (Contador > 0)
            {
                Contador -= Time.deltaTime;
                int tiempoRedondeado = Mathf.CeilToInt(Contador);
                Jugando.text = tiempoRedondeado.ToString();
            }
            else
            {
                PantallaResultado();
                ReestablecerValores();


            }

        }
    }



    public void PantallaJugando()
    {
        Fondo.SetActive(false);
        PJugando.SetActive(true);
        PResultado.SetActive(false);


        Temporizador = true;
        Pool.burbujasFinales = false;

    }


    public void PantallaResultado()
    {
        if (_playerProfile.PuntuacionTemporal1J > _playerProfile.PuntuacionMax1J)
        {
            Resultado.text = "New Record\n" + _playerProfile.PuntuacionTemporal1J;
            _playerProfile.PuntuacionMax1J = _playerProfile.PuntuacionTemporal1J;
        }
        else
        {
            Resultado.text = "PUNTUACION\n" + _playerProfile.PuntuacionTemporal1J;
        }

        Fondo.SetActive(true);
        PJugando.SetActive(false);
        PResultado.SetActive(true);

    }

    public void SceneMenu1J()
    {
        SceneManager.LoadScene("Menu1J");
    }

    private void ReestablecerValores()
    {
        Pool.burbujasFinales = true;
        Temporizador = false;
        Contador = 10;
        Jugando.text = Contador.ToString();
        _playerProfile.PuntuacionTemporal1J = 0;


    }

}
