using System;
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
            form.AddField("serverName", Constants.SERVER_NAME);
            form.AddField("serverLogin", Constants.SERVER_LOGIN);
            form.AddField("serverPwd", Constants.SERVER_PASSWORD);
            form.AddField("databaseName", Constants.DATABASE_NAME);
            form.AddField("tableName", Constants.USERS_TABLE);
            form.AddField("username", username);
            form.AddField("password", password);
            form.AddField("admin", admin ? 1 : 0);

            using UnityWebRequest request = UnityWebRequest.Post(Constants.REGISTER_URI, form);
            await Awaitable.FromAsyncOperation(request.SendWebRequest(), Application.exitCancellationToken);

            if (request.result == UnityWebRequest.Result.ConnectionError)
                UnityEngine.Debug.Log("Connection Error: " + request.error);
            if (request.result == UnityWebRequest.Result.ProtocolError)
                UnityEngine.Debug.Log("Protocol Error: " + request.error);
            if (request.result == UnityWebRequest.Result.DataProcessingError)
                UnityEngine.Debug.Log("data Error: " + request.error);

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new Exception(request.error);
            }
            else
            {
                onComplete?.Invoke();
            }
        }


        #endregion
    }
}