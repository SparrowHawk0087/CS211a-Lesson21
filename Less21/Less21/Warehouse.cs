using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less21
{
    internal class Warehouse
    {

        private Dictionary<string, int> _storage = new Dictionary<string, int>();
        public int this[string index]
        {
            get
            { 
                if (_storage.ContainsKey(index))
                    return _storage[index];
                return -1;
            }
            set 
            { 
               if (value < 0 || !_storage.ContainsKey(index))
                    throw new ArgumentException(nameof(_storage));
               _storage[index] = value;
            }
        }

        public Warehouse()
        { 
            
        }

        public void AddProduct(string id, int amount)
        { 
            if (!_storage.ContainsKey(id))
                _storage[id] = amount;
            _storage[id] += amount;
        }

        public void PickUpProduct(string id, int amount)
        {
            if (!_storage.ContainsKey(id) || _storage[id] < amount)
                throw new ArgumentException(nameof(amount));
            _storage[id] -= amount;
        }

    }
}
