using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginControler : MonoBehaviour
{
    //public Button LoginButton;
    public TextMeshProUGUI Usuario;
    public TextMeshProUGUI Contraseña;
    public TextMeshProUGUI Errores;

    public ScreenActionsSceneDatos ScreenActionsSceneDatos;

    void Start()
    {
        
    }

    //mongodb realmControler
    public async void Login()
    {
        Errores.text = "Iniciando sesion";
        ScreenActionsSceneDatos.ActivarPantallaCarga();

        if (await RealmController.Instance.Login(Usuario.text) != "")
        {
            Debug.Log("Entre");
            SceneManager.LoadScene("Menu");

        }
        else
        {
            Errores.text = "Error de logeo";
            ScreenActionsSceneDatos.DesactivarPantallaCarga();
        }
        
        

    }
}
