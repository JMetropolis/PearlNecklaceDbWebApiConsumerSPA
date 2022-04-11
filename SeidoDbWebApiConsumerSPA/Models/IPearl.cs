using System;

namespace PearlNecklaceDbWebApiConsumerSPA.Models
{

    public interface IPearl : IEquatable<IPearl>, IRandomInit
    {
        public enum PearlColor { Black, White, Pink }
        public enum PearlShape { Round, Tear }
        public enum PearlType { Freshwater, Saltwater }

        public int ID { get; set; }
        public int necklaceID { get; set; }
        public int Size { get; set; }
        public PearlColor Color { get; set; }
        public PearlShape Shape { get; set; }
        public PearlType Type { get; set; }
        public int Price { get; set; }
        public int CompareTo(Pearl other);
        public void RandomInit();
        public bool Equals(Pearl other);
    }
}
