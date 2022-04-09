using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SeidoDbWebApiConsumerSPA.Models
{
    public class Necklace : INecklace
    {
        public int NecklaceID => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Equals(INecklace other)
        {
            throw new NotImplementedException();
        }

        public int Price()
        {
            throw new NotImplementedException();
        }

        public void RandomInit()
        {
            throw new NotImplementedException();
        }

        public void ShowPearls()
        {
            throw new NotImplementedException();
        }
    }
}
