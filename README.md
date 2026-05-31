Запускается просто по кнопке Play в Unity.


Так как то что было в задаче реализованно, я ещё 2 часа потратил бы на улучшение визуальной состовляющей, например Анимация UI‑переходов (CanvasGroup fade). Добавить абстрактный класс AnimatedUIView : AbstractUIViewT<Tvm> с полями fadeDuration и методы FadeInAsync, FadeOutAsync (используют UniTask.Delay). Наследовать SplashUIView, LoadingUIView, MenuUIView от него. В EnterAsync/ExitAsync состояний вызывать соответствующий фейд вместо мгновенного SetActive. Поискать красивые спрайты для прогресс бара.

