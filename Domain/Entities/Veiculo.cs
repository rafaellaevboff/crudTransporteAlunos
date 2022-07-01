using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Veiculo
    {
        public Veiculo(){}
        public Veiculo(int id, string nome, string placa, int ano, string cor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Placa = placa;
            this.Ano = ano;
            this.Cor = cor;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public List<Motorista> Motoristas { get; set; }
    }
}