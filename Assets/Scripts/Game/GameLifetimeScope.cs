using Core.StateMachine;
using Game.Loading;
using Game.Menu;
using Game.Settings;
using Game.Splash;
using Game.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Settings")] 
        [SerializeField] private LoadingSettings loadingSettings;
        [SerializeField] private SplashSettings splashSettings;
        [Header("View")] 
        [SerializeField] private SplashUIView splashUIView;
        [SerializeField] private LoadingUIView loadingView;
        [SerializeField] private MenuUIView menuView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(loadingSettings);
            builder.RegisterInstance(splashSettings);

            builder.RegisterInstance(splashUIView);
            builder.RegisterInstance(loadingView);
            builder.RegisterInstance(menuView);

            builder.Register<LoadingViewModel>(Lifetime.Singleton);
            builder.Register<MenuViewModel>(Lifetime.Singleton);
            builder.Register<SplashViewModel>(Lifetime.Singleton);

            builder.Register<StatesController<GameState>>(Lifetime.Singleton).As<IStatesController<GameState>>();

            builder.Register<SplashState>(Lifetime.Singleton);
            builder.Register<LoadState>(Lifetime.Singleton);
            builder.Register<MenuState>(Lifetime.Singleton);

            builder.RegisterBuildCallback(container =>
            {
                var machine =
                    (StatesController<GameState>)
                    container.Resolve<IStatesController<GameState>>();

                var splashVm = container.Resolve<SplashViewModel>();
                var loadVm = container.Resolve<LoadingViewModel>();
                var menuVm = container.Resolve<MenuViewModel>();

                var splashView = container.Resolve<SplashUIView>();
                var loadView = container.Resolve<LoadingUIView>();
                var menuUIView = container.Resolve<MenuUIView>();

                splashView.Construct(splashVm);
                loadView.Construct(loadVm);
                menuUIView.Construct(menuVm);

                machine.RegisterState(GameState.Splash, container.Resolve<SplashState>());
                machine.RegisterState(GameState.Load, container.Resolve<LoadState>());
                machine.RegisterState(GameState.Menu, container.Resolve<MenuState>());
            });

            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}