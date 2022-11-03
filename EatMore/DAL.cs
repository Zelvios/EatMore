using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class DAL
    {
        private ObservableCollection<Pizza> DataBasePizza;

        private ObservableCollection<Pizza> _DataBasePizza;

        private ObservableCollection<Drik> DataBaseDrik;

        private ObservableCollection<Drik> _DataBaseDrik;

        private ObservableCollection<DrikHalv> DataBaseDrikHalv;

        private ObservableCollection<DrikHalv> _DataBaseDrikHalv;

        private ObservableCollection<DrikAndet> DataBaseDrikAndet;

        private ObservableCollection<DrikAndet> _DataBaseDrikAndet;
        private ObservableCollection<Top> toppingsliste;
        private ObservableCollection<Top> _toppingsliste;

        private ObservableCollection<Pizza> Odreliste;
        private ObservableCollection<Pizza> _Odreliste;


        private ObservableCollection<dinPizza> DinPizza;
        private ObservableCollection<dinPizza> _DinPizza;

        private ObservableCollection<DinTop> dintoppingliste;
        private ObservableCollection<DinTop> _dintoppingliste;



        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        public DAL()
        {

            Odreliste = new ObservableCollection<Pizza>();
            _Odreliste= new ObservableCollection<Pizza>();


            toppingsliste = new ObservableCollection<Top>();
            int dalTopIDS = 0;

            toppingsliste.Add(new Top(dalTopIDS++, "Champignon", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Paprika", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Løg", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Ananas", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Majs", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Oliven", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Tomater", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Jalepenos", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Cherrytomater", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Salat", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Agurk", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Rødløg", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Rucola", 10.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Mozzarella ost", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Fetaost", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Cheddarost", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Parmesanost", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Skinke", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Rejer", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Kebab", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Pommes frites", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Kylling", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Pepperoni", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Pølse", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Oksekød", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Bearnaisesauce", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Spaghetti", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Bacon", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Oksefilet", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Salami", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Sucuk", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Kødsauce", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Tun", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Parmaskinke", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Kartofler", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Tacosauce", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Pesto", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Falafel", 15.00));
            toppingsliste.Add(new Top(dalTopIDS++, "Guld", 99999.00));

            _toppingsliste = new ObservableCollection<Top>();




            DataBasePizza = new ObservableCollection<Pizza>();
            int MenuID = 0;
            int MenuNummer = 1;
            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Pepperoni", new ObservableCollection<Top>() { toppingsliste[0] }, 80.00, 1));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Rejer", new ObservableCollection<Top>() { toppingsliste[1] }, 80.00, 1));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Skinke", new ObservableCollection<Top>() { toppingsliste[3] }, 80.00, 1));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Genova", new ObservableCollection<Top>() { toppingsliste[5], toppingsliste[6], toppingsliste[8] }, 80.00, 1));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Sadig", new ObservableCollection<Top>() { toppingsliste[6], toppingsliste[7], toppingsliste[9] }, 80.00, 1));


            _DataBasePizza = new ObservableCollection<Pizza>();
            // ---------------------------------------------------------------------------------------------------------------------------------------------------


            //DRIKS
            int drikID = 49;
            DataBaseDrik = new ObservableCollection<Drik>();
            DataBaseDrik.Add(new Drik(drikID++, 1.5, "Cola", 35));
            DataBaseDrik.Add(new Drik(drikID++, 1.5, "Cola Zero", 35));
            DataBaseDrik.Add(new Drik(drikID++, 1.5, "Pepsi", 35));
            DataBaseDrik.Add(new Drik(drikID++, 1.5, "Pepsi Max", 35));
            DataBaseDrik.Add(new Drik(drikID++, 1.5, "Fanta", 35));
            DataBaseDrik.Add(new Drik(drikID++, 1.5, "Faxe Kondi", 35));
            _DataBaseDrik = new ObservableCollection<Drik>();


            //DRINKS 0.5L
            DataBaseDrikHalv = new ObservableCollection<DrikHalv>();
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, 0.5, "Cola", 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, 0.5, "Cola Zero", 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, 0.5, "Pepsi", 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, 0.5, "Pepsi Max", 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, 0.5, "Fanta", 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, 0.5, "Faxe Kondi", 22));
            _DataBaseDrikHalv = new ObservableCollection<DrikHalv>();

            //DRINKS ANDET
            DataBaseDrikAndet = new ObservableCollection<DrikAndet>();
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, 0.5, "Øl flaske", 20));
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, 0.5, "Red Bull", 20));
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, 0.5, "Capri Sun", 10));
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, 0.5, "Vand", 6));
            _DataBaseDrikAndet = new ObservableCollection<DrikAndet>();
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------


        


        public ObservableCollection<Pizza> Get()
        {
            return DataBasePizza;
        }

        public ObservableCollection<Top> TGet()
        {
            return toppingsliste;
        }

        public ObservableCollection<Top> Toppings_Get()
        {
            _toppingsliste.Clear(); //Først tømmes den lokale kopi
                                   //Så løber vi alle elementerne igennem i databasen og overfører til lokal kopi
            foreach (Top p in toppingsliste)
            {
                _toppingsliste.Add(p);
            }
            return _toppingsliste;
        }



        public ObservableCollection<Drik> Drik_Get()
        {
            _DataBaseDrik.Clear(); //Først tømmes den lokale kopi
                                    //Så løber vi alle elementerne igennem i databasen og overfører til lokal kopi
            foreach (Drik p in DataBaseDrik)
            {
                _DataBaseDrik.Add(p);
            }
            return _DataBaseDrik;
        }

        public ObservableCollection<DrikHalv> DrikHalv_Get()
        {
            _DataBaseDrikHalv.Clear(); //Først tømmes den lokale kopi
                                   //Så løber vi alle elementerne igennem i databasen og overfører til lokal kopi
            foreach (DrikHalv p in DataBaseDrikHalv)
            {
                _DataBaseDrikHalv.Add(p);
            }
            return _DataBaseDrikHalv;
        }

        public ObservableCollection<DrikAndet> DrikAndet_Get()
        {
            _DataBaseDrikAndet.Clear(); //Først tømmes den lokale kopi
                                   //Så løber vi alle elementerne igennem i databasen og overfører til lokal kopi
            foreach (DrikAndet p in DataBaseDrikAndet)
            {
                _DataBaseDrikAndet.Add(p);
            }
            return _DataBaseDrikAndet;
        }

        public ObservableCollection<Pizza> Pizza_Get()
        {
            _DataBasePizza.Clear(); //Først tømmes den lokale kopi
                                  //Så løber vi alle elementerne igennem i databasen og overfører til lokal kopi
            foreach (Pizza p in DataBasePizza)
            {
                _DataBasePizza.Add(p);
            }
            return _DataBasePizza;
        }




    }
   
}
