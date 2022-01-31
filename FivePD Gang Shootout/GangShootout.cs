using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;

namespace GangWar
{
    [CalloutProperties("Gang War", "GGGDunlix", "0.0.3")]
    public class DrugDeal : Callout
    {
        private Ped a1, a2, a3, a4, a5, b1, b2, b3, b4, b5;
        private Vector3[] coordinates = {
            new Vector3(1643.944f, 3661.229f, 34.81307f),
            new Vector3(1753.082f, 3323.329f, 41.1927f),
            new Vector3(2038.826f, 3180.503f, 45.18373f),
            new Vector3(2101.489f, 2339.281f, 94.28531f),
new Vector3(2133.351f, 1936.308f, 93.787f),
new Vector3(1867.963f, 276.5102f, 162.2581f),
new Vector3(1668.3f, -24.04993f, 173.7749f),
new Vector3(1040.255f, -278.2421f, 50.49659f),
new Vector3(627.0389f, 622.6951f, 128.91f),
new Vector3(-131.7528f, -977.7662f, 27.27535f),
new Vector3(-150.9877f, -959.6083f, 21.27699f),
new Vector3(-144.1955f, -1180.403f, 25.14136f),
new Vector3(-183.437f, -1288.24f, 31.29586f),
new Vector3(103.7896f, -1938.95f, 20.46761f),
new Vector3(869.5767f, -908.5933f, 25.52387f),
new Vector3(710.0289f, 145.0581f, 80.42306f),
new Vector3(31.1657f, -417.6073f, 39.5914f),
new Vector3(-449.648f, -1037.457f, 23.22751f),
new Vector3(-1518.406f, -554.1187f, 32.84311f),
new Vector3(-1652.251f, -913.8225f, 8.138891f),
new Vector3(-1264.669f, -1120.037f, 7.147743f),
new Vector3(-843.1774f, -1050.592f, 10.8462f),
new Vector3(-683.6492f, -885.8746f, 24.16776f),
new Vector3(-99.80907f, -1028.296f, 26.94503f),
new Vector3(18.02932f, -1062.308f, 37.82656f),
new Vector3(460.3688f, -591.0359f, 28.17297f),
new Vector3(282.0897f, -200.7316f, 61.23898f),
new Vector3(-111.2661f, -204.182f, 44.73214f),
new Vector3(-448.3635f, -451.1277f, 32.6615f),
new Vector3(-383.6143f, -118.9606f, 38.3573f),
new Vector3(-387.1316f, -66.74353f, 54.09364f),
        };

        public DrugDeal()
        {
            Vector3 location = coordinates.OrderBy(x => World.GetDistance(x, Game.PlayerPed.Position)).Skip(3).First();

            InitInfo(location);
            ShortName = "Gang Shootout";
            CalloutDescription = "A Gang Shootout is in progress. Get to the location, assess any injuries, and arrest any suspects. Respond in Code 3 High.";
            ResponseCode = 3;
            StartDistance = 60f;
        }
        
        public async override Task OnAccept()
        {

            var suspects = new[]
            {
                PedHash.MexGang01GMY,
                PedHash.RampGang,
                PedHash.BallaEast01GMY,
                PedHash.BallaOrig01GMY,
                PedHash.Ballas01GFY,
                PedHash.Ballasog,
                PedHash.BallaSout01GMY,
                PedHash.Franklin,
                PedHash.LamarDavis,
                PedHash.Trevor,
                PedHash.RampMex,
                PedHash.MexThug01AMY,
                PedHash.MexGoon01GMY,
                PedHash.Vagos01GFY,
                PedHash.VagosFun01,
                PedHash.VagosSpeak,
                PedHash.PestContGunman,
                PedHash.Chef,
                PedHash.CocaineFemale01,
                PedHash.CounterfeitFemale01,
                PedHash.MethFemale01,
                PedHash.WeedFemale01,
                PedHash.WeedMale01
            };
            var a = new[]
            {
                a1,
                a2,
                a3,
                a4,
                a5
            };
            var b = new[]
           {
                b1,
                b2,
                b3,
                b4,
                b5
            };

            InitBlip();
            UpdateData();
            a1 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            a2 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            a3 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            a4 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            a5 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            b1 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            b2 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            b3 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            b4 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);
            b5 = await SpawnPed(suspects[RandomUtils.Random.Next(suspects.Length)], Location);

            a1.Weapons.Give(WeaponHash.APPistol, 9999, true, true);
            a2.Weapons.Give(WeaponHash.SMGMk2, 9999, true, true);
            a3.Weapons.Give(WeaponHash.PumpShotgunMk2, 9999, true, true);
            a4.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
            a5.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);

            b1.Weapons.Give(WeaponHash.APPistol, 9999, true, true);
            b2.Weapons.Give(WeaponHash.AssaultSMG, 9999, true, true);
            b3.Weapons.Give(WeaponHash.PumpShotgunMk2, 9999, true, true);
            b4.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
            b5.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);

        }

        public override void OnStart(Ped player)
        {
            base.OnStart(player);
            a1.AttachBlip();
            a2.AttachBlip();
            a3.AttachBlip();
            a4.AttachBlip();
            a5.AttachBlip();
            b1.AttachBlip();
            b2.AttachBlip();
            b3.AttachBlip();
            b4.AttachBlip();
            b5.AttachBlip();
            
            API.Hate
            

        }
    }


}