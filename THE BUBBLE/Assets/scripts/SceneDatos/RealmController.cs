using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Realms;
using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Threading.Tasks;
using JetBrains.Annotations;

public class RealmController : MonoBehaviour
{
    public static RealmController Instance;

    public string RealmAppId = "practicafinal-uefzc";
    private string _apiKey = "VWXk2SLX2PC087LdB1Y3EJKP50tVvMI2duqMYv7Mua0b2DB6PaRkpJ5Q80ULsQL9";

    private Realm _realm;
    private App _realmApp;
    private User _realmUser;
    private string _playerName;

    public PlayerProfile _playerProfile;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }

    void OnDisable()
    {
        if (_realm != null)
        {
            _realm.Dispose();
        }
    }

    //iniciar sesion
    public async Task<string> Login(string Usuario)
    {
        if (Usuario != "")
        {
            _playerName = Usuario;
            _realmApp = App.Create(new AppConfiguration(RealmAppId)
            {
                MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
            });
            try
            {
                if (_realmUser == null)
                {
                    _realmUser = await _realmApp.LogInAsync(Credentials.ApiKey(_apiKey));
                    var config = new FlexibleSyncConfiguration(_realmUser)
                    {
                        PopulateInitialSubscriptions = (realm) =>
                        {
                            var myItems = realm.All<PlayerProfile>();
                            realm.Subscriptions.Add(myItems);
                        }
                    };

                    _realm = await Realm.GetInstanceAsync(config);

                }
                else
                {
                    _realm = Realm.GetInstance(new FlexibleSyncConfiguration(_realmUser));

                }
            }
            catch (ClientResetException clientResetEx)
            {
                if (_realm != null)
                {
                    _realm.Dispose();
                }
                clientResetEx.InitiateClientReset();
            }
            return _realmUser.Id;
        }
        return "";
    }

    //cargar o crear datos del jugador
    public void InitPlayerProfile()
    {
        var playerQuery = _realm.All<PlayerProfile>().Where(n => n.Nombre == _playerName);
        if (playerQuery.Count() == 0)
        {
            _realm.Subscriptions.Update(() =>
            {
                var allUsers = _realm.All<PlayerProfile>();
                _realm.Subscriptions.Add(allUsers);
            });
            _playerProfile = _realm.Write(() => _realm.Add(new PlayerProfile(_playerName)));
        }
        else
        {
            _playerProfile = playerQuery.First();
        }
    }

    //Devuelve los datos del jugador
    public PlayerProfile GetPlayerProfile()
    {
        
        if (_playerProfile == null) InitPlayerProfile();
        return _playerProfile;
    }

    //actualiza un dato concreto Int
    public void UpdateDataInt(string tipo, int dato)
    {
        GetPlayerProfile();
        if (tipo == "PuntuacionTemporal1J")
        {
            _realm.Write(() => { _playerProfile.PuntuacionTemporal1J += dato; });
        }
        if (tipo == "NumPartidasJugadas1J")
        {
            _realm.Write(() => { _playerProfile.NumPartidasJugadas1J += dato; });
        }
        if (tipo == "NumPuntosTotales1J")
        {
            _realm.Write(() => { _playerProfile.NumPuntosTotales1J += dato; });
        }
        if (tipo == "PuntuacionMax1J")
        {
            _realm.Write(() => { _playerProfile.PuntuacionMax1J = dato; });
        }
        if (tipo == "NumBurbujasTotales1J")
        {
            _realm.Write(() => { _playerProfile.NumBurbujasTotales1J += dato; });
        }
        if (tipo == "NumBurbujasAzules1J")
        {
            _realm.Write(() => { _playerProfile.NumBurbujasAzules1J += dato; });
        }
        if (tipo == "NumBurbujasDoradas1J")
        {
            _realm.Write(() => { _playerProfile.NumBurbujasDoradas1J += dato; });
        }

    }

    //Devuelve un dato concreto Int
    public int GetDataInt(string tipo)
    {
        GetPlayerProfile();
        if (tipo == "PuntuacionTemporal1J")
        {
            return (int)_playerProfile.PuntuacionTemporal1J;
        }
        if (tipo == "NumPartidasJugadas1J")
        {
            return (int)_playerProfile.NumPartidasJugadas1J;
        }
        if (tipo == "NumPuntosTotales1J")
        {
            return (int)_playerProfile.NumPuntosTotales1J;
        }
        if (tipo == "PuntuacionMax1J")
        {
            return (int)_playerProfile.PuntuacionMax1J;
        }
        if (tipo == "NumBurbujasTotales1J")
        {
            return (int)_playerProfile.NumBurbujasTotales1J;
        }
        if (tipo == "NumBurbujasAzules1J")
        {
            return (int)_playerProfile.NumBurbujasAzules1J;
        }
        if (tipo == "NumBurbujasDoradas1J")
        {
            return (int)_playerProfile.NumBurbujasDoradas1J;
        }

        return 1234567890;
    }


    //actualiza un dato concreto Int
    public void resetearData(string tipo)
    {
        GetPlayerProfile();
        if (tipo == "PuntuacionTemporal1J")
        {
            _realm.Write(() => { _playerProfile.PuntuacionTemporal1J = 0; });
        }
        if (tipo == "NumPartidasJugadas1J")
        {
            _realm.Write(() => { _playerProfile.NumPartidasJugadas1J = 0; });
        }
        if (tipo == "NumPuntosTotales1J")
        {
            _realm.Write(() => { _playerProfile.NumPuntosTotales1J = 0; });
        }
        if (tipo == "PuntuacionMax1J")
        {
            _realm.Write(() => { _playerProfile.PuntuacionMax1J = 0; });
        }
        if (tipo == "NumBurbujasTotales1J")
        {
            _realm.Write(() => { _playerProfile.NumBurbujasTotales1J = 0; });
        }
        if (tipo == "NumBurbujasAzules1J")
        {
            _realm.Write(() => { _playerProfile.NumBurbujasAzules1J = 0; });
        }
        if (tipo == "NumBurbujasDoradas1J")
        {
            _realm.Write(() => { _playerProfile.NumBurbujasDoradas1J = 0; });
        }

    }
    
}