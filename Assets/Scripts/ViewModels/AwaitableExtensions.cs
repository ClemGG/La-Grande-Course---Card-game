using System;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
    /// <summary>
    /// Méthodes d'extension pour les Awaitables
    /// </summary>
    public static class AwaitableExtensions
    {
        /// <summary>
        /// Permet de récupérer les exceptions jetées par les Awaitables
        /// </summary>
        /// <param name="awaitable">La méthode async</param>
        /// <param name="onError">Appelée quand une exception est levée</param>
        public static void WaitForResult(this Awaitable awaitable, Action<Exception> onError)
        {
            Awaitable.Awaiter awaiter = awaitable.GetAwaiter();

            if (awaitable.IsCompleted)
            {
                try
                {
                    awaiter.GetResult();
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);
                    //throw ex;
                }
            }
            else
            {
                awaiter.OnCompleted(() =>
                {
                    try
                    {
                        awaiter.GetResult();
                    }
                    catch (Exception ex)
                    {
                        onError?.Invoke(ex);
                        //throw ex;
                    }
                });
            }
        }
    }
}