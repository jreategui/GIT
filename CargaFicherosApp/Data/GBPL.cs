using System;
using CsvHelper.Configuration;

namespace CargaFicherosApp.Data
{
    public class GBPL
    {
        public string COUPSEAT { get; set; }
        public string  COCLAVW0 { get; set; }
        public string  COMPANIA { get; set; }
        public string  CLIEFNR { get; set; }
        public string  COTIPNUM { get; set; }
        private DateTime  _FEINIEFE ;
        public DateTime  FEINIEFE 
        { 
            get{return _FEINIEFE;}
            set{_FEINIEFE = value; }
        }
        private DateTime  _FEFINHIS ;
        public DateTime  FEFINHIS 
        { 
            get{return _FEFINHIS;}
            set{_FEFINHIS = value; }
        }
        private DateTime  _FECONPED ;
        public DateTime  FECONPED 
        { 
            get{return _FECONPED;}
            set{_FECONPED = value; }
        }
        public string  COORIGE { get; set; }
        public string  COSTATUS { get; set; }
        public string  COUNMEVW { get; set; }
        public string  CODCUOTA { get; set; }
        
        public double  PRUNIDIV { get; set; }
        public double  PRUNIEUR { get; set; }
        public double  PRBRUDIV { get; set; }
        public double  PRBRUEUR { get; set; }
        public string  COMONEDA { get; set; }
        public string  COUNPRVW { get; set; }
        public string  PRELOGIS { get; set; }
        public double  PRADEBON { get; set; }
        public double  PRBRSEEU { get; set; }
        public double  PRVRSEDV { get; set; }
        public string  COMONESE { get; set; }
        public string  COCAUSAL { get; set; }

        private DateTime  _COSIALTA ;
        public DateTime  COSIALTA 
        { 
            get{return _COSIALTA;}
            set{_COSIALTA = value; }
        }
        public string  COWERKVW { get; set; }
        public string  CODUNSNR { get; set; }
        public string  COBESTNR { get; set; }

        private DateTime _FEVERLWE;
        public DateTime  FEVERLWE 
        { 
            get{return _FEVERLWE;}
            set{_FEVERLWE = value; }
        }


        private DateTime _FEVERLST;
        public DateTime  FEVERLST 
        { 
            get{return _FEVERLST;}
            set{_FEVERLST = value; }
        }


        private DateTime _FESIMODI;
        public DateTime  FESIMODI 
        { 
            get{return _FESIMODI;}
            set{_FESIMODI = value; }
        }
        private DateTime _CODRESTO;
        public DateTime  CODRESTO 
        { 
            get{return _CODRESTO;}
            set{_CODRESTO = value; }
        }

    }
}