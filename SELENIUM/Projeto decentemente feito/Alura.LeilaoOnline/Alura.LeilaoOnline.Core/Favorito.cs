using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class Favorito
    {
        public int Id { get; set; }
        public int IdInteressada { get; set; }
        public int LeilaoId { get; set; }
        public Leilao LeilaoFavorito { get; set; }
        public Interessada Seguidor { get; set; }
    }
}
