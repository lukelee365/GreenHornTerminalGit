using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInPage : MonoBehaviour
{
    private GameObject _userNameField;
    private GameObject _wrongName;
    private GameObject _mainFiedInput;
    private GameObject _psdInvalid;
    // Use this for initialization
    private void Start()
    {
        _mainFiedInput = GameObject.Find("InputField_Password");
        _psdInvalid = GameObject.Find("Img_InvalidPassword");
        _wrongName = GameObject.Find("Img_InvalidName");
        _userNameField = GameObject.Find("InputField_Email");
        _wrongName.SetActive(false);
        _psdInvalid.SetActive(false);
    }

    public void Post()
    {
        Match();
    }

    //find the match for the replys
    public void Match()
    {
        _wrongName.SetActive(false);
        _psdInvalid.SetActive(false);
        var inputText = _mainFiedInput.GetComponent<InputField>().text.ToLower().Trim();
        var nameText = _userNameField.GetComponent<InputField>().text.ToLower().Trim();
        if (inputText == "password" && !string.IsNullOrEmpty(nameText))
        {
            SceneManager.LoadScene(1);
        }
        else if (inputText != "password" && string.IsNullOrEmpty(nameText))
        {
            _wrongName.SetActive(true);
            _psdInvalid.SetActive(true);
        }
        else if (inputText != "password")
        {
            _psdInvalid.SetActive(true);
        }
        else if (string.IsNullOrEmpty(nameText))
        {
            _wrongName.SetActive(true);
        }
    }
}