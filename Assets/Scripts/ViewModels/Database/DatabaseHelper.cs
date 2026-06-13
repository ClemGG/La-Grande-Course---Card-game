using System;
using Assets.Scripts.Models.Cards;
using Assets.Scripts.Models.Database;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.ViewModels.Database
{
    /// <summary>
    /// Contient les méthodes CRUD d'interaction avec la BDD
    /// </summary>
    internal static class DatabaseHelper
    {
        #region Méthodes statiques publiques

        /// <summary>
        /// Enregistre l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        internal static async Awaitable RegisterAsync(string username, string password, bool admin, Action onComplete)
        {
            WWWForm form = new();
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("admin", admin ? 1 : 0);

            using UnityWebRequest request = UnityWebRequest.Post(Constants.REGISTER_URI, form);
            await Awaitable.FromAsyncOperation(request.SendWebRequest(), Application.exitCancellationToken);

            //switch (request.result)
            //{
            //    case UnityWebRequest.Result.ConnectionError:
            //        UnityEngine.Debug.Log("Connection Error: " + request.error);
            //        break;
            //    case UnityWebRequest.Result.ProtocolError:
            //        UnityEngine.Debug.Log("Protocol Error: " + request.error);
            //        break;
            //    case UnityWebRequest.Result.DataProcessingError:
            //        UnityEngine.Debug.Log("Data Processing Error: " + request.error);
            //        break;
            //}

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new Exception(request.error);
            }
            else if (!string.IsNullOrEmpty(request.downloadHandler.text))
            {
                throw new Exception(request.downloadHandler.text);
            }
            else
            {
                onComplete?.Invoke();
            }
        }

        /// <summary>
        /// Connecte l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        internal static async Awaitable LoginAsync(string username, string password, Action<string> onComplete)
        {
            WWWForm form = new();
            form.AddField("username", username);
            form.AddField("password", password);

            using UnityWebRequest request = UnityWebRequest.Post(Constants.LOGIN_URI, form);
            await Awaitable.FromAsyncOperation(request.SendWebRequest(), Application.exitCancellationToken);

            //switch (request.result)
            //{
            //    case UnityWebRequest.Result.ConnectionError:
            //        UnityEngine.Debug.Log("Connection Error: " + request.error);
            //        break;
            //    case UnityWebRequest.Result.ProtocolError:
            //        UnityEngine.Debug.Log("Protocol Error: " + request.error);
            //        break;
            //    case UnityWebRequest.Result.DataProcessingError:
            //        UnityEngine.Debug.Log("Data Processing Error: " + request.error);
            //        break;
            //}

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new Exception(request.error);
            }
            else if (!string.IsNullOrEmpty(request.downloadHandler.text) && request.downloadHandler.text[0] != '0')
            {
                throw new Exception(request.downloadHandler.text);
            }
            else
            {
                onComplete?.Invoke(request.downloadHandler.text);
            }
        }

        /// <summary>
        /// Déconnecte l'utilisateur
        /// </summary>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        internal static async Awaitable LogoutAsync(Action onComplete)
        {
            WWWForm form = new();

            using UnityWebRequest request = UnityWebRequest.Post(Constants.LOGOUT_URI, form);
            await Awaitable.FromAsyncOperation(request.SendWebRequest(), Application.exitCancellationToken);

            //switch (request.result)
            //{
            //    case UnityWebRequest.Result.ConnectionError:
            //        UnityEngine.Debug.Log("Connection Error: " + request.error);
            //        break;
            //    case UnityWebRequest.Result.ProtocolError:
            //        UnityEngine.Debug.Log("Protocol Error: " + request.error);
            //        break;
            //    case UnityWebRequest.Result.DataProcessingError:
            //        UnityEngine.Debug.Log("Data Processing Error: " + request.error);
            //        break;
            //}

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new Exception(request.error);
            }
            else if (!string.IsNullOrEmpty(request.downloadHandler.text))
            {
                throw new Exception(request.downloadHandler.text);
            }
            else
            {
                onComplete?.Invoke();
            }
        }

        /// <summary>
        /// Charge les cartes depuis le dossier Resources
        /// </summary>
        internal static async Awaitable LoadCardsAsync()
        {
            GameAssets.RacerCards = Resources.LoadAll<RacerCardSO>("Cards/Racers");
            GameAssets.TrackCards = Resources.LoadAll<TrackCardSO>("Cards/Tracks");
            GameAssets.SkillCards = Resources.LoadAll<SkillCardSO>("Cards/Skills");
            GameAssets.EquipmentCards = Resources.LoadAll<EquipmentCardSO>("Cards/Equipments");
            GameAssets.RuseCards = Resources.LoadAll<RuseCardSO>("Cards/Ruses");
        }

        #endregion
    }
}