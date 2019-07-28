using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;

public class RankView : MonoBehaviour 
{
    [System.Serializable]
    public class UserCell
    {
        [SerializeField] private Text _txtName;
        [SerializeField] private Text _txtScore;

        public void Bind(ServerModel inServerModel)
        {
            _txtName.text = inServerModel.name;
            _txtScore.text = inServerModel.score.ToString();
            
            _txtName.gameObject.SetActive(true);
            _txtScore.gameObject.SetActive(true);
        }
    }

    [SerializeField] private UserCell[] _cells;
    [SerializeField] private string _serverURL;
    
    public void Show(string inUserName, string inUserScore)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Co_RequestUser(inUserName, inUserScore));
    }

    IEnumerator Co_RequestUser(string inUserName, string inUserScore)
    {
        string url = string.Format("{0}/RegistScore.php?name={1}&score={2}", _serverURL,inUserName, inUserScore);
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.LogError(www.error);
            }
        }

        using (UnityWebRequest www = UnityWebRequest.Get(string.Format("{0}/index.php", _serverURL)))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                string data = www.downloadHandler.text;
                SimpleJSON.JSONNode jn = SimpleJSON.JSONNode.Parse(data);
                SimpleJSON.JSONArray array = jn.AsArray;

                List<ServerModel> modelList = new List<ServerModel>();
                for (int i = 0; i < array.Count; i++)
                {
                    modelList.Add(new ServerModel()
                    {
                        name = array[i]["name"],
                        score = array[i]["score"].AsInt,
                    });
                }

                modelList = modelList.OrderByDescending(x => x.score).ToList();
                for (int i = 0; i < modelList.Count; i++)
                {
                    if (_cells.Length <= i)
                        break;

                    _cells[i].Bind(modelList[i]);
                }
            }
        }
    }
}
