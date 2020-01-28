using System;

namespace api_ctrl_ots.clases
{
    public class c_ot
    {
        public int id { get; set; }
        public int cont { get; set; }
        public DateTime f_Sol { get; set; }
        public string Descrip { get; set; }
        public int idAreaSol { get; set; }
        public int idSolicitante { get; set; }
        public int idAreaAsig { get; set; }
        public DateTime f_Envio { get; set; }
        public int idEstatus { get; set; }
        public int idUrgencia { get; set; }
        public int idComplejidad { get; set; }
        public int tiempoAtn { get; set; }
        public DateTime f_Atn { get; set; }
        public DateTime f_Entrega { get; set; }
        public bool enTiempo { get; set; }
        public string observaciones { get; set; }
        public string obserCancel { get; set; }
        public string obserAtn { get; set; }
    }
}