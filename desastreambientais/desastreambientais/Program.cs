﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace desastreambientais
{   
    class DAL
    {
        #region Atributos
        private MySqlConnection _conexao;
        private MySqlCommand _comandoDb;
        private MySqlDataAdapter _adaptador;
        private DataSet _dados;
        #endregion

        #region Getters and Setters
        public string Host { get; set; } = "localhost";
        public string DBNome { get; set; } ="";
        public string Usuario { get; set; } ="root";
        public string Senha { get; set; } = "";
        #endregion


        #region Construtor
        public DAL() { }
        #endregion

        #region Metodos
        public void Conectar()
        {
            //dados da conexão
            //servidor, nome do banco, usuario e senha
            //Server=localhost;Database=;Uid=root; Senha=
            string strConexao = "Server=" + Host;
            strConexao += ";Database=" + DBNome;
            strConexao += ";Uid=" + Usuario;
            strConexao += ";Pwd=" + Senha;
            try
            {
                //Bloco de comandos sujeitos a erros
                _conexao = new MySqlConnection(strConexao);
                if (_conexao.State.Equals(ConnectionState.Closed))
                {
                    _conexao.Open();
                }

                _comandoDb = new MySqlCommand();
                _comandoDb.CommandText = strConexao;

                if(_comandoDb.ExecuteNonQuery() !=1)
                {
                    throw new Exception("Falha ao inserir");
                }
            }
            catch(MySqlException erro)
            {
                //Captura o erro, caso ocorra
                throw new Exception("Erro ao inserir" + erro.Message);

            }
            finally
            {
                //Libera o recurso, caso necessário, mesmo no erro
                _conexao.Dispose();

            }
        }
        public void Inserir(string sql) { }
        public void Buscar() { }
        public void Atualizar() { }
        public void Excluir() { }
        #endregion

    }
    
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    
}
