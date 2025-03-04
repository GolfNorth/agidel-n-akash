using Cysharp.Threading.Tasks;
using Game.Interfaces.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Core
{
    /// <summary>
    /// General entry point of the game.
    /// </summary>
    public class GameEntryPoint : IStartable, ITickable
    {
        private readonly ISceneService _sceneService;

        public GameEntryPoint(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }
        
        public async void Start()
        {
            var sceneA = await _sceneService.LoadSceneAsync("SceneA", LoadSceneMode.Additive);
            var sceneB = await _sceneService.LoadSceneAsync("SceneB", LoadSceneMode.Additive);

            Debug.Log($"{sceneA.name}:{sceneA.buildIndex} {sceneB.name}:{sceneB.buildIndex}");

            await UniTask.WaitForSeconds(3f);

            _sceneService.UnloadSceneAsync(sceneA.name);
            _sceneService.UnloadSceneAsync(sceneB.name);
        }

        public void Tick()
        {
        }
    }
}