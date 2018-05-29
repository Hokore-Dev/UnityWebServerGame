using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        int i = 1;
        foreach (var cell in _cells)
        {
            cell.Bind(new ServerModel()
            {
                name = "TEST_" + i.ToString(),
                score =  Random.Range((7 - i) * 100, (8 - i) * 100)
            });
            i++;
        }
    }
}
