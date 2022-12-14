using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace EatMore
{
    public class DAL
    {
        // Databaser

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

        private ObservableCollection<dinPizza> DinPizza;
        private ObservableCollection<dinPizza> _DinPizza;

        private ObservableCollection<DinTop> dintoppingliste;
        private ObservableCollection<DinTop> _dintoppingliste;

        private ObservableCollection<Pizza> test;



        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        public DAL()
        {
            
            _toppingsliste = new ObservableCollection<Top>();
            string fileloadTop = File.ReadAllText("tops.json");
            var FLT = JsonConvert.DeserializeObject<ObservableCollection<Top>>(fileloadTop);
            toppingsliste = new ObservableCollection<Top>(FLT);



            string fileload = File.ReadAllText("pizza.json");
            var FL = JsonConvert.DeserializeObject<ObservableCollection<Pizza>>(fileload);
            DataBasePizza = new ObservableCollection<Pizza>(FL);
            _DataBasePizza = new ObservableCollection<Pizza>();
            
            
            
            // Drik Menu
            //DRIKS
            int drikID = 49;
            DataBaseDrik = new ObservableCollection<Drik>();
            DataBaseDrik.Add(new Drik(drikID++, "1.5L", "1.5L Cola", 35, 1, 35));
            DataBaseDrik.Add(new Drik(drikID++, "1.5L", "1.5L Cola Zero", 35, 1, 35));
            DataBaseDrik.Add(new Drik(drikID++, "1.5L", "1.5L Pepsi", 35, 1, 35));
            DataBaseDrik.Add(new Drik(drikID++, "1.5L", "1.5L Pepsi Max", 35, 1, 35));
            DataBaseDrik.Add(new Drik(drikID++, "1.5L", "1.5L Fanta", 35, 1, 35));
            DataBaseDrik.Add(new Drik(drikID++, "1.5L", "1.5L Faxe Kondi", 35, 1, 35));
            _DataBaseDrik = new ObservableCollection<Drik>();


            //DRINKS 0.5L
            DataBaseDrikHalv = new ObservableCollection<DrikHalv>();
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, "0.5L", "0.5L Cola", 22, 1, 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, "0.5L", "0.5L Cola Zero", 22, 1, 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, "0.5L", "0.5L Pepsi", 22, 1, 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, "0.5L", "0.5L Pepsi Max", 22, 1, 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, "0.5L", "0.5L Fanta", 22, 1, 22));
            DataBaseDrikHalv.Add(new DrikHalv(drikID++, "0.5L", "0.5L Faxe Kondi", 22, 1, 22));
            _DataBaseDrikHalv = new ObservableCollection<DrikHalv>();

            //DRINKS ANDET
            DataBaseDrikAndet = new ObservableCollection<DrikAndet>();
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, "0.5L", "0.5L Øl flaske", 20, 1, 20));
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, "0.5L", "0.5L Red Bull", 20, 1, 20));
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, "200ml", "200ml Capri Sun", 10, 1, 10));
            DataBaseDrikAndet.Add(new DrikAndet(drikID++, "0.5L", "0.5L Vand", 6, 1, 6));
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

        public void JsonStart()
        {


            toppingsliste = new ObservableCollection<Top>();
            int dalTopIDS = 0;

            toppingsliste.Add(new Top(dalTopIDS++, "Tomatsauce", 00.00));  //0
            toppingsliste.Add(new Top(dalTopIDS++, "Mozzarella ost", 15.00)); //1
            toppingsliste.Add(new Top(dalTopIDS++, "Champignon", 10.00));  //2
            toppingsliste.Add(new Top(dalTopIDS++, "Paprika", 10.00)); //3
            toppingsliste.Add(new Top(dalTopIDS++, "Løg", 10.00)); //4
            toppingsliste.Add(new Top(dalTopIDS++, "Ananas", 10.00)); //5
            toppingsliste.Add(new Top(dalTopIDS++, "Majs", 10.00)); //6
            toppingsliste.Add(new Top(dalTopIDS++, "Oliven", 10.00)); //7
            toppingsliste.Add(new Top(dalTopIDS++, "Tomater", 10.00)); //8
            toppingsliste.Add(new Top(dalTopIDS++, "Jalepenos", 10.00)); //9
            toppingsliste.Add(new Top(dalTopIDS++, "Cherrytomater", 10.00)); //10
            toppingsliste.Add(new Top(dalTopIDS++, "Salat", 10.00)); //11
            toppingsliste.Add(new Top(dalTopIDS++, "Agurk", 10.00)); //12
            toppingsliste.Add(new Top(dalTopIDS++, "Rødløg", 10.00)); //13
            toppingsliste.Add(new Top(dalTopIDS++, "Rucola", 10.00)); //14
            toppingsliste.Add(new Top(dalTopIDS++, "Fetaost", 15.00)); //15
            toppingsliste.Add(new Top(dalTopIDS++, "Cheddarost", 15.00)); //16
            toppingsliste.Add(new Top(dalTopIDS++, "Parmesanost", 15.00)); //17
            toppingsliste.Add(new Top(dalTopIDS++, "Skinke", 15.00)); //18
            toppingsliste.Add(new Top(dalTopIDS++, "Rejer", 15.00)); //19
            toppingsliste.Add(new Top(dalTopIDS++, "Kebab", 15.00)); //20
            toppingsliste.Add(new Top(dalTopIDS++, "Pommes frites", 15.00)); //21
            toppingsliste.Add(new Top(dalTopIDS++, "Kylling", 15.00)); //22
            toppingsliste.Add(new Top(dalTopIDS++, "Pepperoni", 15.00)); //23
            toppingsliste.Add(new Top(dalTopIDS++, "Pølse", 15.00)); //24
            toppingsliste.Add(new Top(dalTopIDS++, "Oksekød", 15.00)); //25
            toppingsliste.Add(new Top(dalTopIDS++, "Bearnaisesauce", 15.00)); //26
            toppingsliste.Add(new Top(dalTopIDS++, "Spaghetti", 15.00)); //27
            toppingsliste.Add(new Top(dalTopIDS++, "Bacon", 15.00)); //28
            toppingsliste.Add(new Top(dalTopIDS++, "Oksefilet", 15.00)); //29
            toppingsliste.Add(new Top(dalTopIDS++, "Salami", 15.00)); //30
            toppingsliste.Add(new Top(dalTopIDS++, "Sucuk", 15.00)); //31
            toppingsliste.Add(new Top(dalTopIDS++, "Kødsauce", 15.00)); //32
            toppingsliste.Add(new Top(dalTopIDS++, "Tun", 15.00)); //33
            toppingsliste.Add(new Top(dalTopIDS++, "Parmaskinke", 15.00)); //34
            toppingsliste.Add(new Top(dalTopIDS++, "Kartofler", 15.00)); //35
            toppingsliste.Add(new Top(dalTopIDS++, "Tacosauce", 15.00)); //36
            toppingsliste.Add(new Top(dalTopIDS++, "Pesto", 15.00)); //37
            toppingsliste.Add(new Top(dalTopIDS++, "Falafel", 15.00)); //38
            toppingsliste.Add(new Top(dalTopIDS++, "Dressing", 15.00)); //39
            toppingsliste.Add(new Top(dalTopIDS++, "Guld", 99999.00)); //40

            var saveFileTop = JsonConvert.SerializeObject(toppingsliste, Formatting.Indented);
            File.WriteAllText("tops.json", saveFileTop);


            //Pizza Menu
            DataBasePizza = new ObservableCollection<Pizza>();
            int MenuID = 0;
            int MenuNummer = 1;
            double BasePrisPizza = 25;

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Pepperoni", new ObservableCollection<Top>() { toppingsliste[0], toppingsliste[1], toppingsliste[3] }, BasePrisPizza, 1, 0));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Rejer", new ObservableCollection<Top>() { toppingsliste[0], toppingsliste[1], toppingsliste[18], toppingsliste[19] }, BasePrisPizza, 1, 0));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Skinke", new ObservableCollection<Top>() { toppingsliste[0], toppingsliste[1], toppingsliste[18] }, BasePrisPizza, 1, 0));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Genova", new ObservableCollection<Top>() { toppingsliste[0], toppingsliste[1], toppingsliste[20], toppingsliste[21], toppingsliste[39] }, BasePrisPizza, 1, 0));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Sadig", new ObservableCollection<Top>() { toppingsliste[0], toppingsliste[1], toppingsliste[20], toppingsliste[22], toppingsliste[3], toppingsliste[39] }, BasePrisPizza, 1, 0));

            DataBasePizza.Add(new Pizza(MenuID++, MenuNummer++, "Be a Man", new ObservableCollection<Top>() { toppingsliste[0], toppingsliste[1], toppingsliste[20], toppingsliste[22], toppingsliste[24], toppingsliste[25], toppingsliste[28], toppingsliste[29], toppingsliste[36] }, BasePrisPizza, 1, 0));

            var saveFile = JsonConvert.SerializeObject(DataBasePizza, Formatting.Indented);
            File.WriteAllText("pizza.json", saveFile);
        }
    }

}
