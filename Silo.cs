using System;
using System.Collections.Generic;
using System.Text;

namespace Oefening1_Silo
{
    class Silo
    {
        //instantievariabelen
        private int _iCapacity; // de capaciteit van de silo
        private int _iContent; //inhoud van de silo
        private bool _iCleaned;

        public Silo(int iCapacity)
        {
            _iCapacity = iCapacity;
            _iContent = iCapacity / 2;
            _iCleaned = false;
        }


        //getters en setters
        public int Capacity { get => _iCapacity; set => _iCapacity = value; }
        public int Content { get => _iContent; set => _iContent = value; }
        public bool Cleaned { get => _iCleaned; set => _iCleaned = value; }

        
        //methoden die gekoppeld zijn aan silo
        public string Load(int quantity)
        {
            string sValue = null;
            if (_iContent == 0)
            {
                if (this._iCleaned)
                {
                    if (quantity + _iContent <= _iCapacity)
                    {
                        _iContent += quantity;
                    }
                    else
                    {
                        sValue = $"Niet genoeg ruimte om te laden\r\nEr is maar plaats voor {_iCapacity - _iContent} units meer";
                    }
                    _iCleaned = false;
                }
                else
                {
                    sValue = "De silo is niet schoongemaakt.";
                }
            }
            else
            {
                if (quantity + _iContent <= _iCapacity)
                {
                    _iContent += quantity;
                }
                else
                {
                    sValue = $"Niet genoeg ruimte om te laden\r\nEr is maar plaats voor {_iCapacity - _iContent} units meer";
                }
                _iCleaned = false;
            }
            return sValue;
        }


        public string Unload(int quantity)
        {
            string sValue = null;

            if (quantity <= _iContent)
            {
                _iContent -= quantity;
            }
            else
            {
                sValue = $"Niet genoeg units in silo om te ontladen\r\nEr zijn maar {_iContent} units meer aanwezig";
            }

            return sValue;
        }

    }
}
