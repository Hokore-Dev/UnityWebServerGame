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
    
    public void Show(string inUserName, string inUserScore)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Co_RequestUser());
    }

    IEnumerator Co_RequestUser()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/index.php"))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
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
                for (int i=0;i< modelList.Count;i++)
                {
                    if (_cells.Length <= i)
                        break;

                    _cells[i].Bind(modelList[i]);
                }
            }
        }
    }
}
