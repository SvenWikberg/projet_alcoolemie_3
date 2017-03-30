/*
 * Sven Wikberg
 * 30 mars 2016
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace projet_alcoolemie_3 {

    [System.Serializable]
    public class Modele {

        const double ACLOHOL_DECREASING = 0.15 * 60 * 10; // en ‰ (pour mille) par heures, en vrai c'est 0.15
        const int NORMAL_GAP_TIME = 2; // en secondes

        public string Username {
            get {
                return _username;
            }

            set {
                _username = value;
            }
        }
        string _username;

        public int Poids {
            get {
                return _poids;
            }

            set {
                _poids = value;
            }
        }
        int _poids;

        public bool EstHomme {
            get {
                return _estHomme;
            }

            set {
                _estHomme = value;
            }
        }
        bool _estHomme;

        public double TauxAlcoolemie {
            get {
                return _tauxAlcoolemie;
            }

            set {
                if (value >= 0) {
                    _tauxAlcoolemie = value;
                }
                else {
                    _tauxAlcoolemie = 0;
                }
            }
        }
        double _tauxAlcoolemie;

        public DateTime DernierCalculTauxAlcoolemie {
            get {
                return _dernierCalculTauxAlcoolemie;
            }

            set {
                _dernierCalculTauxAlcoolemie = value;
            }
        }
        DateTime _dernierCalculTauxAlcoolemie;

        public List<Boisson> Boissons {
            get {
                return _boissons;
            }

            set {
                _boissons = value;
            }
        }
        List<Boisson> _boissons;

        public List<AlcoholRateThroughTime> ListARTT {
            get {
                return _listARTT;
            }

            set {
                _listARTT = value;
            }
        }
        List<AlcoholRateThroughTime> _listARTT;

        public Modele() {
            Boissons = new List<Boisson>();
            ListARTT = new List<AlcoholRateThroughTime>(50);

            //Boissons.Add(new Boisson("Bière", 500, 6));
            //Boissons.Add(new Boisson("Verre de vin", 140, 12));
            //Boissons.Add(new Boisson("Sh", 45, 40));
        }

        public void AddARTT() {
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(ListARTT[49].Time);

            if (span.TotalSeconds > NORMAL_GAP_TIME) {
                ListARTT.Add(new AlcoholRateThroughTime(TauxAlcoolemie, DateTime.Now, false));
            }
            else {
                ListARTT.Add(new AlcoholRateThroughTime(TauxAlcoolemie, DateTime.Now, true));
            }

            if (ListARTT.Count >= 50) {
                ListARTT.RemoveAt(0);
            }
        }

        public void CalculerBaisseTauxAlcoolemie() {
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(DernierCalculTauxAlcoolemie);
            double nbHeures = span.TotalHours;
            TauxAlcoolemie = TauxAlcoolemie - (nbHeures * ACLOHOL_DECREASING);
            DernierCalculTauxAlcoolemie = now;
        }

        public void BoireUneBoisson(Boisson b) {
            double K = (EstHomme ? 0.7 : 0.6);
            TauxAlcoolemie = TauxAlcoolemie + (b.AlcoolBrute / (Poids * K));
        }

        public void Serialize() {
            FileStream fs = new FileStream("myModelData.xml", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(Modele));
            xs.Serialize(fs, this);
            fs.Close();
        }


    }
}
