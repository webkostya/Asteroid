using System;
using Handlers.Common;
using UnityEngine;
using UI.Windows;
using UI.Windows.Common;

namespace Handlers
{
    public class GameHandler : MonoBehaviour
    {
        public event Action<GameState> OnStateEvent;

        public GameState State { get; private set; }

        public static GameHandler Instance { get; private set; }

        private static WindowBehaviour WindowBehaviour => WindowBehaviour.Instance;

        private void Awake()
        {
            Instance = this;

            SetState(GameState.Play);
        }

        /// <summary>
        /// Update Game State
        /// </summary>
        /// <param name="state"></param>
        public void SetState(GameState state)
        {
            State = state;

            Time.timeScale = State switch
            {
                GameState.Play => 1,
                GameState.Stop => 0,
                _ => 1
            };

            OnStateEvent?.Invoke(State);
        }

        /// <summary>
        /// Complete Game Event
        /// </summary>
        public void OnGameComplete()
        {
            WindowBehaviour.FadeWindow(WindowType.Complete, true);

            SetState(GameState.Stop);
        }
    }
}