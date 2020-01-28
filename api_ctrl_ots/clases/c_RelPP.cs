using System;

namespace api_ctrl_ots.clases
{
    public class c_RelPP
    {
        public int id { get; set; }
        public int idDA { get; set; }
        public int idDir { get; set; }
        public int idSubDir { get; set; }
        public int idGerencia { get; set; }
        public int idPersona { get; set; }
        public DateTime f_inicio { get; set; }
        public DateTime f_fin { get; set; }
        public bool status { get; set; }
    }
}