// See https://aka.ms/new-console-template for more information
using System;


namespace Teste
{
    public class Rsa
    {
        
        Random aleatorio = new Random();


        public int Mdc(int n1, int n2)
        {
            while (n2 != 0)
            {
                int r = n1 % n2;
                n1 = n2;
                n2 = r;
            }
            return n1;
        }



        public int GerarChavePublica(int n)
        {
            while (true)
            {
                int e = aleatorio.Next(2, n);
                if (Mdc(n, 2) == 1)
                {
                    return e;
                }
            }
        }



        public int GerarChavePrivada(int totiente, int e)
        {
            int d = 0;
           
            for(int i=1; (e * i % totiente != 1); i++)
            {
                i++;
                d = i;
                
            }
           

            return d;
        }



        public string Criptografar(string texto, int e, int n)
        {
            string texto_cript = "";
            List<char> lista = new List<char>();



            for (int i = 0; i < texto.Length; i++)
            {
                lista.Add(texto[i]);
            }
            foreach (char obj in lista)
            {
                double ascii = obj;
                int k = (int) Math.Pow(ascii, e) % n;
                if(k>255)
                {
                    k = k - 255;
                }
                texto_cript += (char)k;
            }
            return texto_cript;
        }



        public string Descriptografar(string textocript, int n, int d)
        {
            string texto_descript = "";
            List<char> lista = new List<char>();


            for (int i = 0; i < textocript.Length; i++)
            {
                lista.Add(textocript[i]);
            }
            foreach (char obj in lista)
            {
                double ascii = obj;
                int k = (int)Math.Pow(ascii, d) % n;
                texto_descript += (char)k;
            }
            return texto_descript;
        }


    }

    class Program
    {

        static void Main(string[] args)
        {

            Rsa rs = new Rsa();

            var msg = "";
            int p = 3;
            int q = 11;
            int n = p * q;
            int y = (p - 1);
            int x = (q - 1);
            int totiente = x * y;

            int e = 7;

            int d = rs.GerarChavePrivada(totiente, e);

            Console.WriteLine("Digite um texto: ");
            msg = Console.ReadLine();

            msg = rs.Criptografar(msg, e, n);
            Console.WriteLine("Texto Criptografado: " + msg);

            msg = rs.Descriptografar(msg, n, d);
            Console.WriteLine("Texto Descriptografado: " + msg);


        }
    }
}
    




