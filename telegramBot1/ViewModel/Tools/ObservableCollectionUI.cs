using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;


namespace FISHY.ViewModel
{
    public class ObservableCollectionUI<T>: ObservableCollection<T>
    {
        public void ActionUI(Action action)
            => Application.Current.Dispatcher.BeginInvoke(action, null);
        public TResult ActionUI<TResult>(Func<TResult> func)
            => (TResult)Application.Current.Dispatcher.Invoke(func, null);
        public void AddUI(T item) => ActionUI(() => Add(item));
        public void AddRangeUI(IEnumerable<T> items)
            => ActionUI(() =>
            {
                foreach (T item in items)
                    Add(item);
            });
        public bool RemoveUI(T item) => ActionUI(() => Remove(item));
        public bool TryRemoveAtUI(int index) => ActionUI(() =>
        {
            try
            {
                RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        });
        public IEnumerable<bool> RemoveRangeUI(IEnumerable<T> items)
            => ActionUI(() =>
            {
                List<bool> list = new List<bool>();
                foreach (T item in items)
                    list.Add(Remove(item));
                return list;
            });
        public void ClearUI() => ActionUI(() => Clear());
        private ObservableCollection<T> _source;
        public ObservableCollection<T> Source
        {
            get => _source;
            set
            {
                if (_source == value)
                    return;
                if (_source != null)
                    _source.CollectionChanged -= CollectionChangedMetod;
                _source = value;
                ClearUI();
                if (_source != null)
                {
                    _source.CollectionChanged += CollectionChangedMetod;
                    AddRangeUI(_source);
                }
            }
        }
        protected virtual void CollectionChangedMetod(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.NewItems != null)
                AddRangeUI(e.NewItems.OfType<T>());
            if (e.OldItems != null)
                RemoveRangeUI(e.OldItems.OfType<T>());
        }
    }
}
