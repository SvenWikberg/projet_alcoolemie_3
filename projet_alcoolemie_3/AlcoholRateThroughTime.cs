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

        public AlcoholRateThroughTime() {

        }

        public AlcoholRateThroughTime(double alcoholRate, DateTime time) {
            AlcoholRate = alcoholRate;
            Time = time;
        }
    }
}
