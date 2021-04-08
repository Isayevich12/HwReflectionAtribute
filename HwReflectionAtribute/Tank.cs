using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwReflectionAtribute
{
    class Tank
    {
        public int Helth { get; private set; }
        private event Action DamageTake;


        public Tank()
        {
            this.Helth = 100;
        }

        public Tank(int helth)
        {
            this.Helth = helth;
        }



        [LimitOfDemage(10, 95)] 
        public void GetDamage(int percent)// процент урона
        {

            var type = typeof(Tank);
            var methInfo = type.GetMethod("GetDamage");
            var attribute = methInfo.GetCustomAttributes(false).First();

            int minLim = (attribute as LimitOfDemageAttribute).MinValue;
            int maxLim = (attribute as LimitOfDemageAttribute).MAxValue;

            this.Helth = percent < minLim ? this.Helth : percent > maxLim ? this.Helth = 0 : this.Helth -=this.Helth * percent / 100;


            this.DamageTake += this.Helth == 0 ? () => Console.WriteLine("танк уничтожен!!") :
                () => Console.WriteLine($"Осталось {this.Helth} очков жизни"); ;

            this.DamageTake.Invoke();

            this.DamageTake = null;
        }

        public string CheckStatus()
        {          
            return  this.Helth == 0? "Танк уничтожен": this.Helth > 0 ?  $"Осталось {this.Helth} очков здоровья": "Вас взломали))";
        }

    }
}
