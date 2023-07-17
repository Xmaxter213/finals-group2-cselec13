using Dan.Main;
using Dan.Models;
using TMPro;
using UnityEngine;

namespace Dan.Demo
{
    public class LeaderboardShowcase : MonoBehaviour
    {
        //secret key: 0c8dd6ead88f33c76b15cae17d186ead60ef728a675fe292a1e9aeb060e5a81470ff67cac587761294822f8480f166033d13bc67cb8a749469aa06eaf7c9366fa821ef09dbe07d784cd2e9e77ff53e80222f4910bb8fd6b1a4823c741ad529ae9e54c6c32695c34779c2d77cb40393c67c3b65d7f273b358a01fb33fa898c32a
        [SerializeField] private string _leaderboardPublicKey;
        
        [SerializeField] private TextMeshProUGUI _playerScoreText;
        [SerializeField] private TextMeshProUGUI[] _entryFields;

        private string[] leaderboardList;
        
        [SerializeField] private TMP_InputField _playerUsernameInput;

        private float _playerScore;
        
        private void Start()
        {
            _playerScore = PlayerPrefs.GetFloat("scoreTutorial") + PlayerPrefs.GetFloat("score1") + PlayerPrefs.GetFloat("score2") + PlayerPrefs.GetFloat("score3");
            _playerScoreText.text = "Your score: " + _playerScore;
            Load();

            Debug.Log("Tutorial: " + PlayerPrefs.GetFloat("scoreTutorial") + "Level1: " + PlayerPrefs.GetFloat("score1") + "Level2: " + PlayerPrefs.GetFloat("score2") + "Level3: " + PlayerPrefs.GetFloat("score3"));
        }

        public void AddPlayerScore()
        {
            _playerScore++;
            _playerScoreText.text = "Your score: " + _playerScore;
        }
        
        public void Load() => LeaderboardCreator.GetLeaderboard(_leaderboardPublicKey, OnLeaderboardLoaded);

        private void OnLeaderboardLoaded(Entry[] entries)
        {
            foreach (var entryField in _entryFields)
            {
                entryField.text = "";
            }

            int count = entries.Length;

            for (int i = 0; i < entries.Length; i++)
            {
                _entryFields[i].text = $"{count}. {entries[i].Username} : {entries[i].Score} seconds";
                count--;
            }
        }

        public void Submit()
        {
            LeaderboardCreator.UploadNewEntry(_leaderboardPublicKey, _playerUsernameInput.text, Mathf.RoundToInt(_playerScore), Callback);
        }
        
        public void DeleteEntry()
        {
            LeaderboardCreator.DeleteEntry(_leaderboardPublicKey, Callback);
        }

        public void ResetPlayer()
        {
            LeaderboardCreator.ResetPlayer();
        }
        
        private void Callback(bool success)
        {
            if (success)
                Load();
        }
    }
}
