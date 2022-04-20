using System;
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

        #region IEquatable
        public bool Equals(INecklace other) => NecklaceID == other.NecklaceID;

        #endregion

        #region IRandomInit
        public void RandomInit()
        {
            string[] names = "Albanian Andorran Austrian Belarussian Belgian Bosnian Bulgarian Croatian Czech Danish Estonian Finnish French German Greek Hungarian Icelandic Irish Italian Latvian Lithuanian Maltan Moldovoan Monacan Dutch Macedonian Serbian Slovakian Swiss Swedish English Bahaman Canadian Cuban Honduran Argentinian Bolivian Brazilian Colombian Benin Chad Egyptian Gabon Ghanan Kenyan Libyan Togo Zambian Afghani Bhutan Cambodian Chinese Georgian Indian Iranian Iraqi Japanese Kuwait Lebanese Mongoloian NorthKorean Syrian Vietnamese Australian Fiji Samoan Tongan".Split(' ');

            var rnd = new Random();
            bool bAllOK = false;
            while (!bAllOK)
            {
                try
                {
                    this.Name = names[rnd.Next(0, names.Length)];

                    bAllOK = true;
                }
                catch { }
            }
        }
        #endregion

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
            string name = this.Name;
            foreach (var item in this._pearls)
            {
                returnPrice += item.Price;
            }
            return $"Necklace {this.NecklaceID}: {name}, {NumberOfPearls} Pearls, Price: {returnPrice} SEK";
        }

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

        public void ShowPearls()
        {
            foreach (var item in this._pearls)
            {
                Console.WriteLine($"{item}");
            }
        }

        public Necklace Copy(INecklace src)
        {
            Name = src.Name;
            return this;
        }


        public Necklace()
        {
            this.NecklaceID = new int();
        }

        public Necklace(bool randominit) : this()
        {
            if (randominit)
                RandomInit();
        }

        //Copy Constructor
        public Necklace(INecklace src)
        {
            this.Copy(src);
        }
    }
}
