using System;

namespace SEAT.CargaFicherosApp.Domain.Models
{
    public class GBPLModel
    {
        public string COUPSEAT { get; set; }
        public string  COCLAVW0 { get; set; }
        public string  COMPANIA { get; set; }
        public string  CLIEFNR { get; set; }
        public string  COTIPNUM { get; set; }
        private string  _FEINIEFE ;
        public string  FEINIEFE 
        { 
            get{return _FEINIEFE;}
            set{_FEINIEFE =value; }
        }
        private string  _FEFINHIS ;
        public string  FEFINHIS 
        { 
            get{return _FEFINHIS;}
            set{_FEFINHIS = value; }
        }
        private string  _FECONPED ;
        public string  FECONPED 
        { 
            get{return _FECONPED;}
            set{_FECONPED = value; }
        }
        public string  COORIGE { get; set; }
        public string  COSTATUS { get; set; }
        public string  COUNMEVW { get; set; }
        public string  CODCUOTA { get; set; }
        
        public string  PRUNIDIV { get; set; }
        public string  PRUNIEUR { get; set; }
        public string  PRBRUDIV { get; set; }
        public string  PRBRUEUR { get; set; }
        public string  COMONEDA { get; set; }
        public string  COUNPRVW { get; set; }
        public string  PRELOGIS { get; set; }
        public string  PRADEBON { get; set; }
        public string  PRBRSEEU { get; set; }
        public string  PRVRSEDV { get; set; }
        public string  COMONESE { get; set; }
        public string  COCAUSAL { get; set; }

        private string  _COSIALTA ;
        public string  COSIALTA 
        { 
            get{return _COSIALTA;}
            set{_COSIALTA = value; }
        }
        public string  COWERKVW { get; set; }
        public string  CODUNSNR { get; set; }
        public string  COBESTNR { get; set; }

        private string _FEVERLWE;
        public string  FEVERLWE 
        { 
            get{return _FEVERLWE;}
            set{_FEVERLWE = value; }
        }


        private string _FEVERLST;
        public string  FEVERLST 
        { 
            get{return _FEVERLST;}
            set{_FEVERLST = value; }
        }


        private string _FESIMODI;
        public string  FESIMODI 
        { 
            get{return _FESIMODI;}
            set{_FESIMODI = value; }
        }
        private string _CODRESTO;
        public string  CODRESTO 
        { 
            get{return _CODRESTO;}
            set{_CODRESTO = value; }
        }

    }
}