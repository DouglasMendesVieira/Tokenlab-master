using System;
using System.Collections.Generic;

namespace Tokenlab.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraTermino { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}