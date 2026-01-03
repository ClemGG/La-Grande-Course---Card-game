using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class TestLoginMySQL : MonoBehaviour
{
    public GameObject _mainMenu, _loginMenu, _registerMenu, _gameMenu;
    public TextMeshProUGUI _scoreLabel, _welcomeLabel;
    public TMP_InputField _usernameFieldLogin, _passwordFieldLogin;
    public TMP_InputField _usernameFieldRegister, _passwordFieldRegister;

    private static string _username;
    private static int _score;
    private static bool LoggedIn => _username != null;

    public void Register()
    {
        StartCoroutine(RegisterCo());
    }

    public void Login()
    {
        StartCoroutine(LoginCo());
    }

    public void Logout()
    {
        StartCoroutine(LogoutCo());
    }

    public void GainPoints()
    {
        ++_score;
        _scoreLabel.text = $"Score: {_score}";
    }

    IEnumerator RegisterCo()
    {
        WWWForm form = new();
        form.AddField("username", _usernameFieldRegister.text);
        form.AddField("password", _passwordFieldRegister.text);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text != "0")
        {
            Debug.LogError(www.downloadHandler.text);
        }
        else
        {
            // Show results as text
            Debug.Log("User created succesfully");
            Debug.Log(www.downloadHandler.text);

            _registerMenu.SetActive(false);
            _gameMenu.SetActive(true);

            _username = _usernameFieldRegister.text;
            _score = 0;
            _welcomeLabel.text = $"Welcome, {_username}";
            _scoreLabel.text = $"Score: {_score}";
        }
    }

    IEnumerator LoginCo()
    {
        WWWForm form = new();
        form.AddField("username", _usernameFieldLogin.text);
        form.AddField("password", _passwordFieldLogin.text);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text[0] != '0')
        {
            Debug.LogError(www.downloadHandler.text);
        }
        else
        {
            // Show results as text
            Debug.Log("User logged in succesfully");
            Debug.Log(www.downloadHandler.text);

            _loginMenu.SetActive(false);
            _gameMenu.SetActive(true);

            _username = _usernameFieldLogin.text;
            _score = int.Parse(www.downloadHandler.text.Split('\n')[1]);
            _welcomeLabel.text = $"Welcome, {_username}";
            _scoreLabel.text = $"Score: {_score}";
        }
    }

    IEnumerator LogoutCo()
    {
        WWWForm form = new();
        form.AddField("username", _username);
        form.AddField("score", _score);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/saveData.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text != "0")
        {
            Debug.LogError(www.downloadHandler.text);
        }
        else
        {
            // Show results as text
            Debug.Log("Game saved successfully");
            Debug.Log(www.downloadHandler.text);

            _username = null;
            _gameMenu.SetActive(false);
            _mainMenu.SetActive(true);
        }
    }
}
