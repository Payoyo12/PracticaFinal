using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenActionsSceneMenu : MonoBehaviour
{

    public GameObject Fondo;
    public GameObject PJugadores;
    public GameObject PEstadisticas;
    public TextMeshProUGUI Estadisticas1j;
    public GameObject PLogros;



    // Start is called before the first frame update
    void Start()
    {

        Fondo.SetActive(true);
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


        Estadisticas1j.text = "|    " + RealmController.Instance.GetDataInt("NumPartidasJugadas1J") +
                            "\n|    " + RealmController.Instance.GetDataInt("NumPuntosTotales1J") +
                            "\n|    " + RealmController.Instance.GetDataInt("PuntuacionMax1J") +
                            "\n|    " + RealmController.Instance.GetDataInt("NumBurbujasTotales1J") +
                            "\n|    " + RealmController.Instance.GetDataInt("NumBurbujasAzules1J") +
                            "\n|    " + RealmController.Instance.GetDataInt("NumBurbujasDoradas1J");

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
