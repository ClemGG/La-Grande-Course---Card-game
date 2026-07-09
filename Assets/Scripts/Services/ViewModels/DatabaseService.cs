using System;
using Assets.Scripts.Cards;
using Assets.Scripts.Database;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Contient les méthodes CRUD d'interaction avec la BDD
    /// </summary>
    public static class DatabaseService
    {
        #region Méthodes statiques publiques

        /// <summary>
        /// Enregistre l'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <param name="admin">true si l'utilisateur a des droits administrateurs</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        public static async Awaitable RegisterAsync(string username, string password, bool admin, Action onComplete)
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
                throw new Exception(request.error);
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
        public static async Awaitable LoginAsync(string username, string password, Action<string> onComplete)
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
                throw new Exception(request.error);
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
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="decklistsJson">Decks du joueur</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        public static async Awaitable LogoutAsync(string username, string decklistsJson, Action onComplete)
        {
            WWWForm form = new();
            form.AddField("username", username);
            form.AddField("decklists", decklistsJson);

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
                throw new Exception(request.error);
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
        /// TODO: Charger les cartes depuis une bdd
        /// </summary>
        public static async Awaitable LoadCardsAsync()
        {
            GameAssets.RacerCards = Resources.LoadAll<RacerCardSO>("Cards/Racers");
            GameAssets.TrackCards = Resources.LoadAll<TrackCardSO>("Cards/Tracks");
            GameAssets.SkillCards = Resources.LoadAll<SkillCardSO>("Cards/Skills");
            GameAssets.EquipmentCards = Resources.LoadAll<EquipmentCardSO>("Cards/Equipments");
            GameAssets.RuseCards = Resources.LoadAll<RuseCardSO>("Cards/Ruses");
        }

#if UNITY_EDITOR

        /// <summary>
        /// Crée ou màj la carte dans la bdd
        /// </summary>
        /// <param name="card">La carte à mettre en ligne</param>
        /// <param name="onComplete">Appelée une fois l'opération terminée</param>
        public static async Awaitable CreateOrUpdateCardAsync(CardBaseSO card, Action onComplete)
        {
            WWWForm form = new();

            form.AddField("ID", card.ID);
            form.AddField("cardName", card.Name);
            form.AddField("effectDesc", card.EffectDescription);
            form.AddField("flavourDesc", card.FlavourDescription);
            form.AddField("purity", (int)card.Purity);

            switch (card)
            {
                case RacerCardSO racer:
                    form.AddField("cardTypeTableName", Constants.RACERS_CARDS_TABLE_NAME);
                    form.AddField("speed", racer.Stats.Speed);
                    form.AddField("style", racer.Stats.Style);
                    form.AddField("technique", racer.Stats.Technique);
                    break;
                case TrackCardSO track:
                    form.AddField("cardTypeTableName", Constants.TRACK_CARDS_TABLE_NAME);
                    form.AddField("speed", track.Stats.Speed);
                    form.AddField("style", track.Stats.Style);
                    form.AddField("technique", track.Stats.Technique);
                    break;
                case SkillCardSO skill:
                    form.AddField("cardTypeTableName", Constants.SKILL_CARDS_TABLE_NAME);
                    break;
                case EquipmentCardSO equip:
                    form.AddField("cardTypeTableName", Constants.EQUIP_CARDS_TABLE_NAME);
                    form.AddField("type", (int)equip.Type);
                    form.AddField("speed", equip.Stats.Speed);
                    form.AddField("style", equip.Stats.Style);
                    form.AddField("technique", equip.Stats.Technique);
                    break;
                case RuseCardSO ruse:
                    form.AddField("cardTypeTableName", Constants.RUSE_CARDS_TABLE_NAME);
                    form.AddField("speed", ruse.Stats.Speed);
                    form.AddField("style", ruse.Stats.Style);
                    form.AddField("technique", ruse.Stats.Technique);
                    break;
                default:
                    throw new Exception(string.Format(Constants.CARD_TYPE_NOT_IMPLEMENTED_ERR, card.Name, card.GetType()));
            }


            using UnityWebRequest request = UnityWebRequest.Post(Constants.CREATE_OR_UPDATE_CARD_URI, form);
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
                throw new Exception(request.error);
            else if (!string.IsNullOrEmpty(request.downloadHandler.text))
            {
                throw new Exception(request.downloadHandler.text);
            }
            else
            {
                onComplete?.Invoke();
            }
        }

#endif

        #endregion
    }
}