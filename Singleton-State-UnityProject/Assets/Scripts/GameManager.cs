using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Chapter.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        private void Start()
        {
            // stuff that may go here later...

            _sessionStartTime = DateTime.Now;
            Debug.Log("We started at: " + DateTime.Now);

        }

        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;

            TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

            Debug.Log("Session ended: " + DateTime.Now);
            Debug.Log("Session Lasted: " +  timeDifference);
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(80, 0, 80, 80));
            if (GUILayout.Button("Next Scene"))
            {
                int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

                if (sceneIndex < 5)
                    SceneManager.LoadScene(sceneIndex);
                else
                    SceneManager.LoadScene(0);

            }
            GUILayout.EndArea();
        }
    }
}
