using System;
using System.Collections.Generic;
using Match3OOAP.GameLifeCycle.GameStateManagement;
using Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Match3OOAPTests
{
    [TestFixture]
    public class GameControllerTests
    {
        [Test]
        public void Constructor_NullArgument_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreateGameController(null));
        }
        
        [Test]
        public void Constructor_PassFactory_ControllerCreatedWithReadyState()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.ReadyToGame));
        }
        
        [Test]
        public void StartGame_WhenGameOnReadyState_GameStarted()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.StartedGame));
        }
        
        [Test]
        public void StartGame_WhenGameAlreadyStarted_GameStarted()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            gameController.StartGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.StartedGame));
        }
        
        [Test]
        public void StartGame_WhenGameFinished_GameStarted()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            GameState finishedStateStub = GetStateStub(GameStatus.FinishedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            gameStateFactoryStub.Setup(x => x.GetFinishedState(It.IsAny<GameController>()))
                .Returns(finishedStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            gameController.FinishGame();
            gameController.StartGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.StartedGame));
        }
        
        [Test]
        public void StartGame_WhenGameClosed_GameClosed()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            GameState finishedStateStub = GetStateStub(GameStatus.FinishedGame, true);
            GameState closedStateStub = GetStateStub(GameStatus.ClosedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            gameStateFactoryStub.Setup(x => x.GetFinishedState(It.IsAny<GameController>()))
                .Returns(finishedStateStub);
            gameStateFactoryStub.Setup(x => x.GetClosedState())
                .Returns(closedStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            gameController.FinishGame();
            gameController.CloseGame();
            gameController.StartGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.ClosedGame));
        }
        
        [Test]
        public void FinishGame_WhenGameStarted_GameFinished()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            GameState finishedStateStub = GetStateStub(GameStatus.FinishedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            gameStateFactoryStub.Setup(x => x.GetFinishedState(It.IsAny<GameController>()))
                .Returns(finishedStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            gameController.FinishGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.FinishedGame));
        }
        
        [Test]
        public void FinishGame_WhenGameReady_StateNotChanged()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState finishedStateStub = GetStateStub(GameStatus.FinishedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetFinishedState(It.IsAny<GameController>()))
                .Returns(finishedStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            GameStatus gameStatus = gameController.GetCurrentGameStatus();
            
            gameController.FinishGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(gameStatus));
        }
        
        [Test]
        public void CloseGame_WhenGameFinished_GameClosed()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState closeStateStub = GetStateStub(GameStatus.ClosedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetClosedState())
                .Returns(closeStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.CloseGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.ClosedGame));
        }
        
        [Test]
        public void CloseGame_WhenGameReady_GameClosed()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            GameState finishedStateStub = GetStateStub(GameStatus.FinishedGame, true);
            GameState closeStateStub = GetStateStub(GameStatus.ClosedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            gameStateFactoryStub.Setup(x => x.GetFinishedState(It.IsAny<GameController>()))
                .Returns(finishedStateStub);
            gameStateFactoryStub.Setup(x => x.GetClosedState())
                .Returns(closeStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            gameController.FinishGame();
            gameController.CloseGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.ClosedGame));
        }
        
        [Test]
        public void CloseGame_WhenGameStarted_StateNotChanged()
        {
            GameState readyStateStub = GetStateStub(GameStatus.ReadyToGame, true);
            GameState startedStateStub = GetStateStub(GameStatus.StartedGame, true);
            GameState closeStateStub = GetStateStub(GameStatus.ClosedGame, true);
            
            Mock<IGameStateFactory> gameStateFactoryStub = new Mock<IGameStateFactory>();
            gameStateFactoryStub.Setup(x => x.GetReadyState(It.IsAny<GameController>()))
                .Returns(readyStateStub);
            gameStateFactoryStub.Setup(x => x.GetRunState(It.IsAny<GameController>()))
                .Returns(startedStateStub);
            gameStateFactoryStub.Setup(x => x.GetClosedState())
                .Returns(closeStateStub);
            
            GameController gameController = CreateGameControllerWithMock(gameStateFactoryStub);
            
            gameController.StartGame();
            gameController.CloseGame();
            
            Assert.That(gameController.GetCurrentGameStatus(), Is.EqualTo(GameStatus.StartedGame));
        }

        public GameController CreateGameControllerWithStubFactory() =>
            new GameController(Mock.Of<IGameStateFactory>());
        
        public GameController CreateGameControllerWithMock(Mock<IGameStateFactory> gameStateFactoryMock) =>
            new GameController(gameStateFactoryMock.Object);
        
        public GameController CreateGameController(IGameStateFactory gameStateFactory) =>
            new GameController(gameStateFactory);

        private GameState GetStateStub(GameStatus status, bool isActive)
        {
            return  Mock.Of<GameState>(stateStub => stateStub.GameStatus == status
                                                    && stateStub.IsStateActive == isActive);
        }
    }
}