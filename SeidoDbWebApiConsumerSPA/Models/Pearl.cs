using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PearlNecklaceDbWebApiConsumerSPA.Models
{
	public enum PearlColor { Black, White, Pink }
	public enum PearlShape { Round, Tear }
	public enum PearlType { Freshwater, Saltwater }
	public class Pearl : IPearl
	{
		//const int MinPearlSize = 5;
		//const int MaxPearlSize = 25;
		public int ID { get; set; }
		public int necklaceID { get; set; }
		public int Size { get; set; }
		public PearlColor Color { get; set; }
		public PearlShape Shape { get; set; }
		public PearlType Type { get; set; }
		public int Price
		{
			get
			{
				if (Type == PearlType.Saltwater)
				{
					return (Size * 50) * 2;
				}
				else
				{
					return Size * 50;
				}
			}
		}

		public int CompareTo(Pearl other)
		{
			if (this.Size != other.Size)
				return this.Size.CompareTo(other.Size);
			if (this.Color != other.Color)
				return this.Color.CompareTo(other.Color);
			return this.Shape.CompareTo(other.Shape);
		}

		public bool Equals(IPearl other)
		{
			return (ID, Size, Color, Shape, Type, Price) == (other.ID, other.Size, other.Color, other.Shape, other.Type, other.Price);
		}

		public override string ToString()
		{
			return $"ID: {ID}\n | Size: {Size}mm\n | Color: {Color}\n | Shape: {Shape}\n | Type: {Type}\n | Price: {Price} sek\n \n";
		}

		#region IRandomInit
		public void RandomInit()
		{
			var rnd = new Random();
			bool bAllOK = false;
			while (!bAllOK)
			{
				try
				{
					Size = rnd.Next(5, 26);
					Color = (PearlColor)rnd.Next((int)PearlColor.Black, (int)PearlColor.Pink + 1);
					Shape = (PearlShape)rnd.Next((int)PearlShape.Round, (int)PearlShape.Tear + 1);
					Type = (PearlType)rnd.Next((int)PearlType.Freshwater, (int)PearlType.Saltwater + 1);

					bAllOK = true;
				}
				catch { }
			}
		}
		#endregion

		public Pearl(int NecklaceID)
		{
			this.ID = new int();
			this.necklaceID = NecklaceID;

			RandomInit();
		}
		public Pearl() { }

		public Pearl(IPearl src)
		{
			Color = src.Color;
			Shape = src.Shape;
			Type = src.Type;
			Size = src.Size;

			ID = src.ID;
			necklaceID = src.necklaceID;
		}
	}
}
