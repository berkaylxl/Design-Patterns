using System;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PromosyonBuilder builder = new WomenBuilder();
            SendPromosyon promosyon = new SendPromosyon();
            promosyon.Send(builder);
            builder.GetPromosyon.ShowPromosyon();
        }
         class Promosyon
        {
            public int promosyonID  { get; set; }
            public string  promosyonName { get; set; }
            public string ShowPromosyon()
            {
                Console.WriteLine($"{promosyonID} numaralı , {promosyonName} promosyonu verilmiştir.");
                return "";
            }
        }
        abstract class PromosyonBuilder
        {
            protected Promosyon _promosyon;
            public Promosyon GetPromosyon
            {
                get
                {
                    return _promosyon;
                }
            }
            public abstract void setPromosyonID();
            public abstract void setPromosyonName();
        }
          class WomenBuilder : PromosyonBuilder
        {
            public WomenBuilder()
            {
                _promosyon = new Promosyon();
            }
            public override void setPromosyonID()
            {
                _promosyon.promosyonID = 1254785478;
            }

            public override void setPromosyonName()
            {
                _promosyon.promosyonName = "WomenPM15478";
            }
        }
        class ManBuilder : PromosyonBuilder
        {
            public override void setPromosyonID()
            {
                _promosyon.promosyonID = 465485478;
            }

            public override void setPromosyonName()
            {
                _promosyon.promosyonName = "ManPM78954";
            }
        }
        class SendPromosyon
        {
            public void Send(PromosyonBuilder builder)
            {
                builder.setPromosyonID();
                builder.setPromosyonName();
            }
        }




    }
}
