﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PearlNecklaceDbWebApiConsumerSPA.Models
{
    public class Necklace : INecklace
    {
        [Key]
        [Column("NecklaceID")]
        public int NecklaceID { get; set; }

        [Column("NecklaceName")]
        public string Name { get; set; }
        public virtual List<Pearl> _pearls { get; set; } = new List<Pearl>();
        public Pearl this[int idx] => _pearls[idx];
        public int price
        {
            get
            {
                return Price();
            }
            set { }
        }

        public void Sort()
        {
            _pearls.Sort();
        }

        public override string ToString()
        {
            int returnPrice = 0;
            int NumberOfPearls = this._pearls.Count;
            foreach (var item in this._pearls)
            {
                returnPrice += item.Price;
            }
            return $"Necklace {this.NecklaceID}: {NumberOfPearls} Pearls, Price: {returnPrice} SEK";
        }

        public bool Equals(INecklace other) => NecklaceID == other.NecklaceID;

        public int Price()
        {
            int price = 0;
            if (_pearls == null)
            {
                return 0;
            }
            else
            {
                foreach (var pearl in this._pearls)
                {
                    price += pearl.Price;
                }
            }
            return price;
        }

        public void RandomInit()
        {
            throw new NotImplementedException();
        }

        public void ShowPearls()
        {
            foreach (var item in this._pearls)
            {
                Console.WriteLine($"{item}");
            }
        }

        public void Copy(INecklace src)
        {
            Name = src.Name;
        }
        public Necklace() { }

        public Necklace(INecklace src)
        {
            Copy(src);
        }
    }
    public static class Factory
    {
        static readonly string[] names = "Albanian Andorran Austrian Belarussian Belgian Bosnian Bulgarian Croatian Czech Danish Estonian Finnish French German Greek Hungarian Icelandic Irish Italian Latvian Lithuanian Maltan Moldovoan Monacan Dutch Macedonian Serbian Slovakian Swiss Swedish English Bahaman Canadian Cuban Honduran Argentinian Bolivian Brazilian Colombian Benin Chad Egyptian Gabon Ghanan Kenyan Libyan Togo Zambian Afghani Bhutan Cambodian Chinese Georgian Indian Iranian Iraqi Japanese Kuwait Lebanese Mongoloian NorthKorean Syrian Vietnamese Australian Fiji Samoan Tongan".Split(' ');

        /// <summary>
        /// Create a randomized necklace with 10 to 51 random pearls.
        /// </summary>
        /// <returns>Necklace object with pearls.</returns>
        public static Necklace CreateRandom()
        {
            var necklace = new Necklace();
            var rnd = new Random();
            necklace.Name = names[rnd.Next(0, names.Length)];

            var rndList = new List<Pearl>();
            int pearls = rnd.Next(10, 51);
            for (int i = 0; i < pearls; i++)
            {
                Pearl pearl = Pearl.Factory.CreateRandomPearl();
                rndList.Add(pearl);
            }
            necklace._pearls = rndList;
            return necklace;
        }

        /// <summary>
        /// Create a randomized necklace with a set amount of pearls.
        /// </summary>
        /// <param name="amount"> Amount of randomized pearls created.</param>
        /// <returns>Necklace object with pearls.</returns>
        public static Necklace CreateRandom(int amount)
        {
            var necklace = new Necklace();
            var rnd = new Random();
            necklace.Name = names[rnd.Next(0, names.Length)];

            var rndList = new List<Pearl>();
            for (int i = 0; i < amount; i++)
            {
                Pearl pearl = Pearl.Factory.CreateRandomPearl();
                rndList.Add(pearl);
            }
            necklace._pearls = rndList;
            return necklace;
        }
    }
}
