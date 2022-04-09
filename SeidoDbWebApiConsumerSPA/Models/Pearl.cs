using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeidoDbWebApiConsumerSPA.Models
{
    public class Pearl : IPearl
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int necklaceID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPearl.PearlColor Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPearl.PearlShape Shape { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPearl.PearlType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CompareTo(Pearl other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Pearl other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IPearl other)
        {
            throw new NotImplementedException();
        }

        public void RandomInit()
        {
            throw new NotImplementedException();
        }
    }
}
