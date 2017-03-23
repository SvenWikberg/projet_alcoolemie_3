﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace projet_alcoolemie_3 {

    [System.Serializable]
    public class Modele {
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

        public Modele() {
            Boissons = new List<Boisson>();
        }

        public void CalculerBaisseTauxAlcoolemie() {
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(DernierCalculTauxAlcoolemie);
            double nbHeures = span.TotalHours;
            TauxAlcoolemie = TauxAlcoolemie - (nbHeures * 0.15);
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
