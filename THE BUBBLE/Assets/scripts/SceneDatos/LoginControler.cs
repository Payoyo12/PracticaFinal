using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginControler : MonoBehaviour
{
    public Button LoginButton;
    public TextMeshProUGUI Usuario;
    public TextMeshProUGUI Contrase�a;
    public TextMeshProUGUI Errores;

    public ScreenActionsSceneDatos ScreenActionsSceneDatos;

    void Start()
    {
        Usuario.text = "clasedepoyo@gmail.com";
        Contrase�a.text = "Clasedeluis12";
        LoginButton.onClick.AddListener(Login);
    }

    //mongodb realmControler
    public async void Login()
    {
        Errores.text = "Iniciando sesion";
        ScreenActionsSceneDatos.ActivarPantallaCarga();
        if (await RealmController.Instance.Login(Usuario.text, Contrase�a.text) != "")
        {

            //CargarDatos();
            SceneManager.LoadScene("Menu");
        }
        else
        {
            ScreenActionsSceneDatos.DesactivarPantallaCarga();
        }

    }
}
