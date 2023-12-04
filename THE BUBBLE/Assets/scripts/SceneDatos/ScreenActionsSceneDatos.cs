using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScreenActionsSceneDatos : MonoBehaviour
{
     

    public GameObject PInicio;
    public GameObject PLogReg;
    public TextMeshProUGUI Titulo;
    public GameObject PInformacion;
    public GameObject PCarga;


    

    // Start is called before the first frame update
    void Start()
    {
        PantallaInicio();
        DesactivarPantallaCarga();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PantallaInicio()
    {
        PInicio.SetActive(true);
        PLogReg.SetActive(false);
        PInformacion.SetActive(false);
    }

    public void PantallaLog()
    {

        Titulo.text = "INICIO";
        PInicio.SetActive(false);
        PLogReg.SetActive(true);
        PInformacion.SetActive(false);
    }

    public void PantallaReg()
    {

        Titulo.text = "REGISTRO";
        PInicio.SetActive(false);
        PLogReg.SetActive(true);
        PInformacion.SetActive(false);
    }

    
    public void PantallaInformacion()
    {
        PInicio.SetActive(false);
        PLogReg.SetActive(false);
        PInformacion.SetActive(true);
    }

    public void ActivarPantallaCarga()
    {
        PCarga.SetActive(true);
    }

    public void DesactivarPantallaCarga()
    {
        PCarga.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

    








}
