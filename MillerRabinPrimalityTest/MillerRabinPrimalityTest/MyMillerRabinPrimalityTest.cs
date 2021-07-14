using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillerRabinPrimalityTest
{
    public partial class MyMillerRabinPrimalityTest : Component
    {
        public MyMillerRabinPrimalityTest()
        {
            InitializeComponent();
        }

        public MyMillerRabinPrimalityTest(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        bool deger;
        public int k { get; set; }
        public int sayi { get; set; }

        public bool sonuc
        {
            get
            {
                deger = isPrime(sayi, k);
                return deger;
            }
        }
        /// <summary>
        /// İlk adım olarak birkaç özel durum için koşul şartı yazdım daha sonra Miller Rabin testinde n sayısının asal olup olmadığını test etmek için
        /// ilk önce n − 1 = (2^s)*d eşitliğini sağlayan d ve s sayıları hesaplanır. 
        /// Fakat formül gereği d tek sayı olmalıdır. Onun için alttaki while döngüsünü kurdum.
        /// Asallık testi olasılığa dayalı olduğu için ne kadar fazla test edilirse doğru olna olasılığı o kadar artar. Ben bu durumu kullanıcının isteğine bıraktım. 
        /// Rasgele sayı değerleri için  kullanıcının istediği sayıda tekrarlanmalı bu yüzden for döngüsüyle asallık testinin ana fonksiyonuna bulunan değerleri kullanıcının verdiği iterasyon sayısı kadar aktardım.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool isPrime(int n, int k)
        {
            int s = 1;
            if (n <= 1 || n == 4)
                return false;
            if (n <= 3)
                return true;

            int d = n - 1;
            while (d % 2 == 0)
            {
                s++;
                d /= 2;
            }
            for (int i = 0; i < k; i++)
            {
                if (miillerTest(d, n, s) == false)
                    return false;
            }
            return true;
        }
        /// 2 ile asallığını kontrol ettiğim sayıdan bir önceki tek sayı arasında random bir sayı üretiyorum,
        /// bu sayıyı x=a^d (mod n) denkleminde yerine yazıyorum. Çıkan mod sonucuna göre true veya false değeri döndürüyorum.
        /// Eğer istenilen sonuçlar çıkmazsa s-1 e kadar döngüyü devam ettiriyorum.
        /// Eşitlik sağlandığındaysa başka bir denkleme göre mod alıyoruz ve sonucu n-1 ise true değilse false döndürüyoruz.
        /// Bu işlemler k değerine ulaşana kadar herhnagi bir false değeri dönmeyene kadar devam ediyor. Bu sayede asal olduğunu öğrenmek istediğimiz sayının asallığını
        /// random değerler için tekrar tekrar kontrol ediyoruz bu sayede hata olasılığı azalıyor.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool miillerTest(int d, int n, int s)
        {

            Random rnd = new Random();
            int a = rnd.Next(2, n - 1);
            int r = 1;

            double x = Math.Pow(a, d) % n;

            if (x == 1 || x == (n - 1))
                return true;
            if (s == 1)
                return false;
            else
            {
                while (r != s - 1)
                {
                    x = Math.Pow(a, (Math.Pow(2, r)) * d) % n;
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        return true;

                    r = r + 1;
                }
            }

            x = Math.Pow(a, Math.Pow(2, (s - 1)) * d) % n;
            if (x == n - 1)
                return true;
            else
                return false;

        }
    }
}
