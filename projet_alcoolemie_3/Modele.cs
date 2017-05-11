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
        private const int NB_ARTT = 600;
        private const double ALCOHOL_DECREASING = 0.15 * 60; // en ‰ (pour mille) par heures, en vrai c'est 0.15

        public double ALCOHOL_DRIVING_MAX_CH {
            get {
                return 0.5;
            }
        }

        public string Username {
            get {
                return _username;
            }

            set {
                _username = value;
            }
        }
        private string _username;

        public int Poids {
            get {
                return _poids;
            }

            set {
                _poids = value;
            }
        }
        private int _poids;

        public bool EstHomme {
            get {
                return _estHomme;
            }

            set {
                _estHomme = value;
            }
        }
        private bool _estHomme;

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
        private double _tauxAlcoolemie;

        public DateTime DernierCalculTauxAlcoolemie {
            get {
                return _dernierCalculTauxAlcoolemie;
            }

            set {
                _dernierCalculTauxAlcoolemie = value;
            }
        }
        private DateTime _dernierCalculTauxAlcoolemie;

        public List<Boisson> Boissons {
            get {
                return _boissons;
            }

            set {
                _boissons = value;
            }
        }
        private List<Boisson> _boissons;

        public List<AlcoholRateThroughTime> ListARTT {
            get {
                return _listARTT;
            }

            set {
                _listARTT = value;
            }
        }
        private List<AlcoholRateThroughTime> _listARTT;

        public Modele() {
            Boissons = new List<Boisson>();
            ListARTT = new List<AlcoholRateThroughTime>(50);

            //Boissons.Add(new Boisson("Bière", 500, 6));
            //Boissons.Add(new Boisson("Verre de vin", 140, 12));
            //Boissons.Add(new Boisson("Sh", 45, 40));
        }

        public void AddARTT() {
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(ListARTT[ListARTT.Count - 1].Time);

            while (ListARTT.Count < NB_ARTT) {
                if (span.TotalSeconds > AlcoholRateThroughTime.NORMAL_GAP_TIME) {
                    ListARTT.Add(new AlcoholRateThroughTime(TauxAlcoolemie, DateTime.Now, false));
                }
                else {
                    ListARTT.Add(new AlcoholRateThroughTime(TauxAlcoolemie, DateTime.Now, true));
                }
            }

            while (ListARTT.Count >= NB_ARTT) {
                ListARTT.RemoveAt(0);
            }
        }

        public void CalculerBaisseTauxAlcoolemie() {
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(DernierCalculTauxAlcoolemie);
            double nbHeures = span.TotalHours;
            TauxAlcoolemie = TauxAlcoolemie - (nbHeures * ALCOHOL_DECREASING);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <returns>temps en secondes</returns>
        public int GetTimeToRate(double rate) {
            if (TauxAlcoolemie < rate) {
                return -1;
            }
            else {
                double alcoholDecreasingSec = 0.15 / (60 * 60);
                double tmp = (TauxAlcoolemie - rate) / alcoholDecreasingSec;
                return (int)tmp;
            }
        }
    }
}
