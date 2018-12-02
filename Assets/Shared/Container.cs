using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace SA
{
    public class Container : MonoBehaviour
    {
        #region Class.
        [System.Serializable]
        public class ContainerItem
        {
            #region Variable.
            // System Guid.
            public System.Guid _id;
            // string.
            public string _name;
            // int.
            public int _maximum;

            public int _amountTaken;

            public int _remaining
            {
                get
                {
                    return _maximum - _amountTaken;
                }
            }

            // .
            public ContainerItem()
            {
                _id = System.Guid.NewGuid();
            }

            #endregion

            #region Get.
            public int Get(int value)
            {
                if ((_amountTaken + value) > _maximum)
                {
                    int toMuch = (_amountTaken + value) - _maximum;
                    _amountTaken = _maximum;
                    return value - toMuch;
                }
                _amountTaken += value;

                return value;
            }
            #endregion

            #region Set.
            public void Set(int amount)
            {
                _amountTaken -= amount;
                if (_amountTaken < 0)
                {
                    _amountTaken = 0;
                }

            }
            #endregion
        }
        #endregion

        #region Variable.
        // List.
        public List<ContainerItem> _items;

        // Event.
        public event System.Action _onContainerReady;

        // Class.
        private ContainerItem _containerItem;
        #endregion

        #region Awake.
        private void Awake()
        {
            _items = new List<ContainerItem>();

            if (_onContainerReady != null)
            {
                _onContainerReady();
            }
        }
        #endregion

        #region Add.
        public System.Guid Add(string name, int maximum)
        {
            _items.Add(new ContainerItem
            {
                _id = System.Guid.NewGuid(),
                _maximum = maximum,
                _name = name
            });

            return _items.Last()._id;
        }
        #endregion

        #region Put.
        public void Put(string name, int amount)
        {
            ContainerItem containerItem = _items.Where(x => x._name == name).FirstOrDefault();
            if (containerItem == null)
            {
                return;
            }
            containerItem.Set(amount);
        }
        #endregion

        #region Take From Container 
        public int TakeFromContainer(System.Guid id, int amount)
        {
            ContainerItem containerItem = GetContainerItem(id);
            if (containerItem == null)
            {
                return -1;
            }

            return containerItem.Get(amount);
        }
        #endregion

        #region Get Amount Remaining.
        public int GetAmountRemaining(System.Guid id)
        {
            ContainerItem containerItem = GetContainerItem(id);
            if (containerItem == null)
            {
                return -1;
            }

            return containerItem._remaining;
        }
        #endregion

        #region Get Container Item.
        private ContainerItem GetContainerItem(System.Guid id)
        {
            _containerItem = _items.Where(x => x._id == id).FirstOrDefault();
            return _containerItem;
        }
        #endregion
    }
}

