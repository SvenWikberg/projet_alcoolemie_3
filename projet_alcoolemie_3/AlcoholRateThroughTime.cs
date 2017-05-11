using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_alcoolemie_3 {
    [System.Serializable]

    public class AlcoholRateThroughTime {
        public double AlcoholRate {
            get {
                return _alcoholRate;
            }

            set {
                _alcoholRate = value;
            }
        }
        double _alcoholRate;

        public DateTime Time {
            get {
                return _time;
            }

            set {
                _time = value;
            }
        }
        DateTime _time;

        public bool NormalTimeGap {
            get {
                return _normalTimeGap;
            }

            set {
                _normalTimeGap = value;
            }
        }

        public static int NORMAL_GAP_TIME {   //                    en secondes
            get {
                return 2;
            }
        }

        bool _normalTimeGap;

        public AlcoholRateThroughTime() {

        }

        public AlcoholRateThroughTime(double alcoholRate, DateTime time, bool normalTimeGap) {
            AlcoholRate = alcoholRate;
            Time = time;
            NormalTimeGap = normalTimeGap;
        }
    }
}
