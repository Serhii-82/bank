using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace bank
{
    internal class Automat
    {
        private int _iloscMonet;
        private readonly decimal[] _przyjmowaneMonety = new decimal[] { 5, 2, 1, 0.5m, 0.2m, 0.1m };

        // Stwórz metodę WrzucMonete
        private readonly Dictionary<decimal, int> _iloscMonet = new Dictionary<decimal, int>();

        public Automat()
        {
            foreach (decimal nominal in _przyjmowaneMonety)
            {
                _iloscMonet[nominal] = 0;
            }
        }

        public void WrzucMonete(KontoBankowe konto, string moneta)
        {
            // Kropka jako separator dziesiętny, niezależnie od ustawień komputera
            bool czyUdanyParse = decimal.TryParse(
                moneta,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out decimal wartosc);

            if (!czyUdanyParse)
            {
                Console.WriteLine($"Nieudany odczyt monety: \"{moneta}\".");
                return;
            }

            if (!_iloscMonet.ContainsKey(wartosc))
            {
                Console.WriteLine($"Zła moneta: {Formatuj(wartosc)}.");
                return;
            }

            konto.Wplac(wartosc);
            _iloscMonet[wartosc]++;
            Console.WriteLine($"Moneta przyjęta: {Formatuj(wartosc)}.");
        }

        public void PokazMonety()
        {
            decimal suma = 0;

            Console.WriteLine("Monety w automacie:");
            foreach (decimal nominal in _przyjmowaneMonety)
            {
                int ilosc = _iloscMonet[nominal];
                suma += nominal * ilosc;
                Console.WriteLine($"  {Formatuj(nominal)}: {ilosc} szt.");
            }
            Console.WriteLine($"Łączna wartość: {Formatuj(suma)}");
        }

        private static string Formatuj(decimal wartosc)
        {
            return wartosc.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }
        }
    
