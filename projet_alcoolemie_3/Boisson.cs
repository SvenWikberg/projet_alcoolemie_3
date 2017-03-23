using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_alcoolemie_3 {
    [System.Serializable]
    public class Boisson {
        // Nom de la boisson
        private string _nom;
        public string Nom {
            get {
                return _nom;
            }

            set {
                _nom = value;
            }
        }

        // Quantité en ml de la boisson
        private double _quantite;
        public double Quantite {
            get {
                return _quantite;
            }

            set {
                _quantite = value;
            }
        }

        /// <summary> Degré d'alcool dans la boisson (valide entre 0 et 100)</summary>
        public double Degre {
            get {
                return _degre;
            }

            set {
                if (value > 100) {
                    value = 100;
                }
                else {
                    if (value < 0) {
                        value = 0;
                    }
                }
                _degre = value;
            }
        }
        private double _degre;

        // Quantité d'alcool dans la boisson, en gramme
        public double AlcoolBrute {
            get {
                //0.8 est car 1L d'alcool pur pèse 0.8kg
                return ((Degre * Quantite) / 100) * 0.8;
            }
        }

        // tostring
        public override string ToString() {
            return String.Format("{0} - {1}ml", Nom, Quantite);
        }

        // pour que ca coit serializable
        public Boisson() { }

        public Boisson(string nom, double quantite, double degre) {
            Nom = nom;
            Quantite = quantite;
            Degre = degre;
        }
    }
}
