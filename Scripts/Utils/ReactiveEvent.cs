using System;

namespace Utils
{
    /*public class ReactiveEvent : IObservable<Unit>
    {
        private event Action<Unit> Action;
       
        public void Invoke()
        {
            Action?.Invoke(default);
        }

        public IObservable<Unit> AsObservable() => Observable.FromEvent<Unit>(
            addHandler => Action += addHandler,
            removeHandler => Action -= removeHandler);

        public IDisposable Subscribe(IObserver<Unit> observer)
        {
            return AsObservable().Subscribe(observer);
        }
    }

    /// <summary>
    /// Реактивные эвенты предназначены для кейсов когда необходимо сообщить внешним слушателям
    /// о изменении внутреннего состояния или действиях без заботе о контроле жизненного цикла обмена сообщениями.
    /// Стоит использовать когда внешних слушателей мало и не требуется явно нотифицировать слушателей
    /// о завершении жизненого цикла наблюдаемого.
    /// В противном случае рекомендуется использовать ReactiveProperty\Subject и тп.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReactiveEvent<T> : IObservable<T>
    {
        private event Action<T> Action;

        public void Invoke(T value)
        {
            Action?.Invoke(value);
        }

        public IObservable<T> AsObservable() => Observable.FromEvent<T>(
            addHandler => Action += addHandler,
            removeHandler => Action -= removeHandler);

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return AsObservable().Subscribe(observer);
        }
    }*/
}