using System.Collections;

namespace Lessons_7_8;

/// <summary>
/// Мой список
/// </summary>
/// <typeparam name="T">Тип элементов списка</typeparam>
public class MyList<T>
{
    internal T[] _items;
    internal int _size;

    /// <summary>
    /// Инициализирует новый экземпляр MyList, который является пустым и имеет начальную емкость 0.
    /// </summary>
    public MyList()
    {
        _items = Array.Empty<T>();
        _size = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр MyList, который является пустым и имеет указанную начальную емкость.
    /// </summary>
    /// <param name="capacity">Количество элементов, которые новый список может первоначально сохранить.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public MyList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException();
        _items = new T[capacity];
        _size = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса, который содержит элементы, скопированные из указанной коллекции
    /// и обладает достаточной емкостью для размещения скопированных элементов.
    /// </summary>
    /// <param name="collection">Коллекция, элементы которой скопируются в новый список</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="collection" /> является <see langword="null" />.
    ///  </exception>
    public MyList(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException();
        _items = collection.ToArray();
        _size = collection.Count();
    }

    /// <summary>
    /// Возвращает или задаёт общее количество элементов, которое может содержать внутренняя структура данных
    /// без изменения размера
    /// </summary>
    /// <exception cref="T:System.ArgumentOutOfRangeException">Capacity задано меньше, чем Count.</exception>
    /// <exception cref="T:System.OutOfMemoryException">В системе недостаточно доступной памяти.</exception>
    /// <returns>Количество элементов, которые может содержать список до изменения размера.</returns>
    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _size)
                throw new ArgumentOutOfRangeException();
            if (value == _items.Length)
                return;
            if (value > 0)
            {
                var destinationArray = new T[value];
                if (_size > 0)
                    Array.Copy(_items, destinationArray, _size);
                _items = destinationArray;
            }
            else
                _items = Array.Empty<T>();
        }
    }

    /// <summary>
    /// Возвращает количество элементов, содержащихся в MyList
    /// </summary>
    public int Count => _size;

    /// <summary>Возвращает или устанавливает элемент с указанным индексом.</summary>
    /// <param name="index">Отсчитываемый c нуля индекс элемента, который нужно получить или установить.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index" /> меньше нуля либо больше или равен Count.
    /// </exception>
    public T this[int index]
    {
        get
        {
            if ((uint) index >= (uint) _size)
                throw new ArgumentOutOfRangeException();
            return _items[index];
        }
        set
        {
            if ((uint) index >= (uint) _size)
                throw new ArgumentOutOfRangeException();
            _items[index] = value;
        }
    }

    /// <summary>Добавляет объект в конец списка</summary>
    /// <param name="item">Объект, который нужно добавить в конец списка.</param>
    public void Add(T item)
    {
        if (_size < _items.Length)
        {
            _items[_size] = item;
            _size++;
        }
        else
            AddWithResize(item);
    }
    
    private void AddWithResize(T item)
    {
        Grow(_size + 1);
        _items[_size] = item;
        _size++;
    }

    private void Grow(int capacity)
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        if (newCapacity > Array.MaxLength)
            newCapacity = Array.MaxLength;
        else if (newCapacity < capacity)
            newCapacity = capacity;
        Capacity = newCapacity;
    }
    
    /// <summary>Удаляет первое вхождение определенного объекта из списка.</summary>
    /// <param name="item">Объект, который нужно удалить из списка.</param>
    /// <returns>
    /// <see langword="true" />, если <paramref name="item" /> успешно удален; в противном случае <see langword="false" />.
    /// Этот метод также возвращает <see langword="false" />, если <paramref name="item" /> не найден в списке.
    /// </returns>
    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index < 0)
            return false;
        RemoveAt(index);
        return true;
    }

    /// <summary>Удаляет элемент по указанному индексу из списка</summary>
    /// <param name="index">Отсчитываемый c нуля индекс удаляемого элемента.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="index" /> меньше 0 либо больше или равен Count.
    /// </exception>
    public void RemoveAt(int index)
    {
        if ((uint) index >= (uint) _size)
            throw new ArgumentOutOfRangeException();
        if (index < _size)
            Array.Copy(_items, index + 1, _items, index, _size - index - 1);
        _size--;
    }

    /// <summary>
    /// Выполняет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения во всем списке.
    /// </summary>
    /// <param name="item">Объект для поиска в списке.</param>
    /// <returns>
    /// Отсчитываемый от нуля индекс первого вхождения <paramref name="item" /> во всем списке, если он найден; иначе -1.
    /// </returns>
    public int IndexOf(T item) => Array.IndexOf(_items, item, 0, _size);
}