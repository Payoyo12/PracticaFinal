using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenActionsSceneMenu : MonoBehaviour
{
    private PlayerProfile _playerProfile;

    public GameObject Fondo;
    public GameObject PJugadores;
    public GameObject PEstadisticas;
    public TextMeshProUGUI Estadisticas1j;
    public GameObject PLogros;
    //public GameObject PCarga;


    // Start is called before the first frame update
    void Start()
    {
        _playerProfile = RealmController.Instance.GetPlayerProfile();

        Fondo.SetActive(true);
        //DesactivarPantallaCarga();
        PantallaJugadores();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PantallaJugadores()
    {
        PJugadores.SetActive(true);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(false);

    }
    public void PantallaEstadisticas()
    {

        

        Estadisticas1j.text = "|    " + _playerProfile.NumPartidasJugadas1J +
                            "\n|    " + _playerProfile.NumPuntosTotales1J +
                            "\n|    " + _playerProfile.PuntuacionMax1J +
                            "\n|    " + _playerProfile.NumBurbujasTotales1J +
                            "\n|    " + _playerProfile.NumBurbujasAzules1J +
                            "\n|    " + _playerProfile.NumBurbujasDoradas1J;

        PJugadores.SetActive(false);
        PEstadisticas.SetActive(true);
        PLogros.SetActive(false);

    }
    public void PantallaLogros()
    {
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(true);

    }


    

    //public void ActivarPantallaCarga()
    //{
    //    PCarga.SetActive(true);
    //}

    //public void DesactivarPantallaCarga()
    //{
    //    PCarga.SetActive(false);
    //}

    public void SceneMenu1J()
    {
        SceneManager.LoadScene("Menu1J");

    }

    public void SceneMenu2J()
    {
        SceneManager.LoadScene("Menu2J");

    }

    public void Salir()
    {
        Application.Quit();
    }





}
