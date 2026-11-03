using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bank
{
    internal class KontoBankowe
    {
        private static int _licznikKont = 0;

        private decimal _saldo;

        private string _numer { get; } // generowany automatycznie przy tworzeniu konta

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public KontoBankowe()
        {
            _licznikKont++;
            _numer = $"PL{_licznikKont:D10}";
        }
        public void Wplac(decimal kwota)
        {
            if (kwota <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(kwota), "Kwota wpłaty musi być dodatnia.");
            }

            _saldo += kwota;
        }

        public decimal StanKonta()
        {
            return _saldo;
        }
    }
}
