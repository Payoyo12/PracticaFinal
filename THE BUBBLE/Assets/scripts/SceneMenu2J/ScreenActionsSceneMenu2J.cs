using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenActionsSceneMenu2J : MonoBehaviour
{

    public GameObject PJugar;
    public GameObject PComenzandor;
    public TextMeshProUGUI Comenzando;

    private float Contador;
    private bool Temporizador;
    // Start is called before the first frame update
    void Start()
    {

        ReestablecerValores();
        //PantallaJugar();
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
                Comenzando.text = tiempoRedondeado.ToString();
            }
            else
            {
                ReestablecerValores();
                SceneGame2J();

            }

        }
    }

    private void ReestablecerValores()
    {
        Temporizador = false;
        Contador = 3;
        Comenzando.text = Contador.ToString();


    }

    public void PantallaJugar()
    {
        PJugar.SetActive(true);
        PComenzandor.SetActive(false);

    }

    public void PantallaComenzando()
    {

        PJugar.SetActive(false);
        PComenzandor.SetActive(true);
        Temporizador = true;

    }

    private void SceneGame2J()
    {
        SceneManager.LoadScene("Game2J");

    }

    public void SceneMenu()
    {
        SceneManager.LoadScene("Menu");

    }





















}
