﻿/* Copyright © 2014 Apex Software. All rights reserved. */
namespace Apex.AI.Editor.UndoRedo
{
    using System;

    public class UndoRedoLog
    {
        private IUndoRedo[] _array;
        private int _head = -1;
        private int _tail = 0;
        private int? _current = null;
        private int _savePoint = -1;
        private int _savePointRelatedDelta;
        private bool _validSavePoint = true;

        public UndoRedoLog(int capacity)
        {
            _array = new IUndoRedo[capacity];
        }

        public bool canUndo
        {
            get { return _current.HasValue; }
        }

        public bool canRedo
        {
            get { return _head >= 0 && _current != _head; }
        }

        public bool isSavePoint
        {
            get { return _validSavePoint && (_savePoint == _current.GetValueOrDefault(-1)); }
        }

        public int savePointRelatedDelta
        {
            get { return _savePointRelatedDelta; }
        }

        public IUndoRedo lastEntry
        {
            get { return _current.HasValue ? _array[_current.Value] : null; }
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _array.Length);
            _tail = 0;
            _head = -1;
            _current = null;
            _validSavePoint = _validSavePoint && (_savePoint == -1);
        }

        public void SetSavePoint()
        {
            _savePoint = _current.GetValueOrDefault(-1);
        }

        public void InvalidateSavePoint()
        {
            _validSavePoint = false;
        }

        public IUndoRedo NextUndo()
        {
            if (!_current.HasValue)
            {
                return null;
            }

            var cur = _current.Value;
            _savePointRelatedDelta = ((cur > _head) && ((cur <= _savePoint) || (_savePoint <= _head))) || ((cur <= _savePoint) && (_savePoint <= _head)) ? 1 : -1;

            var op = _array[cur];

            if (_current == _tail)
            {
                _current = null;
            }
            else
            {
                _current--;
                if (_current < 0)
                {
                    _current = _array.Length - 1;
                }
            }

            return op;
        }

        public IUndoRedo NextRedo()
        {
            if (_current == _head || _head < 0)
            {
                return null;
            }

            _current = _current.HasValue ? (_current + 1) % _array.Length : _tail;

            var cur = _current.Value;
            _savePointRelatedDelta = ((cur > _head) && ((cur <= _savePoint) || (_savePoint <= _head))) || ((cur <= _savePoint) && (_savePoint <= _head)) ? -1 : 1;

            return _array[_current.Value];
        }

        public void Register(IUndoRedo op)
        {
            if (_current.HasValue)
            {
                bool prune = (_head != _current.Value);
                if (_savePoint > _current.Value)
                {
                    _validSavePoint = false;
                }

                _current = (_current + 1) % _array.Length;
                _head = _current.Value;

                if (prune)
                {
                    if (_tail < _head)
                    {
                        Array.Clear(_array, 0, _tail);

                        var top = _head + 1;
                        if (top < _array.Length)
                        {
                            Array.Clear(_array, top, _array.Length - top);
                        }
                    }
                    else if (_tail > _head)
                    {
                        Array.Clear(_array, _head + 1, _tail - _head - 1);
                    }
                }
                else if (_tail == _head)
                {
                    _tail++;
                }
            }
            else
            {
                Clear();
                _current = _head = 0;
            }

            _array[_current.Value] = op;
        }
    }
}