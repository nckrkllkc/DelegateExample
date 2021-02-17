using System;

namespace DeletegateExample
{
    //Delegate içerisine ekleyeceğiniz metotlar delegate'in tanımına uygun olmalıdır(dönüş değeri, parametreler)
    //parametre almayan, void döndüren metotları barındıran delegate
    public delegate void MyDelegate();
    //int döndüren ve parametre alan metotları barındıran delegate
    public delegate int MyDelegate2(int sayi1, int sayi2);
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new();
            //Metot ataması yaparak delegate oluşturma
            MyDelegate myDelegate = customerManager.SendMessage;
            //delegate içerisine metot ekleme
            myDelegate += customerManager.ShowAlert;
            myDelegate();
            myDelegate -= customerManager.SendMessage; // delegate içerisinden metot silme

            //parametre vererek de delegate oluşturabilirsiniz.
            MyDelegate2 myDelegate2 = new MyDelegate2(customerManager.Topla);
            myDelegate2 += customerManager.Carp;

            //parametreli metotları barındıran delegate kullanımı
            //ekrana delegate içerisindeki en son metotdan dönen değer yazılacaktır.
            Console.WriteLine(myDelegate2(2, 4));
        }
    }

    class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be careful");
        }

        public int Topla(int sayi1 , int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
