using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MongoDB.Bson;
using UnityEngine;
using Realms;
using Realms.Sync;

public partial class PlayerProfile : RealmObject
{

    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId UserId { get; set; }
    [CanBeNull] public string Nombre { get; set; }
    public int? PuntuacionTemporal1J { get; set; }
    public int? NumPartidasJugadas1J { get; set; }
    public int? NumPuntosTotales1J { get; set; }
    public int? PuntuacionMax1J { get; set; }
    public int? NumBurbujasTotales1J { get; set; }
    public int? NumBurbujasAzules1J { get; set; }
    public int? NumBurbujasDoradas1J { get; set; }

    public PlayerProfile() { }

    public PlayerProfile(string nombre)
    {
        this.UserId = ObjectId.GenerateNewId();
        this.Nombre = nombre;
        this.PuntuacionTemporal1J = 0;
        this.NumPartidasJugadas1J = 0;
        this.NumPuntosTotales1J = 0;
        this.PuntuacionMax1J = 0;
        this.NumBurbujasTotales1J = 0;
        this.NumBurbujasAzules1J = 0;
        this.NumBurbujasDoradas1J = 0;
    }
}
