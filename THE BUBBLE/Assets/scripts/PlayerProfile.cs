using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;

public class PlayerProfile : RealmObject
{

    [PrimaryKey]
    [MapTo("_id")]
    public string UserId { get; set; }

    [MapTo("PuntuacionTemporal1J")]
    public int PuntuacionTemporal1J { get; set; }

    [MapTo("NumPartidasJugadas1J")]
    public int NumPartidasJugadas1J { get; set; }

    [MapTo("NumPuntosTotales1J")]
    public int NumPuntosTotales1J { get; set; }


    [MapTo("PuntuacionMax1J")]
    public int PuntuacionMax1J { get; set; }


    [MapTo("NumBurbujasTotales1J")]
    public int NumBurbujasTotales1J { get; set; }


    [MapTo("NumBurbujasAzules1J")]
    public int NumBurbujasAzules1J { get; set; }


    [MapTo("NumBurbujasDoradas1J")]
    public int NumBurbujasDoradas1J { get; set; }

    public PlayerProfile() { }

    public PlayerProfile(string userId)
    {
        this.UserId = userId;
        this.PuntuacionTemporal1J = 0;
        this.NumPartidasJugadas1J = 0;
        this.NumPuntosTotales1J = 0;
        this.PuntuacionMax1J = 0;
        this.NumBurbujasTotales1J = 0;
        this.NumBurbujasAzules1J = 0;
        this.NumBurbujasDoradas1J = 0;
    }













}
