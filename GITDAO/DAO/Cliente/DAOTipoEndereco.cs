using System;
using System.Collections.Generic;
using System.Text;
using GITDAO.Commons.Providers;
using GITDAO.Entity.Cliente;
using MySql.Data.MySqlClient;

namespace GITDAO
{
    public class DAOTipoEndereco
    {
        public int AddRecord(string descricao)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationServiceProvider.GetConnectionString("GTI.MySQL")))
            {
                conn.Open();

                StringBuilder stbComando = new StringBuilder();
                stbComando.Append("Insert into TipoEndereco (descricao) ");
                stbComando.Append($" values ('{descricao}')");

                using (MySqlCommand command = new MySqlCommand(stbComando.ToString(), conn))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<TipoEnderecoModel> GetRecord(int? id = null)
        {
            List<TipoEnderecoModel> objRetorno = new List<TipoEnderecoModel>();

            using (MySqlConnection conn = new MySqlConnection(ConfigurationServiceProvider.GetConnectionString("GTI.MySQL")))
            {
                conn.Open();

                // EXEMPLO DO QUE "NÃO SE DEVE FAZER".... CONCATENAÇÃO "DESENFREADA" DE STRINGS....
                //string strComando = "";
                //strComando += "Select ID";             ''  / 'Select ID'
                //strComando += " , descricao";           ''  / 'Select ID' / 'Select ID , descricao'
                //strComando += "From TipoEndereco ";

                StringBuilder stbComando = new StringBuilder();
                stbComando.Append("Select ID");
                stbComando.Append(" , descricao ");
                stbComando.Append("From TipoEndereco ");
                if (id != null)
                    stbComando.Append(" Where ID = " + id.ToString());

                using (MySqlCommand command = new MySqlCommand(stbComando.ToString(), conn))
                {
                    using (MySqlDataReader mySqlData = command.ExecuteReader())
                    {
                        while (mySqlData.Read())
                        {
                            objRetorno.Add(new TipoEnderecoModel()
                            {
                                ID = (int)mySqlData["ID"],
                                Descricao = (string)mySqlData["descricao"]
                            });
                        }
                    }
                }

                return objRetorno;
            }
        }
    }
}
